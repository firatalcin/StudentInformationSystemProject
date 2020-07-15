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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        private void Form18_Load(object sender, EventArgs e)
        {         
            baglanti.Open();
                      
            SqlCommand cmd = new SqlCommand("select * from AddCourse", baglanti); // Ders isimlerini yazdırdık
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["CourseName"]);
            }
            baglanti.Close();

            // Skor tablosunu gösterdik

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddScore.Ogrenci_ID , AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not FROM AddOgr, AddScore where AddOgr.ID = AddScore.Ogrenci_ID", baglanti);
            DataTable ds = new DataTable();
            baglanti.Open();
            da1.Fill(ds);
            baglanti.Close();
            dataGridView1.DataSource = ds;

           // Öğrenci tablosunu gösterdik       
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT  AddOgr.ID , AddOgr.FirstName, AddOgr.LastName FROM AddOgr", baglanti);            
            DataTable dt = new DataTable();
            baglanti.Open();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e) // Skor listesine geri döndük
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddScore.Ogrenci_ID , AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not FROM AddOgr, AddScore where AddOgr.ID = AddScore.Ogrenci_ID", baglanti);
            DataTable ds = new DataTable();
            baglanti.Open();
            da1.Fill(ds);
            baglanti.Close();
            dataGridView1.DataSource = ds;
        }

        private void button1_Click(object sender, EventArgs e) // Verileri yazdırdık
        {
            TextWriter yaz = new StreamWriter(@"C:\Users\firatalcin\Desktop\SkorCikti.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // dersi alan öğrencileri gösteriyor
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddScore.Ogrenci_ID , AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not from AddOgr, AddScore where  AddOgr.ID = AddScore.Ogrenci_ID AND Ogrenci_Ders like '%" + listBox1.SelectedItem + "%'", baglanti);
            da.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }
        int rowindex;
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) // Çalışmadı
        {
            rowindex = e.RowIndex;

            baglanti.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddScore.Ogrenci_ID , AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not from AddOgr, AddScore where  AddOgr.ID = AddScore.Ogrenci_ID AND ID like '%" + dataGridView1.Rows[rowindex].Cells[0].Value + "%'", baglanti);
            da.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
