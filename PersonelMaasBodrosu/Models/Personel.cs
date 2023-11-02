using PersonelMaasBodrosu.Abstraction;
using PersonelMaasBodrosu.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelMaasBodrosu.Models
{
    public class Personel : IPersonel
    {
        int _yas;
        double _saatlikUcret;
        int _calismaSuresi;
       public Personel(int personelID, string ad,string soyad,int yas,Unvan personelUnvan, double saatlikUcret,int calismaSuresi)
        {
            this.PersonelID = personelID;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Yas = yas;
            this.PersonelUnvan = personelUnvan; 
            this.SaatlikUcret = saatlikUcret;
            this.CalismaSuresi = calismaSuresi;
        }
        public int PersonelID { get; set; } 
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas
        { get=> _yas; 
          set
            {
                if ((DateTime.Now.Year - value >= 18))
                {
                    _yas = DateTime.Now.Year - value;
                }
                else
                {
                    throw new Exception("18 yaşından küçük personel çalıştırılamaz");
                }
            }
        }
        public double SaatlikUcret
        {
            get => _saatlikUcret;
            set
            {
                if (value >=200)
                {
                   _saatlikUcret = value;
                }
                else
                {
                    throw new Exception("Saatlik Ucret 200 den Az Olamaz");
                }
            } 
        }
        public int CalismaSuresi 
        { 
            get=>_calismaSuresi; 
            set
            {
                if (value > 0)
                {
                    _calismaSuresi = value;
                }
                else 
                { 
                    throw new Exception("Çalışma Surasi 0 dan küçük olamaz"); 
                }
            } 
        }
        public double ToplamMaas { get; set; }
        public Unvan PersonelUnvan { get; set; }

        public virtual void MaasHesapla()
        {
            ToplamMaas = _calismaSuresi * _saatlikUcret;
        }

        public override string ToString()
        {
            string kisi = $"Id: {PersonelID}\nAdı: {Ad}\nSoyadı: {Soyad}\nYası: {Yas}\nSaatlik Ucreti: {SaatlikUcret}\nCalisma Suresi: {CalismaSuresi}\nMaası: {ToplamMaas.ToString("N2")}";
            return kisi;
        }
    }
}
