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
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-G59PNFR;Initial Catalog=DBSeçimUyg;Integrated Security=True");
        private void Grafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select İlçeİd from TblParti",baglanti);
            SqlDataReader dr=komut.ExecuteReader(); 
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select SUM(AParti),SUM(BParti),SUM(CParti),SUM(DParti),SUM(EParti) FROM TblParti",baglanti);
            SqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("AParti", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("BParti", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("CParti", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("DParti", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("EParti", dr2[4]);

            }

            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from TblParti where İlçeİd=@P1", baglanti);
            komut3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr= komut3.ExecuteReader();  
            while(dr.Read())
            {
                progressBar1.Value = int.Parse( dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                labela.Text = dr[2].ToString();
                labelb.Text = dr[3].ToString();
                labelc.Text = dr[4].ToString();
                labeld.Text = dr[5].ToString();
                labele.Text = dr[6].ToString();
            }
            baglanti.Close();

        }
    }
}
