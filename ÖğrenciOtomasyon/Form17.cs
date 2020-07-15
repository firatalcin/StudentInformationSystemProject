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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        private void Form17_Load(object sender, EventArgs e) // Ders Adı ve Ortalama not döndürdük
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not FROM AddOgr,AddScore where AddOgr.ID = AddScore.Ogrenci_ID", baglanti);
            DataTable dt = new DataTable();
            baglanti.Open();
            da1.Fill(dt);
            baglanti.Close();

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT CourseName FROM AddCourse", baglanti);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            baglanti.Close();


            foreach (DataRow item in dataTable.Rows) // Ortalama notu yapan döngü
            {
                int averaj = 0;
                int temp = 0;
                Boolean veri = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (item[0].ToString().Trim() == dt.Rows[i][0].ToString().Trim())
                    {
                        veri = true;
                        averaj = averaj + int.Parse(dt.Rows[i][1].ToString());
                        temp++;
                    }
                }
                if (veri)
                    dataGridView1.Rows.Add(item[0], (float)averaj / temp + "");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

