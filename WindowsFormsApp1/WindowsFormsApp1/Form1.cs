using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
      
        public OleDbCommand sorgu;
        public OleDbDataReader dr;
        public string tc;
        public string sf;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = pictureBox1.InitialImage;

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            con.Open();
            sorgu = new OleDbCommand("select TCKimlik , Sifre from Doktorlar where TCKimlik = @tc and Sifre = @sf  ", con);
            sorgu.Parameters.AddWithValue("@tc", textBox1.Text);
            sorgu.Parameters.AddWithValue("@sf", textBox2.Text);
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            if (dr.Read())
            {
                tc = textBox1.Text;
                sf = textBox2.Text;
                Form2 form = new Form2(this);
                form.Show();
                this.Hide();
                
              
            }

            else
            {
                con.Close();
                MessageBox.Show("Yanliş Tc Veya Şifre Lütfen Tekrar Deniyiniz");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
                textBox2.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            }
        }
    }

