using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB_Kitaplik_Uygulamasi
{
    public class Kitaplar
    {
        public int Id { get; set; }
        public string KitapAd { get; set; }
        public string Yazar { get; set; }
        public string Tur { get; set; }
        public int Sayfa { get; set; }
        public int Puan { get; set; }
        public string Aciklama { get; set; }
    }
}
