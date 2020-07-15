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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection baglantı3 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void label4_Click(object sender, EventArgs e)
        {
          
        }

        
        private void label5_Click(object sender, EventArgs e)
        {
                
        }

        
        private void label6_Click(object sender, EventArgs e)
        {
          
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //Toplam öğrenci sayısını aldık

            double kayitSayisi = 0;
            SqlCommand komut = new SqlCommand("select count(*) from AddOgr", baglantı3);
            baglantı3.Open();
            kayitSayisi = Convert.ToInt32(komut.ExecuteScalar());
            label4.Text = (kayitSayisi.ToString());

            // Erkek öğrenci sayısını aldık

            double erkekSayisi = 0;
            double eYüzde = 0;
            SqlCommand komut1 = new SqlCommand("select count(*) from AddOgr WHERE Gender = 'Male'", baglantı3);           
            erkekSayisi = Convert.ToInt32(komut1.ExecuteScalar());
            eYüzde = (100.0 * (erkekSayisi / kayitSayisi));
            label5.Text = ("%" + eYüzde.ToString());

            // Kız öğrenci sayısını aldık

            double kadınSayisi = 0;
            double kYüzde = 0;
            SqlCommand komut2 = new SqlCommand("select count(*) from AddOgr WHERE Gender = 'Female'", baglantı3);          
            kadınSayisi = Convert.ToInt32(komut2.ExecuteScalar());
            kYüzde = (100.0 * (kadınSayisi / kayitSayisi));
            label6.Text = ("%" + kYüzde.ToString());


            baglantı3.Close();






        }
    }
}
