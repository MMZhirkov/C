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

namespace ChatClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "" && textBox1.Text != "" && textBox1.Text != "")
            {
                try
                {
                    DirectoryInfo Data = new DirectoryInfo("Client_info");
                    Data.Create();

                    var streamWriter = new StreamWriter(@"Client_info/data.txt");

                    streamWriter.WriteLine(textBox1.Text + ":" + textBox2.Text);
                    streamWriter.Close();

                    this.Hide();
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }
    }
}
