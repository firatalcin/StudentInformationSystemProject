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
    public partial class Form3 : Form     
    {

        SqlConnection baglantı1 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        string imgLoc = "";

        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // Bilgisayardan resim upload u için kullandık
        {
            openFileDialog1.Filter = "png files(*.png)|*png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgLoc = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = imgLoc;
            }
        }

        

        

        private void button1_Click(object sender, EventArgs e) // Cancel butonu ile formu kapatıyoruz
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı1.Open();
            // Upload ettiğimiz resmi sql server'a veri olarak alıyoruz
            byte[] images = null;
            FileStream stream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);


            // Öğrenci ekliyoruz
            SqlCommand komut = new SqlCommand("insert into AddOgr(FirstName,LastName,BirthDate,Gender,Phone,Address,Picture) values (@FirstName,@LastName,@BirthDate,@Gender,@Phone,@Address,@Picture)", baglantı1);
            
            komut.Parameters.AddWithValue("@FirstName", textBox1.Text);
            komut.Parameters.AddWithValue("@LastName", textBox2.Text);
            komut.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value.ToString("dd - MM - yyyy "));
            string gender = "";
            if(radioButton1.Checked)
                 gender = "Male";
            else if (radioButton2.Checked)
                gender = "Female";
            komut.Parameters.AddWithValue("@Gender", gender);

            komut.Parameters.AddWithValue("@Phone", textBox4.Text);
            komut.Parameters.AddWithValue("@Address", textBox5.Text);         
            komut.Parameters.AddWithValue("@Picture", images);

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter first name!!");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Please enter last name!!");
            }            
            else if (gender == "")
            {
                MessageBox.Show("Please enter gender!!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter phone!!");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please enter address!!");
            }
            else if (images == null)
            {
                MessageBox.Show("Please enter picture!!");
            }
            else
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("New Student Added");
            }           
                baglantı1.Close();
        }
    }
}
