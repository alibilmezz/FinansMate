using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using EntityLayer;

namespace FinansMate
{
    public partial class FrmGiris: Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void BtnHedefEkle_Click(object sender, EventArgs e)
        {
            LogicKullanıcıIslem logic = new LogicKullanıcıIslem();
            Kullanici ent = new Kullanici();
            ent.KullaniciID = int.Parse(TxtID.Text);
            ent.KullaniciSifre = TxtSifre.Text;
            
            if (logic.LogicKullaniciGiris(ent) == true)
            {

                Form1 fr = new Form1();
                Form1.KullaniciID= ent.KullaniciID;
                this.Hide();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Girdiğiniz Şifre Veya ID Hatalı.lütfen Tekrar Deneyiniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            
           



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKayıt frm = new FrmKayıt();
            frm.Show();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            TxtSifre.UseSystemPasswordChar = !TxtSifre.UseSystemPasswordChar;
        }
    }
}
