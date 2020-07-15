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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        SqlConnection baglanti6 = new SqlConnection("Data Source=DESKTOP-VD0F5NI;Initial Catalog = Personel;Integrated Security = True");

        private void Form13_Load(object sender, EventArgs e) // Kurs u ekrana yazıyoruz
        {
            baglanti6.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from AddCourse", baglanti6);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti6.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Çıktı alıyoruz
        {
            TextWriter yaz = new StreamWriter(@"C:\Users\firatalcin\Documents\DersCikti.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                yaz.Write("  " + dataGridView1.Rows[i].Cells[0].Value.ToString() + "\t" + "|");
                yaz.Write("    " + dataGridView1.Rows[i].Cells[1].Value.ToString() + "       /t\t" + "|");
                yaz.Write("    " + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\t" + "|");
                yaz.Write("  " + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\t|");
                               
                yaz.WriteLine("");
                yaz.Write("-----------------------------------------------------------------------------------------------------------------------------------------------------");
                yaz.WriteLine("");
            }
            yaz.Close();
            MessageBox.Show("Data Exported");
        }
    }
}

