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
    public partial class Form4 : Form
    {

        string imgLoc = "";       
        public Form4()
        {        
        InitializeComponent();        
        }
        static public string isim;

        SqlConnection baglanti4 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");
        DataTable dt = new DataTable();
        
        private void button2_Click(object sender, EventArgs e)
        {

            baglanti4.Open();
            // Upload ettiğimiz resmi sql veri olarak kaydetmemizi sağladık
            byte[] images = null;
            FileStream stream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);


            // Öğrenci bilgilerini güncelledik
            SqlCommand guncelleKomutu = new SqlCommand("UPDATE AddOgr SET  FirstName=@FirstName, LastName=@LastName, BirthDate=@BirthDate, Gender=@Gender, Phone=@Phone, Address=@Address, Picture=@Picture WHERE ID=@ID", baglanti4);
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
                guncelleKomutu.ExecuteNonQuery();
                MessageBox.Show("Bilgiler Başarıyla güncellenmiştir");
            }
            baglanti4.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            baglanti4.Open();


            //Öğrenci ID'yi referans alarak Öğrenci kaydını sildik          
            SqlCommand silKomutu = new SqlCommand("DELETE FROM AddOgr WHERE ID=@ID", baglanti4);
            silKomutu.Parameters.AddWithValue("@ID", textBox3.Text);
         
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter ID");
            }
            else if ("@ID" != null)
            {
                silKomutu.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi...");
            }
            
            baglanti4.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sistemden resim upload ettik
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "png files(*.png)|*png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                imgLoc = file.FileName.ToString();
                pictureBox1.ImageLocation = imgLoc;
            }
        }

        public void button4_Click(object sender, EventArgs e) // ID'yi referans alarak öğrencinin diğer bilgilerini çekiyoruz
        {
            Boolean flag = true;
            formClear();
            refreshDataT();      
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString() == textBox3.Text)
                {
                    textBox1.Text = dr[1].ToString();
                    textBox2.Text = dr[2].ToString();
                    dateTimePicker1.Text = dr[3].ToString();
                    if (radioButton1.Text == dr[4].ToString().Trim())
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                    textBox4.Text = dr[5].ToString();
                    textBox5.Text = dr[6].ToString();
                    pictureBox1.Image = byteArrayToImage((byte[])dr[7]);
                    flag = false;
                }
            }
            if (flag)
            {
                MessageBox.Show("Not Found!");
                textBox3.Clear();
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn) // resmi forma çekmek için kullandık
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void formClear() // Formu boşalttık
        {
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox4.Clear();
            textBox5.Clear();
            pictureBox1.Image = null;
        }

        private void refreshDataT() // DataTable güncelledik
        {
            dt.Clear();
            baglanti4.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM AddOgr", baglanti4);//database e veriler çekiliyor.
            da.Fill(dt);
            baglanti4.Close();
        }
    }


}


