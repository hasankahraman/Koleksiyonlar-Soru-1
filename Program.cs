using System;
using System.Collections;

namespace Koleksiyonlar_Soru_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList sayiListesi = new ArrayList();
            ArrayList asalSayiListesi = new ArrayList();
            ArrayList asalOlmayanSayiListesi = new ArrayList();
            int toplamAsal = 0;
            int toplamAsalOlmayan = 0;

            Console.WriteLine("Lütfen 20 tane pozitif ve nümerik olan sayı giriniz: ");
            
            while(sayiListesi.Count<20){

                try{
                    int girilenSayi = int.Parse(Console.ReadLine());

                if(girilenSayi>0 && StringFaaliyet.IsNumeric(girilenSayi)){ // Eğer numerikse veya pozitifse eklenecek.

                    sayiListesi.Add(girilenSayi);

                    //Asal olma durumu
                    int sonuc = StringFaaliyet.Asalmi(girilenSayi);
                    if (sonuc == 0)
                    {
                        asalOlmayanSayiListesi.Add(girilenSayi);
                        toplamAsalOlmayan += girilenSayi;
                    }
                    else
                    {
                        asalSayiListesi.Add(girilenSayi);
                        toplamAsal += girilenSayi;
                    }
                }else{
                    Console.WriteLine("Lütfen pozitif ve nümerik bir değer giriniz.");
                }

                }catch{
                    Console.WriteLine("Lütfen pozitif ve nümerik bir değer giriniz.");
                }
            }

            


            asalSayiListesi.Sort();
            asalSayiListesi.Reverse();
            Console.WriteLine("Asal Sayı Listesi");
            foreach(var sayi in asalSayiListesi){
                Console.WriteLine(sayi);
            }

            asalOlmayanSayiListesi.Sort();
            asalOlmayanSayiListesi.Reverse();
            Console.WriteLine("Asal Olmayan Sayı Listesi");
            foreach(var sayi in asalOlmayanSayiListesi){
                Console.WriteLine(sayi);
            }

            double asalOrtalama = toplamAsal/asalSayiListesi.Count;
            double asalOlmayanOrtalama = toplamAsalOlmayan/asalOlmayanSayiListesi.Count;
           

            Console.WriteLine("Asal sayı listesindeki eleman sayısı: {0}, sayıların ortalaması: {1}", asalSayiListesi.Count, asalOrtalama);
            Console.WriteLine("Asal olmayan sayı listesindeki eleman sayısı: {0}, sayıların ortalaması: {1}", asalOlmayanSayiListesi.Count, asalOlmayanOrtalama);
            Console.ReadLine();

        }

        public static class StringFaaliyet{
            public static bool IsNumeric(int number){
                double test;
                return double.TryParse(number.ToString(), out test);
            }

            public static int Asalmi(int sayi){
                int i;
                for (i = 2; i <= sayi - 1; i++)
                {
                    if (sayi % i == 0)
                    {
                        return 0;
                    }
                }
                if (i == sayi)
                {
                    return 1;
                }
                return 0;
            }
        } 
    }
}
