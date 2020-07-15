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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();

            
        }

        SqlConnection baglanti5 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");


        private void button5_Click(object sender, EventArgs e) // Kurs a ders ekliyoruz
        {
            SqlCommand komut = new SqlCommand("insert into AddCourse(CourseName,CourseHour,Description) values (@CourseName,@CourseHour,@Description)", baglanti5);
            baglanti5.Open();
            komut.Parameters.AddWithValue("@CourseName", textBox1.Text);
            komut.Parameters.AddWithValue("@Description", textBox3.Text);
            komut.Parameters.AddWithValue("@CourseHour", numericUpDown1.Value);
            komut.ExecuteNonQuery();
            baglanti5.Close();

            MessageBox.Show("New Course Added");

            kayitSayisi += 1;
            label6.Text = (kayitSayisi.ToString());
            listBox1.Items.Add(textBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e) // Bilgileri güncelledik
        {
            SqlCommand guncelleKomutu = new SqlCommand("UPDATE AddCourse SET  CourseName=@CourseName, CourseHour=@CourseHour, Description=@Description WHERE ID=@ID", baglanti5);
            guncelleKomutu.Parameters.AddWithValue("@ID", textBox2.Text);
            guncelleKomutu.Parameters.AddWithValue("@CourseName", textBox1.Text);
            guncelleKomutu.Parameters.AddWithValue("@Description", textBox3.Text);
            guncelleKomutu.Parameters.AddWithValue("@CourseHour", numericUpDown1.Value);
            baglanti5.Open();           
            guncelleKomutu.ExecuteNonQuery();
            baglanti5.Close();

            MessageBox.Show("Bilgiler Başarıyla güncellenmiştir");
        }

        double kayitSayisi = 0;
        private void Form12_Load(object sender, EventArgs e)
        {
            // toplam ders sayısını buluyoruz

            SqlCommand komut = new SqlCommand("select count(*) from AddCourse", baglanti5);
            baglanti5.Open();
            kayitSayisi = Convert.ToInt32(komut.ExecuteScalar());
            label6.Text = (kayitSayisi.ToString());
            baglanti5.Close();
            
            //listbox a aktarıyoruz

            baglanti5.Open();
            SqlCommand cmd = new SqlCommand("select * from AddCourse", baglanti5);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["CourseName"]);              
            }
            baglanti5.Close();
        }

       
        private void button7_Click(object sender, EventArgs e) // Ders siliyoruz
        {
            baglanti5.Open();

            SqlCommand silKomutu = new SqlCommand("DELETE FROM AddCourse WHERE CourseName=@CourseName", baglanti5);
            silKomutu.Parameters.AddWithValue("@CourseName", textBox1.Text);

            if ("@CourseName" != null)
            {
                silKomutu.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi...");
            }
            baglanti5.Close();
            baglanti5.Open();

            listBox1.Items.Remove(listBox1.SelectedItem);         
            kayitSayisi -= 1;
            label6.Text = (kayitSayisi.ToString());
            baglanti5.Close();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            numericUpDown1.Value = 0;

        }

        private void button2_Click(object sender, EventArgs e) // listbox üzerinde hareket
        {
            if (listBox1.SelectedIndex > 0)
            {

                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;

            }
        }

        private void button3_Click(object sender, EventArgs e) // listbox üzerinde hareket
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AddCourse", baglanti5);

            //baglanti5.Open();
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            

            foreach (DataRow item in dataTable.Rows)
            {
                if (listBox1.Text == item[1].ToString())
                {
                    textBox2.Text = item[0].ToString();
                    textBox1.Text = item[1].ToString();
                    numericUpDown1.Value = int.Parse(item[2].ToString());
                    textBox3.Text = item[3].ToString();
                        
                }
            }
            baglanti5.Close();


            

        }
    }
}
