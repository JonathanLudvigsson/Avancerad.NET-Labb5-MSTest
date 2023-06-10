using KiwiBankomaten;

namespace KiwiBankomatenTests
{
    [TestClass]
    public class ConvertCurrencyTests
    {
        [TestMethod]
        public void Convert_Usd_To_SEK_Method_Test()
        {
            //Arrange
            Customer c1 = DataBase.CustomerDict[1];
            BankAccount bankAccount = c1.BankAccounts[4];

            //Act
            decimal expected = bankAccount.Amount * DataBase.ExchangeRates["USD"];
            decimal actual = c1.ConvertToSek(bankAccount);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Convert_SEK_To_EUR()
        {
            //Arrange
            decimal sek = 5000;

            //Act
            decimal expected = sek * 10.85m;
            decimal actual = sek * DataBase.ExchangeRates["EUR"];

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
