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
            string appName = $"{projectName}.exe";
            string projectFileName = "HW5";
            string solutionPath = AppDomain.CurrentDomain.BaseDirectory;
            while(Directory.GetParent(solutionPath).Name != projectFileName)
                solutionPath = Path.GetFullPath(Path.Combine(solutionPath, "..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", appName);
            _robot = new Robot(targetAppPath, START_UP_FORM);
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // RunScriptAdd
        private void RunScriptAdd()
        {
            _robot.ClickButton("Book Borrowing System");
            _robot.Sleep(1);
        }

        // TestMethod
        [TestMethod()]
        public void TestMethod1()
        {
            RunScriptAdd();
        }
    }
}
