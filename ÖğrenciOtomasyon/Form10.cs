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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        SqlConnection baglanti5 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        private void button1_Click(object sender, EventArgs e) //Kurs tablosundan ders siliyoruz

        {
            baglanti5.Open();

            SqlCommand silKomutu = new SqlCommand("DELETE FROM AddCourse WHERE ID=@ID", baglanti5);
            silKomutu.Parameters.AddWithValue("@ID", textBox1.Text);

            if ("@ID" != null)
            {
                silKomutu.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi...");
            }
            MessageBox.Show("Kayıt Bulunmuyor");
            baglanti5.Close();
        }
    }
}
