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
    public class BorrowingFormGUIUnitTest
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
            _robot.ClickElementByText("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // TestMethod
        [TestMethod()]
        public void TestBookCategoryTabControl()
        {
            _robot.ClickTabControl("4月暢銷書");
            _robot.AssertText("_bookDetailTextBox", "");
            _robot.ClickElementByName("Book 4");
            string book4Detail = "煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊\r編號：177.3 8333:3 2022\r作者：艾米.馬洛-麥柯\r出版項：麥田出版 : 家庭傳媒城邦分公司發行, 2022[民111]";
            _robot.AssertText("_bookDetailTextBox", book4Detail);
        }

        // TestMethod
        [TestMethod()]
        public void TestBookDetialTextBox()
        {
            _robot.ClickElementByName("Book 0");
            string book0Detail = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r編號：964 8394:2-5 2021\r作者：ingectar-e\r出版項：原點出版 : 大雁發行, 2021[民110]";
            _robot.AssertText("_bookDetailTextBox", book0Detail);
        }

        // TestMethod
        [TestMethod()]
        public void TestBookRemainLabel()
        {
            _robot.ClickElementByName("Book 1");
            _robot.AssertText("_bookRemainLabel", "剩餘數量：1");
        }

        // TestMethod
        [TestMethod()]
        public void TestPageLabel()
        {
            _robot.AssertText("_pageLabel", "Page：1 / 2");
            _robot.ClickElementByText("下一頁");
            _robot.AssertText("_pageLabel", "Page：2 / 2");
        }

        // TestMethod
        [TestMethod()]
        public void TestPageUpButton()
        {
            _robot.AssertEnableByText("上一頁", false);
            _robot.ClickElementByText("下一頁");
            _robot.AssertEnableByText("上一頁", true);
        }

        // TestMethod
        [TestMethod()]
        public void TestPageDownButton()
        {
            _robot.AssertEnableByText("下一頁", true);
            _robot.ClickElementByText("下一頁");
            _robot.AssertEnableByText("下一頁", false);
        }

        // TestMethod
        [TestMethod()]
        public void TestAddListButton()
        {
            _robot.AssertEnableByText("加入借書單", false);
            _robot.ClickElementByName("Book 2");
            _robot.AssertEnableByText("加入借書單", true);
            _robot.ClickElementByText("加入借書單");
            _robot.AssertEnableByText("加入借書單", false);
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingCountLabel()
        {
            _robot.AssertText("_borrowingCountLabel", "借書數量：0");
            _robot.ClickElementByName("Book 1");
            _robot.ClickElementByText("加入借書單");
            _robot.AssertText("_borrowingCountLabel", "借書數量：1");
            _robot.ClickElementByName("Book 2");
            _robot.ClickElementByText("加入借書單");
            _robot.AssertText("_borrowingCountLabel", "借書數量：2");
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingButton()
        {
            _robot.AssertEnableByText("確認借書", false);
            _robot.ClickElementByName("Book 0");
            _robot.ClickElementByText("加入借書單");
            _robot.AssertEnableByText("確認借書", true);
            _robot.ClickElementByText("確認借書");
            _robot.CloseMessageBox();
            _robot.AssertEnableByText("確認借書", false);
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingDataView()
        {
            _robot.AssertDataGridViewRowCountBy("_borrowingDataView", 0);
            _robot.ClickElementByName("Book 2");
            _robot.ClickElementByText("加入借書單");
            _robot.AssertDataGridViewRowCountBy("_borrowingDataView", 1);
            string[] expectedStringArray = { "", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" };
            _robot.AssertDataGridViewRowDataBy("_borrowingDataView", 0, expectedStringArray);
            _robot.ClickDataGridViewCellBy("_borrowingDataView", 0, "刪除");
            _robot.AssertDataGridViewRowCountBy("_borrowingDataView", 0);
        }

        // TestMethod
        [TestMethod()]
        public void TestOpenBackPackButton()
        {
            _robot.AssertEnableByText("查看我的背包", true);
            _robot.ClickElementByText("查看我的背包");
            _robot.SwitchTo("BackPackForm");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.AssertEnableByText("查看我的背包", false);
            _robot.SwitchTo("BackPackForm");
            _robot.CloseWindow();
            _robot.SwitchTo("BookBorrowingForm");
            _robot.AssertEnableByText("查看我的背包", true);

        }
    }
}
