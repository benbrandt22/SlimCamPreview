using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace SlimCamPreview
{
    class Program : WindowsFormsApplicationBase
    {
        // REF: http://www.codeproject.com/Articles/12890/Single-Instance-C-Application-for-NET

        public Program() {
            this.EnableVisualStyles = true;
            this.IsSingleInstance = true;
            this.MainForm = new Form1();
            this.StartupNextInstance += new StartupNextInstanceEventHandler(this.OnStartupNextInstance);
        }

        protected void OnStartupNextInstance(object sender, StartupNextInstanceEventArgs eventArgs) {
            eventArgs.BringToForeground = true;
        }
        
        [STAThread]
        public static void Main(string[] args) {
            var program = new Program();
            program.Run(args);
        }

    }
}
