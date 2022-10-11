﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library109590004
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new BookBorrowingForm(new BookBorrowingPresentationModel(new LibraryModel())));
            Application.Run(new MenuForm(new MenuFormPresentationModel(new LibraryModel())));
        }
    }
}
