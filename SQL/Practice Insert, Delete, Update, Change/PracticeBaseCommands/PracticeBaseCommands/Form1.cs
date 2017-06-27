﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeBaseCommands
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;//объявляем поля класса для доступа к его объекту в форме
        
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            //получаем физ расположение нашей базы//
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\SQL\Practice Insert, Delete, Update, Change\PracticeBaseCommands\PracticeBaseCommands\DatabaseMagazine.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            //открываем соединение
            await sqlConnection.OpenAsync();

            //получаем содержимое, создавая команду
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM[Products]",sqlConnection);
            
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Name"]) + "  " + Convert.ToString(sqlReader["Price"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        //Отключаемся от БД//
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        // INSERT//
        private async void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text)&&!string.IsNullOrWhiteSpace(textBox1.Text)&&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Products](Name,Price)VALUES(@Name,@Price)", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Price", textBox2.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Все поля должны быть заполнены";
            }
        }
        //UPDATE//
        private async void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Products]",sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while(await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Name"]) + "  " + Convert.ToString(sqlReader["Price"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        //CHANGE//
        //DELETE//
    }
}
