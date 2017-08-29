//ChatClient
//Ver 1.0

////////////////////////////////
///// @author: Deuse     //////
///// @date: 03.09.16   //////
///// @prname: client  //////
////////////////////////////


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ChatClient
{
    public partial class Form1 : Form
    {

        private static Socket Client;
        private IPAddress IP = null;
        private int Port = 0;
        private Thread thread;
        public Form1()
        {
            InitializeComponent();

            richTextBox1.Enabled = false;
            richTextBox2.Enabled = false;
            button3.Enabled = true;

            try
            {
                var streamReader = new StreamReader(@"Client_Info/data.txt");
                string Buffer = streamReader.ReadToEnd();
                streamReader.Close();
                string[] connect = Buffer.Split(':');

                IP = IPAddress.Parse(connect[0]);
                Port = int.Parse(connect[1]);

                label4.ForeColor = Color.Green;
                label4.Text = "Options: \n Server IP:" + connect[0] + "\n Server Port:" + connect[1];
            }

            catch (Exception ex)
            {
                label4.ForeColor = Color.Red;
                label4.Text = "Oops! Properties are not found!";

                Form2 Form = new Form2();
                Form.Show();
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Form = new Form2();
            Form.Show();
        }


        void SendMessage(string Message)
        {
            if (Message != "" && Message != "")
            {
                byte[] buffer = new byte[1024];
                buffer = Encoding.UTF8.GetBytes(Message);
                Client.Send(buffer);
            }
        }
        void ReceiveMessage()
        {
            byte[] buffer = new byte[1024];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = 0;
            }

            for (;;)
            {
                try
                {
                    Client.Receive(buffer);
                    string Message = Encoding.UTF8.GetString(buffer);
                    int count = Message.IndexOf(";;;5");

                    if (count == -1)
                    {
                        continue;
                    }

                    string clearMessage = "";

                    for (int i = 0; i < count; i++)
                    {
                        clearMessage += Message[i];
                    }

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = 0;
                    }

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        richTextBox1.AppendText(clearMessage);
                    });
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage("\n" + textBox1.Text + ":" + richTextBox2.Text + ";;;5");
            richTextBox2.Clear();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Deuse");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (thread != null) 
            thread.Abort();

            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "")
            {
                button3.Enabled = true;
                richTextBox2.Enabled = true;

                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (IP != null)
                {
                    Client.Connect(IP, Port);

                    thread = new Thread(delegate () { ReceiveMessage(); });
                    thread.Start();
                }
            }
        }
    }
}
