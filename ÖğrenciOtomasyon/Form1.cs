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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog=Personel;Integrated Security=True");
        Form2 gecis2 = new Form2();

        private void button1_Click(object sender, EventArgs e) // Cancel butonuyla sistemden çıkıyoruz
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // Giriş butonuyla server daki bilgilerle eşleştiriyoruz
        {
            
                baglantı.Open();                                         
                SqlCommand komut = new SqlCommand("select * from Personeller where KullanıcıAdı='" + textBox1.Text.Trim() + "' and Parola=  '" + textBox2.Text.Trim() + "' ", baglantı);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    gecis2.Show();
                                
                }
                else
                   MessageBox.Show("KullanıcıAdı veya Şifre yanlış");
                baglantı.Close();

           


        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
