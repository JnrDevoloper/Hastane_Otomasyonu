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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection bg = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
        public OleDbDataAdapter daDoktorlar;
        public OleDbDataAdapter Randevular;
        public DataSet dataset = new DataSet();
        public BindingSource bsDoktorlar;
        public BindingSource bsRandevular;
        public OleDbCommandBuilder bd;
        public OleDbCommandBuilder br;
        public OleDbCommand sorgu;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
           
            
            
           
            try
            {
                bg.Open();
                daDoktorlar = new OleDbDataAdapter("select * from Doktorlar ", bg);
                daDoktorlar.Fill(dataset, "Doktorlar");
                bsDoktorlar = new BindingSource(dataset, "Doktorlar");
                textBox1.DataBindings.Add("Text", bsDoktorlar, "TCKimlik", true);
                textBox2.DataBindings.Add("Text", bsDoktorlar, "Adi", true);
                textBox3.DataBindings.Add("Text", bsDoktorlar, "Soyadi", true);
                textBox4.DataBindings.Add("Text", bsDoktorlar, "Bransi", true);
                textBox5.DataBindings.Add("Text", bsDoktorlar, "Yas", true);
                textBox6.DataBindings.Add("Text", bsDoktorlar, "EMail", true);
                textBox7.DataBindings.Add("Text", bsDoktorlar, "Adres", true);
                textBox8.DataBindings.Add("Text", bsDoktorlar, "Sifre", true);
                pictureBox1.DataBindings.Add("ImageLocation", bsDoktorlar, "Fotograf", true);
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image = pictureBox1.InitialImage;
                }
                dataGridView1.DataSource =bsDoktorlar;
                bindingNavigator1.BindingSource = bsDoktorlar;
            }
            catch ( Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sorgu = new OleDbCommand();
                bg.Open();
                sorgu.Connection = bg;
                sorgu = new OleDbCommand("Insert into Doktorlar (TCKimlik,Adi,Soyadi,Bransi,Yas,EMail,Adres,Fotograf,Sifre) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bg);
                sorgu.Parameters.AddWithValue("@p1", textBox1.Text);
                sorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                sorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                sorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                sorgu.Parameters.AddWithValue("@p5", textBox5.Text);
                sorgu.Parameters.AddWithValue("@p6", textBox6.Text);
                sorgu.Parameters.AddWithValue("@p7", textBox7.Text);
                sorgu.Parameters.AddWithValue("@p8",label9.Text );
                sorgu.Parameters.AddWithValue("@p9", textBox8.Text);

                sorgu.ExecuteNonQuery();
                bg.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection ad = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
            ad.Open();
            string a = textBox1.Text;
            string sorgu2 = $" Delete from Doktorlar where TCKimlik='{a}' ";
            sorgu = new OleDbCommand(sorgu2, ad);
            sorgu.ExecuteNonQuery();
            dataGridView1.Refresh();
            ad.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbConnection ad = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");

                ad.Open();

                string sorgu2 = " Update Doktorlar Set TCKimlik=@p1,Adi=@p2,SoyAdi=@p3,Bransi=@p4,Yas =@p5,EMail=@p6,Adres=@p7,Fotograf=@p8,Sifre=@p9  Where TCKimlik=@p1 ";
                sorgu = new OleDbCommand(sorgu2, ad);
                sorgu.Parameters.AddWithValue("@p1", textBox1.Text);
                sorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                sorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                sorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                sorgu.Parameters.AddWithValue("@p5", textBox5.Text);
                sorgu.Parameters.AddWithValue("@p6", textBox6.Text);
                sorgu.Parameters.AddWithValue("@p7", textBox7.Text);
                sorgu.Parameters.AddWithValue("@p8", label9.Text);
                sorgu.Parameters.AddWithValue("@p9", textBox8.Text);



                sorgu.ExecuteNonQuery();
                ad.Close();



            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tüm Dosyalar|*.*|Jpeg Dosyası |*.jpg|PNG Dosyası |*.png";
            DialogResult cevap = ofd.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
                label9.Text = ofd.FileName;
            }
        }
    }
}
