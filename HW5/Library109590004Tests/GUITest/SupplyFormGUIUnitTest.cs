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
    public class SupplyFormGUIUnitTest
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
            _robot.ClickElementByText("Book Inventory System");
            _robot.SwitchTo("BookInventoryForm");
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // TestMethod
        [TestMethod()]
        public void TestSupplyBookDetailTextBox()
        {
            _robot.ClickDataGridViewCellBy("_inventoryDataView", 0, "補貨");
            _robot.SwitchTo("SupplyForm");
            _robot.AssertText("_supplyBookDetailTextBox", "書籍名稱：微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r\r書籍類別：6月暢銷書\r庫存數量：5");
            _robot.ClickElementByText("取消");
        }

        // TestMethod
        [TestMethod()]
        public void TestSupplyBookAmountTextBox()
        {
            _robot.ClickDataGridViewCellBy("_inventoryDataView", 0, "補貨");
            _robot.SwitchTo("SupplyForm");
            _robot.AssertText("_supplyBookAmountTextBox", "");
            _robot.AssertText("_supplyBookDetailTextBox", "書籍名稱：微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r\r書籍類別：6月暢銷書\r庫存數量：5");
            _robot.ClickElementByName("_supplyBookAmountTextBox");
            _robot.SendKey("9");
            _robot.ClickElementByText("確認");
            _robot.SwitchTo("BookInventoryForm");
            string[] expectedStringArray = { "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書", "6月暢銷書", "14", "" };
            _robot.AssertDataGridViewRowDataBy("_inventoryDataView", 0, expectedStringArray);
        }

        // TestMethod
        [TestMethod()]
        public void TestSupplyConfirmButton()
        {
            _robot.ClickDataGridViewCellBy("_inventoryDataView", 3, "補貨");
            _robot.SwitchTo("SupplyForm");
            _robot.ClickElementByName("_supplyBookAmountTextBox");
            _robot.SendKey("3");
            _robot.ClickElementByText("確認");
            _robot.SwitchTo("BookInventoryForm");
            string[] expectedStringArray = { "零零落落", "6月暢銷書", "6", "" };
            _robot.AssertDataGridViewRowDataBy("_inventoryDataView", 3, expectedStringArray);
        }

        // TestMethod
        [TestMethod()]
        public void TestSupplyCancelButton()
        {
            _robot.ClickDataGridViewCellBy("_inventoryDataView", 0, "補貨");
            _robot.SwitchTo("SupplyForm");
            _robot.AssertEnableByText("取消", true);
            _robot.ClickElementByText("取消");
        }
    }
}
