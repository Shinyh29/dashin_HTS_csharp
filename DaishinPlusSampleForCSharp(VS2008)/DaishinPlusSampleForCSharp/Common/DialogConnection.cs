using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace DaishinPlusSampleForCSharp.Common
{
    public partial class DialogConnection : Form
    {
        private FormMain _main;

        public DialogConnection()
        {
            InitializeComponent();
        }

        public void SetParent(FormMain main)
        {
            _main = main;
        }

        private void ButtonCybos_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\daishin\\starter");
            string path = key.GetValue("path").ToString();
            if (path == "")
            {
                MessageBox.Show("사이보스 플러스가 설치되어있지 않습니다.");
            }
            else
            {
                Process.Start(path + "\\ncStarter.exe", "/prj:cp");
                _main.RequestConnection();
            }

            this.Close();
        }

        private void ButtonCreon_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Creon\\dstarter");
            string path = key.GetValue("path").ToString();
            if (path == "")
            {
                MessageBox.Show("크레온 플러스가 설치되어있지 않습니다.");
            }
            else
            {
                Process.Start(path + "\\coStarter.exe", "/prj:cp");
                _main.RequestConnection();
            }

            this.Close();
        }

        private void ButtonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
