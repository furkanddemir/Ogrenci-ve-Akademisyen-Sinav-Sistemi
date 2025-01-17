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

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=FURKAN\\SQLEXPRESS;Initial Catalog=TurkcellOgrenciSinavSistemi;Integrated Security=True");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TblOgrenci Where OgrNumara=@p1 and OgrSifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtNumara.Text);
            komut.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) 
            {
                FrmOgrenciPanel frm = new FrmOgrenciPanel();
                frm.numara=txtNumara.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Numara veya şifre yanlış, tekrar deneyin.","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumara_TextChanged(object sender, EventArgs e)
        {
            if(txtNumara.Text == "00000" && txtSifre.Text == "000")
            {
                FrmHarita frm = new FrmHarita();
                frm.Show();
                this.Hide();
            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            if (txtSifre.Text == "000" && txtNumara.Text == "00000")
            {
                FrmHarita frm = new FrmHarita();
                frm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
