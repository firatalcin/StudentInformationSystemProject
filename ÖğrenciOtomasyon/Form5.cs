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
using System.IO;

namespace ÖğrenciOtomasyon
{
    public partial class Form5 : Form
    {
        

        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglantı2 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglantı2.Open();
            
            //Öğrenci tablosunu gösteriyor
            SqlCommand komut = new SqlCommand("SELECT * from AddOgr", baglantı2);          
            SqlDataAdapter da = new SqlDataAdapter(komut);            
            DataTable dt = new DataTable();
            da.Fill(dt);           
            dataGridView1.DataSource = dt;
            
            baglantı2.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // dataGridView deki seçili satırdaki bilgileri delete formuna aktardık

            Form4 a = new Form4();
            baglantı2.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM AddOgr", baglantı2);//database e veriler çekiliyor.
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            baglantı2.Close();

            switch (e.ColumnIndex)
            {
                case 0:
                    a.textBox3.Select();
                    break;
                case 2:
                    a.textBox2.Select();
                    break;
                case 3:
                    a.dateTimePicker1.Select();
                    break;
                case 5:
                    a.textBox4.Select();
                    break;
                case 6:
                    a.textBox5.Select();
                    break;
            }

            a.textBox3.Text = dataTable.Rows[e.RowIndex][0].ToString();
            a.button4_Click(sender, e);
            a.ShowDialog();
        }
    }
}
