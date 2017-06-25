using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }
        #region Load BD
        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\learn\xamarin test\XamarinTest\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM[Products]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while(await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Name"]) + "  " + Convert.ToString(sqlReader["Price"]));
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), Ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        #endregion
        #region Exit,Close
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        #endregion 
        #region Insert
        private async void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text)&& !string.IsNullOrWhiteSpace(textBox1.Text)&&
                !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                )
            {
                SqlCommand command = new SqlCommand("INSERT INTO[Products](Name,Price)VALUES(@Name,@Price)", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Price", textBox2.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Fields must be filled";
            }           
        }
        #endregion
        #region Update
        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM[Products]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Name"]) + "  " + Convert.ToString(sqlReader["Price"]));
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), Ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        #endregion
#region Change
        private async void button2_Click(object sender, EventArgs e)
        {

            if (label8.Visible)
                label8.Visible = false;

            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                 !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                 !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                 )
            {
                SqlCommand command = new SqlCommand("UPDATE [Products] SET[Name]=@Name,[Price]=@Price WHERE [Id]=@Id",sqlConnection);

                command.Parameters.AddWithValue("Id", textBox5.Text);
                command.Parameters.AddWithValue("Name", textBox4.Text);
                command.Parameters.AddWithValue("Price", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Fields must be filled";
            }
            
        }
        #endregion

        #region Delete
        private async void button3_Click(object sender, EventArgs e)
        {
            if (label9.Visible)
                label9.Visible = false;
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [id]=@Id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox6.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Fields must be filled";
            }
        }
        #endregion


    }
}
