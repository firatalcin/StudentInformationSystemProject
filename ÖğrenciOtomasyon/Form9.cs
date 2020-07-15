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
    public partial class Form9 : Form
    {

        SqlConnection baglantı1 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Kurs tablosuna ders ekliyoruz

        {
            SqlCommand komut = new SqlCommand("insert into AddCourse(CourseName,CourseHour,Description) values (@CourseName,@CourseHour,@Description)", baglantı1);
            baglantı1.Open();

            komut.Parameters.AddWithValue("@CourseName", textBox1.Text);
            komut.Parameters.AddWithValue("@Description", textBox3.Text);
            komut.Parameters.AddWithValue("@CourseHour", numericUpDown1.Value);

            if (textBox1.Text == "" )
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
                komut.ExecuteNonQuery();
                MessageBox.Show("New Course Added");
            }

            
            baglantı1.Close();

           
        }
    }
}
