using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmHarita : Form
    {
        public FrmHarita()
        {
            InitializeComponent();
        }

        private void PnlDersListesi_Click(object sender, EventArgs e)
        {
            FrmDersListesi frm = new FrmDersListesi();
            frm.Show();
            
        }

        private void pnlBolumListesi_Click(object sender, EventArgs e)
        {
            FrmBolumListesi frm = new FrmBolumListesi();
            frm.Show();
        }

        private void pnlYeniBolum_Click(object sender, EventArgs e)
        {
            FrmBolumler frm = new FrmBolumler();
            frm.Show();
        }

        private void pnlNotlar_Click(object sender, EventArgs e)
        {
            FrmNotlar frm = new FrmNotlar();
            frm.Show();
        }

        private void pnlOgrenciFormu_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
        }

        private void pnlOgrenciKayit_Click(object sender, EventArgs e)
        {
            FrmOgrenciKayit frm = new FrmOgrenciKayit();
            frm.Show();
        }

        private void pnlYardım_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Turkcell Geleceği Yazanlar Eğitimi kapsamında hazırlanmıştır. Müfredatın son projesinde amacımız şu ana kadar öğrenmiş olduğumz konuların büyük bir kısmını içeren örnek bir veri tabanlı proje uygulaması geliştirmektir. Projemizde akademisyen için kullanıcı adı : 00000 olup şifre : 000 şeklindedir. Akademisyen panelinden öğrenci, ders, bölüm, sınav notları gibi işlemlerin tamamı gerçekleştirilebilir. Sisteme giriş yapan öğrenci sadece kendisinde ait bilgileri ve sınav notlarını görüntüler. ","Yardım Penceresi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pnlYeniDers_Click(object sender, EventArgs e)
        {
            FrmYeniDers frm = new FrmYeniDers();
            frm.Show();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlCikisYap_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
