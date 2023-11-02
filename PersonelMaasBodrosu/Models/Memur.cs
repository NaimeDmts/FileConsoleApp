using PersonelMaasBodrosu.Abstraction;
using PersonelMaasBodrosu.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelMaasBodrosu.Models
{
    public class Memur : Personel, IMemur
    {
        double _avans;
 
        public Memur(int personelID, string ad,string soyad ,int yas, Unvan personelUnvan, double saatlikUcret, int calismaSuresi, double avans) : base(personelID,ad, soyad,yas, personelUnvan, saatlikUcret, calismaSuresi)
        {

            this.Avans = avans;
        }

        public double Avans 
        { 
            get=>_avans;
            set
            {
                if(value>=SaatlikUcret) 
                {
                    _avans = value;
                }
                else 
                {
                    throw new Exception("Avans Saatlik Ücretten az olamaz");
                }
            }
        }
        public override void MaasHesapla()
        {
          base.MaasHesapla();
          ToplamMaas += Avans;
        }
        public override string ToString()
        {
            string kisi = $"Id: {PersonelID}\nAdı: {Ad}\nSoyadı: {Soyad}\nYası: {Yas}\nSaatlik Ucreti: {SaatlikUcret}\nCalisma Suresi: {CalismaSuresi}\nAvans: {Avans}\nMaası: {ToplamMaas.ToString("N2")}";
            return kisi;
        }
    }
}
