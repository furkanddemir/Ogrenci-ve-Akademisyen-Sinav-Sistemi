using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmYeniDers : Form
    {
        public FrmYeniDers()
        {
            InitializeComponent();
        }
        TurkcellOgrenciSinavSistemiEntities db = new TurkcellOgrenciSinavSistemiEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblDersler t = new TblDersler();
            t.DersAd = txtDersAd.Text;
            db.TblDersler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni ders kaydetme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHarita frm = new FrmHarita();
            frm.Show();
            this.Hide();
        }
    }
}
