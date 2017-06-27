using System;
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
        SqlConnection sqlConnection;//объявляем поле класса для доступа к его объекту в форме
        
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            //получаем физ расположение БД//
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
        private async void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)&&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Products]SET [Name]=@Name, [Price]=@Price WHERE [Id]=@Id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox6.Text);
                command.Parameters.AddWithValue("Name", textBox4.Text);
                command.Parameters.AddWithValue("Price", textBox5.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Все поля должны быть заполнены";
            }
        }
        //DELETE//
        private async void button3_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
                label10.Visible = false;
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [Id]=@Id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox9.Text);
               

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label10.Visible = true;
                label10.Text = "Все поля должны быть заполнены";
            }
        }
    }
}
