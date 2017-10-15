using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FastReport;

namespace FastReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //connect DB
            string connString = @"Data Source=desktop-fj80pq6\sqlexpress; Integrated Security=SSPI; Initial Catalog=FastReport;";
            string sql = "select * from Table_1";
          
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                cnn.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                //dataGridView1.DataSource = ds.Tables[0];
                Report report = new Report();
                report.Load("report1.frx");
                report.RegisterData(ds, "NorthWind");
                // готовим отчет
                report1.Prepare();
                // создаем экземпляр экспорта в HTML
                report.Show();

            }



        }


        
    }
}
