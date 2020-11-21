using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace UnblockOverwatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Timer timer;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Timer(3000);
            timer.AutoReset = true;
            timer.Elapsed += KillBlockOverwatch;
        }

        private void KillBlockOverwatch(object sender, System.Timers.ElapsedEventArgs e)
        {
            var p = Process.GetProcessesByName("blockOverwatch");
            if (p.Length >= 1)
            {
                p.FirstOrDefault().Kill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            this.Visible = false;

            this.ShowIcon = false;
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;

            this.ShowIcon = true;

            notifyIcon1.Visible = false;
            timer.Stop();
        }
    }
}
