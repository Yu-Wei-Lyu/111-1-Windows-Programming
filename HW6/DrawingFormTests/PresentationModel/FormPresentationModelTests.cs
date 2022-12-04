using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Moq;

namespace DrawingForm.Presentation.Tests
{
    [TestClass()]
    public class FormPresentationModelTests
    {
        DrawingModel.Model _model;
        PrivateObject _privateModel;
        FormPresentationModel _presentationModel;
        
        [TestInitialize()]
        public void Initialize()
        {
            _model = new DrawingModel.Model();
            _privateModel = new PrivateObject(_model);
            _presentationModel = new FormPresentationModel(_model);
        }

        [TestMethod()]
        public void TestDraw()
        {
            Graphics graphics = null;
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isPainting"));
            _presentationModel.Draw(graphics);
            Assert.AreEqual(true, _privateModel.GetFieldOrProperty("_isPainting"));
        }
    }
}