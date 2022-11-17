using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Library109590004GUITests
{
    [TestClass()]
    public class UnitTest1
    {
        private string targetAppPath;
        private const string START_UP_FORM = "StartUpForm";

        // init
        [TestInitialize]
        public void Initialize()
        {
            var projectName = "CourseSystem";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "CourseSystem.exe");
            _robot = new Robot(targetAppPath, START_UP_FORM);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
