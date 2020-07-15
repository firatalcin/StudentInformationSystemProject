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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        SqlConnection baglanti5 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");


        private void Form11_Load(object sender, EventArgs e)
        {
           
            SqlCommand komut = new SqlCommand("SELECT * FROM AddCourse");            
            komut.Connection = baglanti5;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti5.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CourseName"]);
            }
            baglanti5.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Kurs tablosunda ki bilgileri güncelledik
        {
            SqlCommand guncelleKomutu = new SqlCommand("UPDATE AddCourse SET  CourseName=@CourseName, CourseHour=@CourseHour, Description=@Description WHERE CourseName=@CourseName", baglanti5);
            guncelleKomutu.Parameters.AddWithValue("@CourseName", textBox1.Text);
            guncelleKomutu.Parameters.AddWithValue("@Description", textBox3.Text);
            guncelleKomutu.Parameters.AddWithValue("@CourseHour", numericUpDown1.Value);

            baglanti5.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Course Name");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter Description");
            }
            else if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Please increase your course time ");
            }        
            else
            {
                guncelleKomutu.ExecuteNonQuery();
                MessageBox.Show("Bilgiler Başarıyla güncellenmiştir");
            }
            
            baglanti5.Close();

            
        }
    }
}
