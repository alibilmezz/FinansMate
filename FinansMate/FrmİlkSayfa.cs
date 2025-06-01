using EntityLayer;
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
    public partial class FrmİlkSayfa: Form
    {
        public FrmİlkSayfa()
        {
            InitializeComponent();
        }
        public static int ID;
        private void FrmİlkSayfa_Load(object sender, EventArgs e)
        {
            //burada bakiyeyi maaş gününde güncelledik
            Kullanici kullanici = new Kullanici();
            LogicKullanıcıIslem islem=new LogicKullanıcıIslem();
            kullanici.KullaniciID = ID;
            islem.MaasGunuGuncelleme(kullanici);
        }
    }
}
