using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Library109590004
{

    public partial class Form1 : Form
    {
        private Library _library;
        
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Library library)
        {
            InitializeComponent();
            SetTabPageConstruct();
        }
        // set TabPage component
        private void SetTabPageConstruct() 
        {
            TabPage newTabPage = new TabPage();
            Button newButton = new Button();
        }
    }
}
