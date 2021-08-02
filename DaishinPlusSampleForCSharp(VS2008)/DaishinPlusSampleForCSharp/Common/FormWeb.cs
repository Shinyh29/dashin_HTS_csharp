using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaishinPlusSampleForCSharp.Common
{
    public partial class FormWeb : Form
    {
        public FormWeb()
        {
            InitializeComponent();
        }

        private void FormWeb_Load(object sender, EventArgs e)
        {

        }

        private void FormWeb_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ShowWeb(String title, String url)
        {
            this.Text = title;
            WebBrowser1.Navigate(url);
        }
    }
}
