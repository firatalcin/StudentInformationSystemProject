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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        Form17 average = new Form17();

        private void button1_Click(object sender, EventArgs e) // Kurs tablosuna ekleme yaptık
        {
            SqlCommand command = new SqlCommand("insert into AddScore (Ogrenci_ID,Ogrenci_Ders,Ogrenci_Not,Ogrenci_Hak) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);//database e veriler aktarılıyor.
            baglanti.Open();
            command.Parameters.AddWithValue("@OgrenciCourse", comboBox1.Text);
            command.Parameters.AddWithValue("@OgrenciId", int.Parse(textBox1.Text));
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("New Score Added");

            textBox2.Clear();
            textBox1.Clear();
            comboBox1.Text = "";
            textBox3.Clear();
        }
        int rowindex;
        private void button3_Click(object sender, EventArgs e) // Kurs tablosunda silme yaptık
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE from AddScore WHERE Ogrenci_ID = @Ogrenci_ID AND Ogrenci_Ders = @Ogrenci_Ders", baglanti);
            baglanti.Open();
            sqlCommand.Parameters.AddWithValue("@Ogrenci_ID", dataGridView1.Rows[rowindex].Cells[0].Value);
            sqlCommand.Parameters.AddWithValue("@Ogrenci_Ders", dataGridView1.Rows[rowindex].Cells[4].Value);
            sqlCommand.ExecuteNonQuery();
            baglanti.Close();
            dataGridView1.Rows.RemoveAt(rowindex);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowindex = e.RowIndex;
        }

        private void button2_Click(object sender, EventArgs e) // Form geçişi sağladık
        {
            average.Show();
        }

        private void Form16_Load(object sender, EventArgs e) // Kurs tablosunu gösterdik
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddScore.Ogrenci_ID , AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not FROM AddOgr, AddScore where AddOgr.ID = AddScore.Ogrenci_ID", baglanti); DataTable ds = new DataTable();
            baglanti.Open();
            da1.Fill(ds);
            baglanti.Close();
            dataGridView1.DataSource = ds;


            SqlCommand komut = new SqlCommand("SELECT * FROM AddCourse");
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CourseName"]);
            }
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e) // Öğrenci tablosunda bazı bilgileri çektik
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT  AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddOgr.BirthDate FROM AddOgr", baglanti);
            DataTable ds = new DataTable();
            baglanti.Open();
            da1.Fill(ds);
            baglanti.Close();
            dataGridView1.DataSource = ds;
        }

        private void button5_Click(object sender, EventArgs e) // Skor tablosuna geri döndük
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddScore.Ogrenci_ID , AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not FROM AddOgr, AddScore where AddOgr.ID = AddScore.Ogrenci_ID", baglanti); DataTable ds = new DataTable();
            baglanti.Open();
            da1.Fill(ds);
            baglanti.Close();
            dataGridView1.DataSource = ds;
        }
    }
}
