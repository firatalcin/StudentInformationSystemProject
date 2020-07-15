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

namespace ÖğrenciOtomasyon
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        int rowindex;
        private void button1_Click(object sender, EventArgs e) // tablodan tıklayarak silme gerçekleştirdik
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE from AddScore WHERE Ogrenci_ID = @Ogrenci_ID AND Ogrenci_Ders = @Ogrenci_Ders", baglanti);
            baglanti.Open();
            sqlCommand.Parameters.AddWithValue("@Ogrenci_ID", dataGridView1.Rows[rowindex].Cells[0].Value);
            sqlCommand.Parameters.AddWithValue("@Ogrenci_Ders", dataGridView1.Rows[rowindex].Cells[4].Value);
            sqlCommand.ExecuteNonQuery();
            baglanti.Close();
            dataGridView1.Rows.RemoveAt(rowindex);
        }

        private void Form15_Load(object sender, EventArgs e) // Skor tablosunu gösterdik
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT AddOgr.ID , AddOgr.FirstName , AddOgr.LastName , AddScore.Ogrenci_ID , AddScore.Ogrenci_Ders , AddScore.Ogrenci_Not FROM AddOgr, AddScore where AddOgr.ID = AddScore.Ogrenci_ID", baglanti);
            DataTable ds = new DataTable();
            baglanti.Open();
            da1.Fill(ds);
            baglanti.Close();
            dataGridView1.DataSource = ds;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowindex = e.RowIndex;
        }
    }
}
