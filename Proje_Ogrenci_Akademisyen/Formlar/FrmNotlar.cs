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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        TurkcellOgrenciSinavSistemiEntities db = new TurkcellOgrenciSinavSistemiEntities();

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "DersAd";
            comboBox1.ValueMember = "DersID";
            comboBox1.DataSource = db.TblDersler.ToList();
            comboBox2.DisplayMember = "DersAd";
            comboBox2.ValueMember = "DersID";
            comboBox2.DataSource = db.TblDersler.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblNotlar t = new TblNotlar();
            t.Sinav1 = byte.Parse(txtSinav1.Text);
            t.Sinav2 = byte.Parse(txtSinav2.Text);
            t.Sinav3 = byte.Parse(txtSinav3.Text);
            t.Proje = byte.Parse(txtProje.Text);
            t.Quiz1 = byte.Parse(txtQuiz1.Text);
            t.Quiz2 = byte.Parse(txtQuiz2.Text);
            t.Ders = int.Parse(comboBox1.SelectedValue.ToString());
            t.Ogrenci = int.Parse(txtOgrenci.Text);
            db.TblNotlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci not bilgisi için sisteme kaydedildi.");
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            byte s1, s2, s3, q1, q2, proje;
            double ortalama;
            s1= byte.Parse(txtSinav1.Text);
            s2 = byte.Parse(txtSinav2.Text);
            s3 = byte.Parse(txtSinav3.Text);
            q1 = byte.Parse(txtQuiz1.Text);
            q2 = byte.Parse(txtQuiz2.Text);
            proje = byte.Parse(txtProje.Text);
            ortalama=(s1+s2+s3+q1+q2+proje)/6;
            txtOrtalama.Text=ortalama.ToString();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.View_1.ToList();
            dataGridView1.DataSource = db.Notlar3();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotID,
                               x.TblDersler.DersAd,
                               Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ders
                           };
            
            int d=int.Parse(comboBox2.SelectedValue.ToString());
            dataGridView1.DataSource= degerler.Where(y=>y.Ders==d).ToList();
            dataGridView1.Columns["Ders"].Visible = false;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotID,
                               x.TblDersler.DersAd,
                               Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ogrenci
                           };
            int i = int.Parse(txtNumara.Text);
            dataGridView1.DataSource = degerler.Where(y=>y.Ogrenci==i).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }

        private void btnAra2_Click(object sender, EventArgs e)
        {
            string no=txtNumara.Text;
            var deger = db.TblOgrenci.Where(x => x.OgrNumara == no).Select(y=>y.OgrId).FirstOrDefault();
            //txtId.Text = deger.ToString();
            var notlar = from x in db.TblNotlar
                         select new
                         {
                             x.NotID,
                             x.TblDersler.DersAd,
                             Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                             x.Sinav1,
                             x.Sinav2,
                             x.Sinav3,
                             x.Quiz1,
                             x.Quiz2,
                             x.Proje,
                             x.Ortalama,
                             x.Ogrenci
                         };
            dataGridView1.DataSource = notlar.Where(z => z.Ogrenci == deger).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = db.TblNotlar.Find(id);
            x.Sinav1 = int.Parse(txtSinav1.Text);
            x.Sinav2 = int.Parse(txtSinav2.Text);
            x.Sinav3 = int.Parse(txtSinav3.Text);
            x.Quiz1 = int.Parse(txtQuiz1.Text);
            x.Quiz2 = int.Parse(txtQuiz2.Text);
            x.Proje = int.Parse(txtProje.Text);
            x.Ortalama = int.Parse(txtOrtalama.Text);
            db.SaveChanges();
            MessageBox.Show("Öğrenci notları başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtQuiz1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtQuiz2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            //txtOgrenci.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            //comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHarita frm = new FrmHarita();
            frm.Show();
            this.Hide();
        }
    }
}
