using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFormTests
{
    class FormUITest
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
                _robot.SwitchTo("DrawingForm");
            }

            // TestCleanup
            [TestCleanup()]
            public void Cleanup()
            {
                _robot.CleanUp();
            }
        }
    }
}
