using PersonelMaasBodrosu.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelMaasBodrosu.Models
{
    public class PersonelIslem
    {
        static int _id=0;
        public PersonelIslem()
        {
                
        }
        public IList<Personel> DosyaOku(string path,string okunacakDosyaAdi)
        {

            List<Personel> personeller = new List<Personel>();

            if (File.Exists(path+okunacakDosyaAdi))
            {
                using (StreamReader reader = new StreamReader(path+okunacakDosyaAdi))
                {
                    string satir;
     
                    while ((satir = reader.ReadLine()) != null)
                    {
                        string[] veriler = satir.Split(',');
                        if (veriler.Length >=6)
                        {
                            
                            int id =++_id;
                            string ad = veriler[0];
                            string soyad = veriler[1];
                            int yas = Convert.ToInt32(veriler[2]);
                            Unvan unvan = (Unvan)Enum.Parse(typeof(Unvan), veriler[3]);
                            double saatlikUcret = Convert.ToDouble(veriler[4]);
                            int calismaSuresi = Convert.ToInt32(veriler[5]);
                          

                            Personel personel;
                            if (Unvan.Standart == unvan)
                            {
                                personel = new Personel(id,ad, soyad, yas, unvan, saatlikUcret, calismaSuresi)
                                { 
                                    PersonelID=id,
                                    Ad = ad,
                                    Soyad = soyad,
                                    Yas = yas,
                                    PersonelUnvan = unvan,
                                    SaatlikUcret = saatlikUcret,
                                    CalismaSuresi = calismaSuresi
                                };
                     
                                personel.MaasHesapla();

                                personeller.Add(personel);
                            }
                            else if(Unvan.Mudur == unvan)
                            {
                                double bonus = Convert.ToDouble(veriler[6]);
                                personel = new Mudur(id,ad, soyad, yas, unvan, saatlikUcret, calismaSuresi, bonus)
                                {
                                    PersonelID = id,
                                    Ad = ad,
                                    Soyad = soyad,
                                    Yas = yas,
                                    PersonelUnvan = unvan,
                                    SaatlikUcret = saatlikUcret,
                                    CalismaSuresi = calismaSuresi,
                                    Bonus = bonus
                                };
                                personel.MaasHesapla();
                                personeller.Add(personel);

                            }
                            else if(Unvan.Memur == unvan)
                            {
                                double avans = Convert.ToDouble(veriler[6]);
                                personel = new Memur(id,ad, soyad, yas, unvan, saatlikUcret, calismaSuresi, avans)
                                {   PersonelID = id,    
                                    Ad = ad,
                                    Soyad = soyad,
                                    Yas = yas,
                                    PersonelUnvan = unvan,
                                    SaatlikUcret = saatlikUcret,
                                    CalismaSuresi = calismaSuresi,
                                    Avans = avans
                                };
                                personel.MaasHesapla();
                                personeller.Add(personel);

                            }
                        }
                    }
                }
                string klasorAdi = DateTime.Now.ToString("yyyy-MMMM");
                string klasorYolu = Path.Combine(path, klasorAdi);

                Directory.CreateDirectory(klasorYolu);

                foreach (Personel personel in personeller)
                {
                    string dosyaAdi = $"{personel.Ad}_{personel.Soyad}_{personel.PersonelUnvan}.txt";
                    string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

                    using (StreamWriter writer = new StreamWriter(dosyaYolu))
                    {
                        writer.WriteLine(personel);
                    }
                }
            }
            return personeller;
        }     
    }
}
