using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004Tests
{
    [TestClass()]
    public class MenuFormGUITest
    {
        private Robot _robot;

        // init
        [TestInitialize()]
        public void Initialize()
        {
            _robot = new Robot();
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // test
        public void MenuButtonEnableTest(string formType)
        {
            string button = string.Format("Book {0} System", formType);
            _robot.AssertEnableByText(button, true);
            _robot.ClickElementByText(button);
            _robot.AssertEnableByText(button, false);
            _robot.SwitchTo(string.Format("Book{0}Form", formType));
            _robot.CloseWindow();
            _robot.SwitchTo("MenuForm");
            _robot.AssertEnableByText(button, true);
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingSystemButton()
        {
            MenuButtonEnableTest("Borrowing");
        }

        // TestMethod
        [TestMethod()]
        public void TestInventorySystemButton()
        {
            MenuButtonEnableTest("Inventory");
        }

        // TestMethod
        [TestMethod()]
        public void TestManagementSystemButton()
        {
            MenuButtonEnableTest("Management");
        }
    }
}
