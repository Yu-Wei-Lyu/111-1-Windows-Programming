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
    public class ManagementFormGUIUnitTest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_FORM = "MenuForm";

        // init
        [TestInitialize()]
        public void Initialize()
        {
            string projectName = "Library109590004";
            string appPath = Path.Combine(projectName, "bin", "Debug", projectName + ".exe");
            string projectFileName = "HW5";
            string solutionPath = AppDomain.CurrentDomain.BaseDirectory;
            while (Directory.GetParent(solutionPath).Name != projectFileName)
                solutionPath = Path.GetFullPath(Path.Combine(solutionPath, "..\\"));
            targetAppPath = Path.Combine(solutionPath, appPath);
            _robot = new Robot(targetAppPath, START_UP_FORM);
            _robot.ClickElementByText("Book Management System");
            _robot.SwitchTo("BookManagementForm");
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // TestMethod
        [TestMethod()]
        public void TestInventoryDataView()
        {
            _robot.AssertListBoxItemNameExist("暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫");
        }

        // TestMethod
        [TestMethod()]
        public void TestAddBookButton()
        {
            _robot.AssertEnableByText("新增書籍", false);
        }

        // TestMethod
        [TestMethod()]
        public void TestBookNameTextBox()
        {
            _robot.AssertEnableByName("_bookNameTextBox", false);
            _robot.ClickListBoxItemBy("零零落落");
            _robot.AssertEnableByName("_bookNameTextBox", true);
            _robot.AssertText("_bookNameTextBox", "零零落落");
        }

        // TestMethod
        [TestMethod()]
        public void TestBookIdTextBox()
        {
            _robot.AssertEnableByName("_bookIdTextBox", false);
            _robot.ClickListBoxItemBy("零零落落");
            _robot.AssertEnableByName("_bookIdTextBox", true);
            _robot.AssertText("_bookIdTextBox", "851.486 8345:2 2022");
        }

        // TestMethod
        [TestMethod()]
        public void TestBookAuthorTextBox()
        {
            _robot.AssertEnableByName("_bookAuthorTextBox", false);
            _robot.ClickListBoxItemBy("零零落落");
            _robot.AssertEnableByName("_bookAuthorTextBox", true);
            _robot.AssertText("_bookAuthorTextBox", "黃春明");
        }

        // TestMethod
        [TestMethod()]
        public void TestBookPublicationTextBox()
        {
            _robot.AssertEnableByName("_bookPublicationTextBox", false);
            _robot.ClickListBoxItemBy("零零落落");
            _robot.AssertEnableByName("_bookPublicationTextBox", true);
            _robot.AssertText("_bookPublicationTextBox", "聯合文學, 2022[民111]");
        }

        // TestMethod
        [TestMethod()]
        public void TestBookImagePathTextBox()
        {
            _robot.AssertEnableByName("_bookImagePathTextBox", false);
            _robot.ClickListBoxItemBy("零零落落");
            _robot.AssertEnableByName("_bookImagePathTextBox", true);
            _robot.AssertText("_bookImagePathTextBox", "../../../image/4.jpg");
        }

        // TestMethod
        [TestMethod()]
        public void TestBookCategoryComboBox()
        {
            _robot.AssertEnableByName("_bookCategoryComboBox", false);
            _robot.ClickListBoxItemBy("零零落落");
            _robot.AssertEnableByName("_bookCategoryComboBox", true);
            _robot.AssertText("_bookCategoryComboBox", "6月暢銷書");
        }
        //_applyChangedButton
        // TestMethod
        [TestMethod()]
        public void TestApplyChangedButton()
        {
            _robot.AssertEnableByText("儲存", false);
            _robot.ClickListBoxItemBy("零零落落");
            _robot.ClickElementByName("_bookNameTextBox");
            _robot.SendKey("MODIFY");
            _robot.AssertEnableByText("儲存", true);
            _robot.ClickElementByText("儲存");
            _robot.AssertEnableByText("儲存", false);
            _robot.AssertListBoxItemNameExist("零零落落MODIFY");
        }
    }
}
