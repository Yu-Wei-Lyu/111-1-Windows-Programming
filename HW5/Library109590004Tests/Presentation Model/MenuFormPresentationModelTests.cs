using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library109590004;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004.Tests
{
    [TestClass()]
    public class MenuFormPresentationModelTests
    {
        MenuFormPresentationModel _presentationModel;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _presentationModel = new MenuFormPresentationModel();
        }

        // TestMethod
        [TestMethod()]
        public void TestMenuFormPresentationModel()
        {
            // this class didn't have any property or method to test (empty class)
        }
    }
}