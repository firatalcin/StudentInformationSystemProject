using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÖğrenciOtomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Form geçişleri yapılıyor

        Form3 gecis3 = new Form3();
        Form4 gecis4 = new Form4();
        Form5 gecis5 = new Form5();
        Form6 gecis6 = new Form6();
        Form7 gecis7 = new Form7();
        Form8 gecis8 = new Form8();
        Form9 gecis9 = new Form9();
        Form10 gecis10 = new Form10();
        Form11 gecis11 = new Form11();
        Form12 gecis12 = new Form12();
        Form13 gecis13 = new Form13();
        Form14 gecis14 = new Form14();
        Form15 gecis15 = new Form15();
        Form16 gecis16 = new Form16();
        Form17 gecis17 = new Form17();
        Form18 gecis18 = new Form18();

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis3.ShowDialog();
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis5.ShowDialog();
        }

        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis6.ShowDialog();
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis4.ShowDialog();
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis7.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis8.ShowDialog();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis9.ShowDialog();
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis10.ShowDialog();
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis11.ShowDialog();
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis12.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gecis13.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis14.ShowDialog();
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis15.ShowDialog();
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis16.ShowDialog();
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gecis17.ShowDialog();
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            gecis18.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
