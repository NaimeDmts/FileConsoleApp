using PersonelMaasBodrosu.Models;

namespace PersonelMaasBodrosu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonelIslem personelIslem = new PersonelIslem();
            string path = @"C:\Users\naime\Desktop\";
            IList<Personel> personeller = personelIslem.DosyaOku(path,"calisan.txt");

         
            MaasBodro maasBodro = new MaasBodro(personeller);
            string maasgetir = maasBodro.MaasGetir("Ayşe");
            Console.WriteLine(maasgetir);

            Console.WriteLine(maasBodro.MaxMaas());
            foreach (var personel in maasBodro.MaxMaasGetir()) 
            { 
                Console.WriteLine(personel);
            }
        }
    }
}