using PersonelMaasBodrosu.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelMaasBodrosu.Abstraction
{
    public interface IPersonel
    {
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        
        public Unvan PersonelUnvan { get; set; }
        public double SaatlikUcret { get; set; }
        public int CalismaSuresi { get; set; }

        public double ToplamMaas { get; set; }

        public virtual void MaasHesapla() 
        { 
        }
    }
}
