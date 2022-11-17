using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Library109590004
{
    [TestClass()]
    public class UnitTest1
    {
        private Robot _robot;
        private string targetAppPath;
        private const string START_UP_FORM = "MenuForm";

        // init
        [TestInitialize]
        public void Initialize()
        {
            var projectName = "Library109590004";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "Library109590004.exe");
            _robot = new Robot(targetAppPath, START_UP_FORM);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        private void RunScriptAdd()
        {
            _robot.ClickButton("_borrowingSystemButton");
        }


        [TestMethod]
        public void TestMethod1()
        {
            RunScriptAdd();
            _robot.AssertText("_borrowLabel", "借書單");
        }
    }
}
