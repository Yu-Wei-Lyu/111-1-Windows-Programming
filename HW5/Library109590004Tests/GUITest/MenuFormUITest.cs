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
        public void TestBorrowAndReturnBookOf1()
        {
            // 開啟借書視窗
            _robot.ClickButtonByText("Book Borrowing System"); 
            _robot.SwitchTo("BookBorrowingForm");
            // 選擇一本書加到借書單中
            _robot.ClickButtonByName("Book 2");
            _robot.ClickButtonByText("加入借書單");
            // Assert 加入借書單按鈕 Enable 為 false
            _robot.AssertEnable("加入借書單", false);
            // 借書單中調整該書籍數量超過 2
            _robot.EditDataGridViewCellBy("_borrowingDataView", 0, "數量");
            _robot.SendKey("left 3");
            // Assert MessageBox 顯示訊息同本書一次限借2本
            _robot.AssertMessageBoxText("同本書一次限借2本");
            // 按下確定後調整為合法的書籍數量
            _robot.CloseMessageBox();
            string[] expectedStringArray = { "", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "2", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" }; 
            _robot.AssertDataGridViewRowDataBy("_borrowingDataView", 0, expectedStringArray);
            // 按下確認借書按鈕
            _robot.ClickButtonByText("確認借書"); 
            // Assert MessageBox 顯示該書籍成功借閱。
            _robot.AssertMessageBoxText("【暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫】2本\r\n\r\n已成功借出！");
            _robot.CloseMessageBox();
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowAndReturnBookOf2()
        {
            // 同時開啟借書視窗及背包視窗
            _robot.ClickButtonByText("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickButtonByText("查看我的背包");
            _robot.SwitchTo("BackPackForm");
            _robot.SwitchTo("BookBorrowingForm");
            // 選擇一本書並成功借書
            _robot.ClickButtonByName("Book 1");
            _robot.AssertText("_bookRemainLabel", "剩餘數量：1");
            _robot.ClickButtonByText("加入借書單");
            _robot.ClickButtonByText("確認借書");
            _robot.CloseMessageBox();
            // 在借書視窗中，點擊剛剛借的書
            _robot.ClickButtonByName("Book 1");
            // Assert 書籍資訊欄位裡的書籍剩餘數量有減少
            _robot.AssertText("_bookRemainLabel", "剩餘數量：0");
            // 我的背包中有新增剛剛借的書
            _robot.SwitchTo("BackPackForm");
            string[] expectedStringArray = { "歸還", "1", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", string.Format("{0:yyyy/MM/dd}", DateTime.Now), string.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(30)), "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" };
            _robot.AssertDataGridViewRowDataBy("_backPackDataView", 0, expectedStringArray);
            // 並將書本歸還
            _robot.ClickDataGridViewCellBy("_backPackDataView", 0, "還書");
            _robot.CloseMessageBox();
            // Assert 背包視窗該本書有刪除
            _robot.AssertDataGridViewRowCountBy("_backPackDataView", 0);
            // 借書視窗中該本書的剩餘數量有恢復
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickButtonByName("Book 1");
            _robot.AssertText("_bookRemainLabel", "剩餘數量：1");
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowAndReturnBookOf3()
        {
            // 同時開啟借書視窗、庫存管理視窗及背包視窗
            _robot.ClickButtonByText("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.SwitchTo("MenuForm");
            _robot.ClickButtonByText("Book Inventory System");
            _robot.SwitchTo("BookInventoryForm");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickButtonByText("查看我的背包");
            _robot.SwitchTo("BackPackForm");
            // 借書視窗選擇一本書並成功借書
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickTabControl("英文學習");
            _robot.ClickButtonByText("下一頁");
            _robot.ClickButtonByName("Book 14");
            _robot.ClickButtonByText("加入借書單");
            _robot.EditDataGridViewCellBy("_borrowingDataView", 0, "數量");
            _robot.SendKey("left 2");
            _robot.ClickButtonByText("確認借書");
            _robot.CloseMessageBox();
            // Assert 庫存管理視窗該本書的庫存數量有減少
            _robot.SwitchTo("BookInventoryForm");
            string[] expectedStringArray = { "全民英檢中級900核心單字", "英文學習", "0", "" };
            _robot.AssertDataGridViewRowDataBy("_inventoryDataView", 14, expectedStringArray);
            // 背包視窗還書後
            _robot.SwitchTo("BackPackForm");
            _robot.ClickDataGridViewCellBy("_backPackDataView", 0, "還書");
            _robot.CloseMessageBox();
            // Assert 庫存管理視窗該本書的庫存數量有增加
            _robot.SwitchTo("BookInventoryForm");
            string[] expectedStringArray2 = { "全民英檢中級900核心單字", "英文學習", "1", "" };
            _robot.AssertDataGridViewRowDataBy("_inventoryDataView", 14, expectedStringArray2);
        }
        /*點選任一書籍，Assert 右側有顯示正確的書籍資訊，按下補
        貨按鈕，Assert 補貨單有正確的書籍資訊，按下補貨單取消按鈕，Assert 該書籍
        的庫存數量維持不變。*/

        // TestMethod
        [TestMethod()]
        public void TestSupplyBookOf1()
        {
            // 開啟庫存管理視窗
            _robot.ClickButtonByText("Book Inventory System");
            _robot.SwitchTo("BookInventoryForm");
            // 點選任一書籍
            _robot.ClickDataGridViewCellBy("_inventoryDataView", 0, "書籍名稱");
            // Assert 右側有顯示正確的書籍資訊
            string exceptedString = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r編號：964 8394:2-5 2021\r作者：ingectar-e\r出版項：原點出版 : 大雁發行, 2021[民110]";
            _robot.AssertText("_bookDetailTextBox", exceptedString);
        }
    }
}
