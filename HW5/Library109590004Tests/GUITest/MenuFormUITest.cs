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
    public class MenuFormUITest
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
            while(Directory.GetParent(solutionPath).Name != projectFileName)
                solutionPath = Path.GetFullPath(Path.Combine(solutionPath, "..\\"));
            targetAppPath = Path.Combine(solutionPath, appPath);
            _robot = new Robot(targetAppPath, START_UP_FORM);
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // TestMethod
        [TestMethod()]
        public void TestMethod1()
        {
            _robot.ClickButtonByText("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickButtonByName("Book 2");
            _robot.ClickButtonByText("加入借書單");
            _robot.AssertEnable("加入借書單", false);
            _robot.EditDataGridViewCellBy("_borrowingDataView", 0, "數量");
            _robot.SendKey("left 3");
            _robot.AssertMessageBoxText("同本書一次限借2本");
            _robot.CloseMessageBox();
            _robot.ClickButtonByText("確認借書");
            _robot.AssertMessageBoxText("【暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫】2本\r\n\r\n已成功借出！");
            _robot.CloseMessageBox();
        }

        // TestMethod
        [TestMethod()]
        public void TestMethod2()
        {
            _robot.ClickButtonByText("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickButtonByText("查看我的背包");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickButtonByName("Book 1");
            _robot.AssertText("_bookRemainLabel", "剩餘數量：1");
            _robot.ClickButtonByText("加入借書單");
            _robot.ClickButtonByText("確認借書");
            _robot.CloseMessageBox();
            _robot.ClickButtonByName("Book 1");
            _robot.AssertText("_bookRemainLabel", "剩餘數量：0");
            _robot.SwitchTo("BackPackForm");
            string[] expectedStringArray = new string[] { "歸還", "1", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", string.Format("{0:yyyy/MM/dd}", DateTime.Now), string.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(30)), "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" };
            _robot.AssertDataGridViewRowDataBy("_backPackDataView", 0, expectedStringArray);
            //_robot.ClickDataGridViewCellBy("_backPackDataView", 0, "還書");
            //_robot.CloseMessageBox();
            //_robot.AssertDataGridViewRowCountBy("_backPackDataView", 0);
            ///_robot.CloseWindow();
            //_robot.SwitchTo("BookBorrowingForm");
            //_robot.ClickButtonByName("Book 1");
            //_robot.AssertText("_bookRemainLabel", "剩餘數量：1");
            //_robot.CloseMessageBox();
        }
    }
}
