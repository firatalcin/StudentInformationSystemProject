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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        private void button1_Click(object sender, EventArgs e) // Skor ekledik
        {
            SqlCommand command = new SqlCommand("insert into AddScore (Ogrenci_ID,Ogrenci_Ders,Ogrenci_Not,Ogrenci_Hak) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);//database e veriler aktarılıyor.
            baglanti.Open();
            command.Parameters.AddWithValue("@Ogrenci_Ders", comboBox1.Text);
            command.Parameters.AddWithValue("@Ogrenci_ID", int.Parse(textBox1.Text));
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("New Score Added");

            textBox2.Clear();
            textBox1.Clear();
            comboBox1.Text = "";
            textBox3.Clear();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

            //Combobox a dersleri aktardık

            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM AddCourse", baglanti);//database e veriler çekiliyor. 
            baglanti.Open();
            da.Fill(dataTable);
            baglanti.Close();

            //SqlCommand komut = new SqlCommand("SELECT * FROM AddCourse");
            //komut.Connection = baglanti;
            //komut.CommandType = CommandType.Text;

            //SqlDataReader dr;
            //baglanti.Open();
            //dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox1.Items.Add(dr["CourseName"]);
            //}
            //baglanti.Close();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox1.Items.Add(dataTable.Rows[i][1]);
            }

            // dataGridView i doldurduk

            DataTable dataTable1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT ID , FirstName , LastName FROM AddOgr", baglanti);//database e veriler çekiliyor.
            baglanti.Open();
            da1.Fill(dataTable1);
            baglanti.Close();
            dataGridView1.DataSource = dataTable1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // event ile etkileşime geçtik
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
