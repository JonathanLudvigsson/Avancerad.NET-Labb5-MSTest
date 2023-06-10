using KiwiBankomaten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiBankomatenTests
{
    [TestClass]
    public class UserAccountTests
    {
        [TestMethod]
        public void Create_New_Customer_Test()
        {
            //Arrange
            Admin admin = DataBase.AdminList[1];

            //Act
            admin.CreateNewUser(1, "TestUser123", "user53");
            Customer newestCustomer = DataBase.CustomerDict[DataBase.CustomerDict.Keys.Last()];

            //Assert
            Assert.IsTrue(newestCustomer.UserName == "TestUser123" && newestCustomer.Password == "user53");

        }
        [TestMethod]
        public void Create_New_Admin_Test()
        {
            //Arrange
            Admin admin = DataBase.AdminList[1];

            //Act
            admin.CreateNewUser(2, "TestAdmin2", "admin64");
            Admin newestAdmin = DataBase.AdminList.Last();

            //Assert
            Assert.IsTrue(newestAdmin.UserName == "TestAdmin2" && newestAdmin.Password == "admin64");

        }
        [TestMethod]
        public void Lock_Customer_Account()
        {
            //Arrange
            Admin admin = DataBase.AdminList[1];

            //Act
            admin.LockOrUnlockAccount(DataBase.CustomerDict[1], true);

            //Assert
            Assert.IsTrue(DataBase.CustomerDict[1].Locked == true);

        }
        [TestMethod]
        public void Unlock_Customer_Account()
        {
            //Arrange
            Admin admin = DataBase.AdminList[1];

            //Act
            DataBase.CustomerDict[2].Locked = true;
            admin.LockOrUnlockAccount(DataBase.CustomerDict[2], true);

            //Assert
            Assert.IsTrue(DataBase.CustomerDict[2].Locked == false);

        }
    }
}
