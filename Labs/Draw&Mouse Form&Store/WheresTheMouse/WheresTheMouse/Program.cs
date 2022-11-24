using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheresTheMouse
{
    static class Program
    {
        static void Main(string[] args)
        {
            Form form = new MouseForm();
            Application.Run(form);
        }
    }
}
