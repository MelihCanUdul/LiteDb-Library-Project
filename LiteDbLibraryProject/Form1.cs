using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiteDB_Kitaplik_Uygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


  
        private void Form1_Load(object sender, EventArgs e)
        {
            verileriListele();
        }

   
        private List<Kitaplar> verileriGetir()
        {
            var liste = new List<Kitaplar>();
            using (var db = new LiteDatabase(@"Veritabani.db"))
            {
                var kitaplar = db.GetCollection<Kitaplar>("Kitaplar");
                foreach (Kitaplar item in kitaplar.FindAll())
                {
                    liste.Add(item);
                }
            }
            return liste;
        }
        
        public void verileriListele()
        {
            dataGridView1.DataSource = verileriGetir();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(@"Veritabani.db"))
            {
                var kitaplar = db.GetCollection<Kitaplar>("Kitaplar");
                var kitap = new Kitaplar
                {
                    KitapAd = txtAdi.Text,
                    Yazar = txtYazari.Text,
                    Tur = txtTuru.Text,
                    Sayfa = int.Parse(nudSayfa.Value.ToString()),
                    Puan = int.Parse(nudPuan.Value.ToString()),
                    Aciklama = txtAciklama.Text,
                };
                kitaplar.Insert(kitap);
                verileriListele();
            }
        }

    
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(@"Veritabani.db"))
            {
                var kitaplar = db.GetCollection<Kitaplar>("Kitaplar");
                var kitap = new Kitaplar
                {
                    Id = Convert.ToInt32(txtId.Text),
                    KitapAd = txtAdi.Text,
                    Yazar = txtYazari.Text,
                    Tur = txtTuru.Text,
                    Sayfa = int.Parse(nudSayfa.Value.ToString()),
                    Puan = int.Parse(nudPuan.Value.ToString()),
                    Aciklama = txtAciklama.Text,
                };
                kitaplar.Update(kitap);
                verileriListele();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(@"Veritabani.db"))
            {
                var kitaplar = db.GetCollection<Kitaplar>("Kitaplar");
                kitaplar.Delete(x => x.Id == Convert.ToInt32(txtId.Text));
                verileriListele();
            }
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtYazari.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTuru.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string sayfanumarasi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            nudSayfa.Value = int.Parse(sayfanumarasi.ToString());
            string puani = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            nudPuan.Value = int.Parse(puani.ToString());
            txtAciklama.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

    }
}
