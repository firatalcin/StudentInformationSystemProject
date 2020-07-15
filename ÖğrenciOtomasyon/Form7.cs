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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        string imgLoc = "";

        SqlConnection baglanti5 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        double kayitSayisi = 0;       
        public void Form7_Load(object sender, EventArgs e)
        {
            // Öğrenci sayısını aldık

            SqlCommand komut = new SqlCommand("select count(*) from AddOgr", baglanti5); 
            baglanti5.Open();
            kayitSayisi = Convert.ToInt32(komut.ExecuteScalar());
            label10.Text = (kayitSayisi.ToString());
            baglanti5.Close();

            //Öğrenci tablosunu çektik

            baglanti5.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from AddOgr", baglanti5);            
            da.Fill(dt);           
            dataGridView1.DataSource = dt;                       
            baglanti5.Close();                       
        }

        private void button2_Click(object sender, EventArgs e) // Öğrenci ekliyoruz
        {


            baglanti5.Open();
            byte[] images = null;
            FileStream stream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            SqlCommand komut = new SqlCommand("insert into AddOgr(FirstName,LastName,BirthDate,Gender,Phone,Address,Picture) values (@FirstName,@LastName,@BirthDate,@Gender,@Phone,@Address,@Picture)", baglanti5);
            komut.Parameters.AddWithValue("@FirstName", textBox1.Text);
            komut.Parameters.AddWithValue("@LastName", textBox2.Text);
            komut.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value.ToString("dd - MM - yyyy "));
            string gender = "";
            if (radioButton1.Checked)
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
            else if (textBox2.Text == "")
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
            baglanti5.Close();
                       
            kayitSayisi += 1;
            label10.Text = (kayitSayisi.ToString());
            baglanti5.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from AddOgr", baglanti5);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti5.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Upload butonu
        {
            openFileDialog1.Filter = "png files(*.png)|*png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgLoc = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = imgLoc;
            }
        }



        private void button4_Click(object sender, EventArgs e) //Güncelleme butonu
        {
            byte[] images = null;
            FileStream stream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            SqlCommand guncelleKomutu = new SqlCommand("UPDATE AddOgr SET  FirstName=@FirstName, LastName=@LastName, BirthDate=@BirthDate, Gender=@Gender, Phone=@Phone, Address=@Address, Picture=@Picture WHERE ID=@ID", baglanti5);
            guncelleKomutu.Parameters.AddWithValue("@ID", textBox3.Text);
            guncelleKomutu.Parameters.AddWithValue("@FirstName", textBox1.Text);
            guncelleKomutu.Parameters.AddWithValue("@LastName", textBox2.Text);
            guncelleKomutu.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value.ToString("dd - MM - yyyy "));
            string gender = "";
            if (radioButton1.Checked)
                gender = "Male";
            else if (radioButton2.Checked)
                gender = "Female";
            guncelleKomutu.Parameters.AddWithValue("@Gender", gender);
            guncelleKomutu.Parameters.AddWithValue("@Phone", textBox4.Text);
            guncelleKomutu.Parameters.AddWithValue("@Address", textBox5.Text);
            guncelleKomutu.Parameters.AddWithValue("@Picture", images);
            baglanti5.Open();
            guncelleKomutu.ExecuteNonQuery();
            baglanti5.Close();

            MessageBox.Show("Bilgiler Başarıyla güncellenmiştir");
        }

        private void button5_Click(object sender, EventArgs e) //ID yi referans alarak sildik
        {
            baglanti5.Open();
            SqlCommand silKomutu = new SqlCommand("DELETE FROM AddOgr WHERE ID=@ID", baglanti5);
            silKomutu.Parameters.AddWithValue("@ID", textBox3.Text);

            if ("@ID" != null)
            {
                silKomutu.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi...");
            }
            MessageBox.Show("Kayıt Bulunmuyor");
            baglanti5.Close();            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e) //search butonu
        {
            baglanti5.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from AddOgr where FirstName like '%" + textBox6.Text + "%' OR LastName like '%" + textBox6.Text + "%'", baglanti5);            
            da.Fill(dt);
            dataGridView1.DataSource = dt;         
            baglanti5.Close();
        }

        private void button6_Click(object sender, EventArgs e) // Reset butonu
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            dateTimePicker1.ResetText();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox1.Image = null;           
        }
    }
}
