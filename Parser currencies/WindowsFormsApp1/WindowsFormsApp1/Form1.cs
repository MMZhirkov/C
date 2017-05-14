using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private string AksoBank()
        //{
        //    System.Net.WebClient wc = new System.Net.WebClient();
        //    String Response = wc.DownloadString("http://aksonbank.ru");
        //    String Rate = System.Text.RegularExpressions.Regex.Match(Response,@"id=""con0"" value=""([0-9]+\.[0-9]+)""").Groups[1].Value;
        //    return "Aksobank:" + Rate + " p. \r\n";
        //}
        //private string ForaBank()
        //{
        //    System.Net.WebClient wc = new System.Net.WebClient();
        //    String Response = wc.DownloadString("http://rnd.forabank.ru/private/rnd.cash");
        //    String Rate = System.Text.RegularExpressions.Regex.Match(Response, @"<p><strong><span style=""font-size: 12pt;"">([0-9]+\,[0-9]+)</span>").Groups[1].Value;
        //    return "ForaBank:" + Rate + " p. \r\n";
        //}
        private string RSBank()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            String Response = wc.DownloadString("http://rshb.ru/branches/saratov/");
            String Rate = System.Text.RegularExpressions.Regex.Match(Response, @"<td>([0-9]+\.[0-9]+)</td>").Groups[1].Value;
            return "RSBank:" + Rate + " p. \r\n";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text =  RSBank();
        }
    }
}
