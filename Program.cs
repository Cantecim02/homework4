using System.Globalization;
using helper;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Class1> kitaplar = new List<Class1>();
            {

                new Class1 { Id = 1, Ad = "Sanatın Kalbi", YazarAdi = "Ahmet Yılmaz", Tur = "Sanat", SayfaSayisi = 200, YayinTarihi = new DateTime(2020, 5, 1), Fiyat = 120, Stok = 10, SatisRakam = 50 };
                new Class1 { Id = 2, Ad = "Yazılım Mühendisliği", YazarAdi = "Mehmet Demir", Tur = "Teknoloji", SayfaSayisi = 300, YayinTarihi = new DateTime(2019, 3, 15), Fiyat = 150, Stok = 5, SatisRakam = 20 };
                new Class1 { Id = 3, Ad = "Veri Yapıları", YazarAdi = "Ayşe Korkmaz", Tur = "Eğitim", SayfaSayisi = 250, YayinTarihi = new DateTime(2021, 7, 10), Fiyat = 80, Stok = 15, SatisRakam = 30 };


            };

            Console.WriteLine("Sanat türündeki kitaplar:");
            foreach (var k in kitaplar.Where(k => k.Tur == "Sanat"))

                Console.WriteLine($" {k.Ad}");


            Console.Write("\nYazar adı giriniz: ");
            string yazar = Console.ReadLine();

            var yazarKitaplari = kitaplar.Where(k => k.YazarAdi.Equals(yazar, StringComparison.OrdinalIgnoreCase));
            if (yazarKitaplari.Any())
            {
                foreach (var kitap in yazarKitaplari)
                    Console.WriteLine($"- {kitap.Ad}, {kitap.Fiyat} TL");
                Console.WriteLine($"Toplam {yazarKitaplari.Count()} kitap bulundu.");


            }
            else
                Console.WriteLine("Aradığınız kriterler bulunamadı ");


            // yenikitaplar 


            Console.WriteLine("\nYeni kitap ekleyiniz:");
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Yazar: ");
            string yazarAdi = Console.ReadLine();
            Console.Write("Tür: ");
            string tur = Console.ReadLine();
            Console.Write("Sayfa Sayısı: ");
            int sayfa = int.Parse(Console.ReadLine());
            Console.Write("Yayın Tarihi (yyyy-mm-dd): ");
            DateTime yayinTarihi = DateTime.Parse(Console.ReadLine());
            Console.Write("Fiyat: ");
            decimal fiyat = decimal.Parse(Console.ReadLine());
            Console.Write("Stok: ");
            int stok = int.Parse(Console.ReadLine());
            Console.Write("Satış Rakamı: ");
            int satis = int.Parse(Console.ReadLine());



            kitaplar.Add(new Class1
            {
                Id = kitaplar.Max(k => k.Id) + 1,
                Ad = ad,
                YazarAdi = yazarAdi,
                Tur = tur,
                SayfaSayisi = sayfa,
                YayinTarihi = yayinTarihi,
                Fiyat = fiyat,
                Stok = stok,
                SatisRakam = satis
            });

            Console.WriteLine("yeni kitap başarıyla eklendi.");



            //kitaptan elde edilen karlar 
            Console.WriteLine("\nHer kitaptan elded edilen kar :");
            foreach (var kitap in kitaplar )
                Console.WriteLine($"{kitap.Ad}: {kitap.Fiyat * kitap.SatisRakam} TL");


            // kitap adıyla arama ve okuma süresi 

            Console.Write("\nkitap adı giriniz: ");
              string kitapAdi = Console.ReadLine();
            var kitapBul = kitaplar.FirstOrDefault(k => k.Ad.Equals(kitapAdi, StringComparison.OrdinalIgnoreCase));
            if (kitapBul != null) 
            {
                Console.WriteLine($"Ad: {kitapBul.Ad}, Yazar: {kitapBul.YazarAdi}, Sayfa: {kitapBul.SayfaSayisi}");
                double okumaSuresi = kitapBul.SayfaSayisi / 2.0; // varsayılan 2 dk/sayfa
                Console.WriteLine($"Yaklaşık okuma süresi: {okumaSuresi} dakika");
            }
            else 
                Console.WriteLine("Aradığınız kitap bulunamadı.");

            // en çok satanlara göre sıralama 

            Console.WriteLine("\nEn çok satan kitaplar:");
            var enCokSatanlar = kitaplar.OrderByDescending(k => k.SatisRakam);
           foreach ( var kitap in enCokSatanlar )
                Console.WriteLine($"Ad: {kitap.Ad}, Yazar: {kitap.YazarAdi}, Sayfa: {kitap.SayfaSayisi}, Fiyat: {kitap.Fiyat}, Satış: {kitap.SatisRakam}");
            // fiyat 100 den az olan kitap sayısı 

            int ucuzKitapSAYISI = kitaplar.Count(k => k.Fiyat < 100);
            Console.WriteLine($"\n100 TL altındaki kitap sayısı: {ucuzKitapSAYISI}");


            //ortalama fiyatlar 

            decimal ortalamaFiyat = kitaplar.Average(k => k.Fiyat); ;

            Console.WriteLine($"Kitapların ortalama fiyatı: {ortalamaFiyat:F2} TL");
        }









    }
    
}