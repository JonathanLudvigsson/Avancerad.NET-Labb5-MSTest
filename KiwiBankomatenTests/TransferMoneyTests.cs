using KiwiBankomaten;

namespace KiwiBankomatenTests
{
    [TestClass]
    public class TransferMoneyTests
    {
        [TestMethod]
        public void TransferMoney_SameValues_500kr()
        {
            //Arrange
            Customer c1 = KiwiBankomaten.DataBase.CustomerDict[1];
            int account1Num = c1.BankAccounts[1].AccountNumber;
            int account2Num = c1.BankAccounts[2].AccountNumber;
            decimal moneyToTransfer = 500;
            decimal expectedFirstAccount = c1.BankAccounts[1].Amount - moneyToTransfer;
            decimal expectedSecondAccount = c1.BankAccounts[2].Amount + moneyToTransfer;

            //Act
            c1.TransferMoney(account2Num, account1Num, moneyToTransfer);

            //Assert
            Assert.AreEqual(expectedFirstAccount, c1.BankAccounts[1].Amount);
            Assert.AreEqual(expectedSecondAccount, c1.BankAccounts[2].Amount);
        }
        [TestMethod]
        public void TransferMoney_SEKToUSD_5000kr()
        {
            //Arrange
            Customer c1 = KiwiBankomaten.DataBase.CustomerDict[1];
            int account1Num = c1.BankAccounts[1].AccountNumber;
            int Account2Num = c1.BankAccounts[4].AccountNumber;
            decimal amountToTransfer = 5000;
            decimal rate1 = DataBase.ExchangeRates[c1.BankAccounts[1].Currency];
            decimal rate2 = DataBase.ExchangeRates[c1.BankAccounts[4].Currency];

            decimal expectedFirstAccount = c1.BankAccounts[1].Amount - amountToTransfer;
            decimal expectedSecondAccount = c1.BankAccounts[4].Amount + (amountToTransfer / rate2);

            //Act
            c1.TransferMoney(Account2Num, account1Num, amountToTransfer);

            //Assert
            Assert.AreEqual(expectedFirstAccount, c1.BankAccounts[1].Amount);
            Assert.AreEqual(expectedSecondAccount, c1.BankAccounts[4].Amount);
        }
        [TestMethod]
        public void TransferMoney_NegativeAmount_Minus5000()
        {
            //Arrange
            Customer c1 = KiwiBankomaten.DataBase.CustomerDict[1];
            int account1Num = c1.BankAccounts[1].AccountNumber;
            int account2Num = c1.BankAccounts[2].AccountNumber;
            decimal moneyToTransfer = -5000;
            decimal expectedFirstAccount = c1.BankAccounts[1].Amount;
            decimal expectedSecondAccount = c1.BankAccounts[2].Amount;

            //Act
            c1.TransferMoney(account2Num, account1Num, moneyToTransfer);

            //Assert
            Assert.AreEqual(expectedFirstAccount, c1.BankAccounts[1].Amount);
            Assert.AreEqual(expectedSecondAccount, c1.BankAccounts[2].Amount);
        }
        [TestMethod]
        public void TransferMoney_MoreMoneyThanIsInAccount()
        {
            //Arrange
            Customer c1 = KiwiBankomaten.DataBase.CustomerDict[1];
            int account1Num = c1.BankAccounts[1].AccountNumber;
            int account2Num = c1.BankAccounts[2].AccountNumber;
            decimal moneyToTransfer = 5000000000;
            decimal expectedFirstAccount = c1.BankAccounts[1].Amount;
            decimal expectedSecondAccount = c1.BankAccounts[2].Amount;

            //Act
            c1.TransferMoney(account2Num, account1Num, moneyToTransfer);

            //Assert
            Assert.AreEqual(expectedFirstAccount, c1.BankAccounts[1].Amount);
            Assert.AreEqual(expectedSecondAccount, c1.BankAccounts[2].Amount);
        }
    }
}