using PersonelMaasBodrosu.Abstraction;
using PersonelMaasBodrosu.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelMaasBodrosu.Models
{
    public class Mudur : Personel, IMudur
    {
        private double _bonus;


        public Mudur(int personelID, string ad, string soyad,int yas, Unvan personelUnvan, double saatlikUcret, int calismaSuresi, double bonus) : base(personelID, ad, soyad, yas, personelUnvan, saatlikUcret, calismaSuresi)
        {
      
            this._bonus = bonus;

        }

        public double Bonus { get; set; }

        public override void MaasHesapla()
        {
            base.MaasHesapla();
            ToplamMaas += Bonus;
        }
        public override string ToString()
        {
            string kisi = $"Id: {PersonelID}\nAdı: {Ad}\nSoyadı: {Soyad}\nYası: {Yas}\nSaatlik Ucreti: {SaatlikUcret}\nCalisma Suresi: {CalismaSuresi}\nBonus: {Bonus}\nMaası: {ToplamMaas.ToString("N2")}";
            return kisi ;
        }
    }
}
