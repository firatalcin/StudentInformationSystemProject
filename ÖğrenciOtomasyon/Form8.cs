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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private DataTable dt = new DataTable();
        SqlConnection baglanti6 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        private void Form8_Load(object sender, EventArgs e) // Öğrenci tablosunu gösterdik
        {
            radioButton1.Checked = true;           
            baglanti6.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from AddOgr", baglanti6);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti6.Close();
        }

        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
                      
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }



        private void button2_Click(object sender, EventArgs e) // Bilgileri yazdırdık
        {
            TextWriter yaz = new StreamWriter(@"C:\Users\firatalcin\Desktop\OgrenciCikti.txt");
            for (int i = 0; i < dataGridView1.Rows.Count -1 ; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    yaz.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                yaz.WriteLine("");
                yaz.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            }            
            yaz.Close();
            MessageBox.Show("Data Exported");
        }

        private void button1_Click(object sender, EventArgs e) // GO butonu ile aradıklarımızı filtreledik
        {
            if (radioButton2.Checked == true)
            {
                baglanti6.Open();

                SqlCommand komut = new SqlCommand("SELECT * from AddOgr where Gender = 'Male' ", baglanti6);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti6.Close();
            }

            if (radioButton1.Checked == true)
            {
                baglanti6.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from AddOgr", baglanti6);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti6.Close();
            }

            if (radioButton3.Checked == true)
            {
                SqlCommand komut = new SqlCommand("SELECT * from AddOgr where Gender = 'Female' ", baglanti6);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (radioButton5.Checked == true)
            {

                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;

                SqlCommand komut = new SqlCommand("select * from AddOgr where BirthDate between '" + dateTimePicker1.Value.ToString("dd - MM - yyyy ") + "' and '" + dateTimePicker2.Value.ToString("dd - MM - yyyy ") + "'", baglanti6);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;                
            }

            if (radioButton4.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            
            
        }


        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        





    }
}
