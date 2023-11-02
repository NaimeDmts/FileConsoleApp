using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelMaasBodrosu.Models
{
    public class MaasBodro
    {
        private IList<Personel> personeller;
        public MaasBodro(IList<Personel> personeller)
        {
                this.personeller = personeller;
        }


        public string MaasGetir(string PersonelAdi)
        {
            var maasGetir = personeller
                .Where(p => p.Ad == PersonelAdi)
                .Select(p => p.ToplamMaas.ToString("N2"))
                .FirstOrDefault();
            return maasGetir;
        }
        public double MaxMaas()
        {
            var maxMaasGetir = personeller.Max(p => p.ToplamMaas);
            return maxMaasGetir;
        }
        public IList<(string Ad, string Soyad)> MaxMaasGetir()
        {
            var maxmaas =MaxMaas();
            var kosul = personeller.Where(p => p.ToplamMaas == maxmaas);
            return kosul.Select(p => (Ad: p.Ad, Soyad: p.Soyad)).ToList(); 
        }
        

    }
}
