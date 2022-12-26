using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Veri_tabanlı_parti_uygulaması
{
    public partial class VTGS : Form
    {
        public VTGS()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-G59PNFR;Initial Catalog=DBSeçimUyg;Integrated Security=True");
        private void btnoygiriş_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblParti(İlçeİd,AParti,BParti,CParti,DParti,EParti) values (@P1,@P2,@P3,@P4,@P5,@P6)" ,baglanti);
            komut.Parameters.AddWithValue("@P1", txtilçead.Text);
            komut.Parameters.AddWithValue("@P2", txta.Text);
            komut.Parameters.AddWithValue("@P3", txtb.Text);
            komut.Parameters.AddWithValue("@P4", txtc.Text);
            komut.Parameters.AddWithValue("@P5", txtd.Text);
            komut.Parameters.AddWithValue("@P6", txte.Text);
            komut.ExecuteNonQuery();    
            baglanti.Close();
            MessageBox.Show("oy girişi gerçekleşti");

        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            Grafikler fr=new Grafikler();
            fr.Show();
        }

        private void btnçıkış_Click(object sender, EventArgs e)
        {
            DialogResult seçim = new DialogResult();
            seçim = MessageBox.Show("çıkış yapmak istediğinize emin misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (seçim == DialogResult.Yes)
            {
                Application.Exit();
            }
            
            
          

            
        }
    }
}
