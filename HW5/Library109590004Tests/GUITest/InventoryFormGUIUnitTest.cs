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
    public class InventoryFormGUIUnitTest
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
        public void TestInventoryDataView()
        {
            _robot.AssertDataGridViewRowCountBy("_inventoryDataView", 20);
            string[] expectedStringArray = { "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "6月暢銷書", "1", "" };
            _robot.AssertDataGridViewRowDataBy("_inventoryDataView", 1, expectedStringArray);
        }

        // TestMethod
        [TestMethod()]
        public void TestBookDetailTextBox()
        {
            _robot.ClickDataGridViewCellBy("_inventoryDataView", 1, "書籍名稱");
            _robot.AssertText("_bookDetailTextBox", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡\r編號：176.51 8564 2022\r作者：羅瑞塔.葛蕾吉亞諾.布魯\r出版項：閱樂國際文化出版");
        }
    }
}
