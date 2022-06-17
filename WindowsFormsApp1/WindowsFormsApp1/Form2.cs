using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Form1 form1;
        OleDbConnection bg = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
        public OleDbDataAdapter daDoktorlar;
        public OleDbDataAdapter Randevular;
        public DataSet dataset = new DataSet();
        public BindingSource bsDoktorlar;
        public BindingSource bsRandevular;
        public OleDbCommandBuilder bd;
        public OleDbCommandBuilder br;
        public OleDbCommand sorgu;
        public string b;
        public string s;

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            fotoğrafPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            button3.Visible = false;
            try
            {
                string a = form1.tc;
                string b = form1.sf;
                string k = "9274";
                string l = "27485483326";
                if (a ==l  && b ==k )
                {
                    button3.Visible =true;
                }
                else
                bg.Open();
                
                daDoktorlar = new OleDbDataAdapter($"select * from Doktorlar where TCKimlik = '{a}' ", bg);
                daDoktorlar.Fill(dataset, "Doktorlar");
                bsDoktorlar = new BindingSource(dataset, "Doktorlar");
                label8.DataBindings.Add("Text", bsDoktorlar, "TCKimlik", true);
                label9.DataBindings.Add("Text", bsDoktorlar, "Adi", true);
                label10.DataBindings.Add("Text", bsDoktorlar, "Soyadi", true);
                label11.DataBindings.Add("Text", bsDoktorlar, "Bransi", true);
                label13.DataBindings.Add("Text", bsDoktorlar, "Yas", true);
                label12.DataBindings.Add("Text", bsDoktorlar, "EMail", true);
                label14.DataBindings.Add("Text", bsDoktorlar, "Adres", true);
                fotoğrafPictureBox.DataBindings.Add("ImageLocation", bsDoktorlar, "Fotograf", true);
                if (fotoğrafPictureBox.Image == null)
                {
                    fotoğrafPictureBox.Image = fotoğrafPictureBox.InitialImage;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = label8.Text;
            Form3 fr = new Form3(this);
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fr = new Form4();
            fr.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            s = label8.Text;
            Form5 fr = new Form5(this);
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Geri Dönmek İstiyormusunuz", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Form1 fs = new Form1();
                fs.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı");
            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Geri Dönmek İstiyormusunuz", "ÇIKIŞ", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Form1 fs = new Form1();
                fs.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı");
            }
        }
    }
}
