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
    public partial class Form3 : Form
    {
        Form2 form2;
        OleDbConnection bg = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database2.mdb");
        public OleDbDataAdapter daDoktorlar;
        public OleDbDataAdapter daRandevular;
        public DataSet dataset = new DataSet();
        public BindingSource bsDoktorlar;
        public BindingSource bsRandevular;
        public OleDbCommandBuilder bd;
        public OleDbCommandBuilder br;
        public OleDbCommand sorgu;
        public Form3(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }
        public Form3()
        {
            
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bg.Open();
            
            string b = form2.b ;
            daRandevular = new OleDbDataAdapter($"select * from Randevular where DoktorTc = '{b}' ", bg);
            
            daRandevular.Fill(dataset, "Randevular");
            bsRandevular = new BindingSource(dataset, "Randevular");
           
            dataGridView1.DataSource = bsRandevular;
            bindingNavigator1.BindingSource = bsRandevular;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 fs = new Form2();
            fs.Show();
        }
    }
}
