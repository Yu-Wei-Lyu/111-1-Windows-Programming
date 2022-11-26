﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Library109590004Tests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("appWorkingDir", Directory.GetParent(targetAppPath).FullName);

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickElementByText(string text)
        {
            _driver.FindElementByName(text).Click();
        }

        // test
        public void ClickElementByName(string name)
        {
            _driver.FindElementByAccessibilityId(name).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void ClickComboBoxItem(string name, int itemIndex)
        {
            _driver.FindElementByAccessibilityId(name).Click();
            for (int i = 0; i <= itemIndex; i++)
            {
                SendKeys.SendWait("{DOWN}");
            }
            SendKeys.SendWait("{ENTER}");
        }
        
        /// <summary>
        /// 以元件中心為基準，拖曳滑鼠並放開
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="name"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DragAndDrop(string name, int x1, int y1, int x2, int y2)
        {
            Actions action = new Actions(_driver);
            var element = _driver.FindElementByName(name);
            Point center = new Point(element.Size.Width / 2, element.Size.Height / 2);
            action.MoveToElement(element).Perform();
            action.MoveByOffset(x1 - (int)center.X, y1 - (int)center.Y).ClickAndHold().Perform();
            action.MoveByOffset(x2 - x1, y2 - y1).Release().Perform();
        }

        // test
        public void ClearTextBoxText(string name)
        {
            _driver.FindElementByAccessibilityId(name).Clear();
        }

        // test
        public void SendKey(string key)
        {
            SendKeys.SendWait(key);
        }
        
        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            string targetName = columnName + " 資料列 " + rowIndex;
            _driver.FindElementByName(targetName).Click();
        }

        // test
        public void ClickListBoxItemBy(string itemText)
        {
            var element = _driver.FindElementByName(itemText);
            if ("ControlType.ListItem" == element.TagName)
                element.Click();
        }

        // test
        public void AssertListBoxItemNameBy(string itemText, string expectedText)
        {
            var element = _driver.FindElementByName(itemText);
            if ("ControlType.ListItem" == element.TagName)
                Assert.AreEqual(element.Text, expectedText);
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertMessageBoxText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertMessageBoxText(string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId("65535");
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            string targetName = "資料列 " + rowIndex;
            var rowDatas = dataGridView.FindElementByName(targetName).FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
    }
}
