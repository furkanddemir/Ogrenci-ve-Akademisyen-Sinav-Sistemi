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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        TurkcellOgrenciSinavSistemiEntities db = new TurkcellOgrenciSinavSistemiEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtBolumAd.Text == "")
            {
                errorProvider1.SetError(txtBolumAd,"Bölüm adı boş geçilemez!");
            }
            else
            {
                TblBolum t = new TblBolum();
                t.BolumAd = txtBolumAd.Text;    
                db.TblBolum.Add(t);
                db.SaveChanges();
                MessageBox.Show("Bölüm ekleme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHarita frm = new FrmHarita();
            frm.Show();
            this.Hide();
        }
    }
}
