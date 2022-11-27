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
    public class BackPackFormGUIUnitTest
    {
        private Robot _robot;

        // init
        [TestInitialize()]
        public void Initialize()
        {
            _robot = new Robot();
            _robot.ClickElementByText("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickElementByText("查看我的背包");
            _robot.SwitchTo("BackPackForm");
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // TestMethod
        [TestMethod()]
        public void TestBackPackDataView()
        {
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickElementByName("Book 1");
            _robot.ClickElementByText("加入借書單");
            _robot.ClickElementByText("確認借書");
            _robot.CloseMessageBox();
            _robot.SwitchTo("BackPackForm");
            string[] expectedStringArray = { "歸還", "1", "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡", "1", string.Format("{0:yyyy/MM/dd}", DateTime.Now), string.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(30)), "176.51 8564 2022", "羅瑞塔.葛蕾吉亞諾.布魯", "閱樂國際文化出版" };
            _robot.AssertDataGridViewRowDataBy("_backPackDataView", 0, expectedStringArray);
            _robot.ClickDataGridViewCellBy("_backPackDataView", 0, "還書");
            _robot.CloseMessageBox();
            _robot.AssertDataGridViewRowCountBy("_backPackDataView", 0);
        }
    }
}
