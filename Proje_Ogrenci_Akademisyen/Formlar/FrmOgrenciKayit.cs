using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;


namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciKayit : Form
    {
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }
        

        SqlConnection baglanti = new SqlConnection("Data Source=FURKAN\\SQLEXPRESS;Initial Catalog=TurkcellOgrenciSinavSistemi;Integrated Security=True");

        TurkcellOgrenciSinavSistemiEntities db = new TurkcellOgrenciSinavSistemiEntities();
        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TblBolum",baglanti);
            //SqlDataReader dr = komut.ExecuteReader();   
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = ds;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == txtSifreTekrar.Text)
            {
                TblOgrenci t = new TblOgrenci();
                t.OgrAd = txtAd.Text;
                t.OgrSoyad = txtSoyad.Text;
                t.OgrNumara = mtxtNumara.Text;
                t.OgrMail = txtMail.Text;
                t.OgrSifre = txtSifre.Text;
                t.OgrResim = txtResim.Text;
                t.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
                db.TblOgrenci.Add(t);
                db.SaveChanges();
                MessageBox.Show("Öğrenci bilgileri sisteme başarılı bir şekilde kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen şifreleri birbiri ile aynı olacak şekilde yeniden girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtResim.Text = openFileDialog1.FileName; //path + file name
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHarita frm = new FrmHarita();
            frm.Show();
            this.Hide();
        }
    }
}
