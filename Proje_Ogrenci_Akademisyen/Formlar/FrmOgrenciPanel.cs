using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciPanel : Form
    {
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }
        public string numara;
        TurkcellOgrenciSinavSistemiEntities db = new TurkcellOgrenciSinavSistemiEntities();
        int ogrenciId;
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            txtNumara.Text = numara;
            txtAd.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrAd).FirstOrDefault();
            txtSoyad.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrSoyad).FirstOrDefault();
            txtMail.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrMail).FirstOrDefault();
            txtSifre.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrSifre).FirstOrDefault();
            txtBolum.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrBolum).FirstOrDefault().ToString();

             ogrenciId=db.TblOgrenci.Where(x=>x.OgrNumara==numara).Select(y=>y.OgrId).FirstOrDefault();

            var sinavNotlari = (from x in db.TblNotlar
                               select new
                               {
                                   x.TblDersler.DersAd,
                                   x.Sinav1,
                                   x.Sinav2,
                                   x.Sinav3,
                                   x.Quiz1,
                                   x.Quiz2,
                                   x.Proje,
                                   x.Ortalama,
                                   x.Ogrenci
                               }).Where(y=>y.Ogrenci==ogrenciId).ToList();
            dataGridView1.DataSource = sinavNotlari;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == txtYeniSifre2.Text)
            {
                var deger = db.TblOgrenci.Find(ogrenciId);
                deger.OgrSifre = txtYeniSifre1.Text;
                db.SaveChanges();
                MessageBox.Show("Şifre değiştirme işlemi başarılı bir şekilde gerçekleşti.");
            }
            else
            {
                MessageBox.Show("Girilen şifreler birbiriyle uyuşmuyor.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris frm = new FrmGiris();
            frm.Show();
            this.Hide();
        }
    }
}
