using System;
using System.Collections.Generic;

namespace ToDo
{
    class Program
    {
        static Dictionary<int, string> kullanicilar = new Dictionary<int, string>();
        static List<Card> board = new List<Card>();

        static void Main(string[] args)
        {
            kullanicilar.Add(1, "Selin Cengiz");
            kullanicilar.Add(2, "Nalan Cengiz");
            kullanicilar.Add(3, "Serkan Cengiz");
            kullanicilar.Add(4, "Semih Cengiz");
            kullanicilar.Add(5, "Zeliha Gökoğlan");
            kullanicilar.Add(6, "Göknil Keskin");



            selectionPage();


        }
        public static void selectionPage()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz\n****************************************");
            Console.WriteLine("(1) Board Listelemek ");
            Console.WriteLine("(2) Board'a Kart Eklemek ");
            Console.WriteLine("(3) Board'dan Kart Silmek ");
            Console.WriteLine("(4) Kart Taşımak ");

            int selection = int.MinValue;
            selectionControl(ref selection);

            switch (selection)
            {
                case 1:
                    BoardListeleme();
                    break;
                case 2:
                    BoardaKartEkleme();
                    break;
                case 3:
                    BoardtanKartSilme();
                    break;
                case 4:
                    KartTasimak();
                    break;

            }

        }
        public static void selectionControl(ref int selection)
        {
            while (true)
            {
                bool isInt = Int32.TryParse(Console.ReadLine(), out selection);
                if (selection > 0 && selection < 5 && isInt)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim , tekrar deneyiniz");

                }

            }
        }
        public static void BoardListeleme()
        {
            bool isNull = true;
            Console.WriteLine("\nTODO Line\n************************");
            foreach (var item in board)
            {
                if (item.line == Line.TODO)
                {
                    isNull = false;
                    Console.WriteLine($"Başlık      :{item.Baslik}");
                    Console.WriteLine($"İçerik      :{item.Icerik}");
                    Console.WriteLine($"Atanan Kişi :{item.kullanıcı}");
                    Console.WriteLine($"Büyüklük    :{item.buyuklukler}");
                    Console.WriteLine();

                }
            }
            if (isNull == true)
                Console.WriteLine(" ~ BOŞ ~");

            isNull = true;
            Console.WriteLine("\n IN PROGRESS Line\n************************");
            foreach (var item in board)
            {
                if (item.line == Line.inPROGRESS)
                {
                    isNull = false;
                    Console.WriteLine($"Başlık      :{item.Baslik}");
                    Console.WriteLine($"İçerik      :{item.Icerik}");
                    Console.WriteLine($"Atanan Kişi :{item.kullanıcı}");
                    Console.WriteLine($"Büyüklük    :{item.buyuklukler}");
                    Console.WriteLine();

                }

            }
            if (isNull == true)
                Console.WriteLine(" ~ BOŞ ~");

            isNull = true;

            Console.WriteLine(" \nDONE Line\n************************");
            foreach (var item in board)
            {
                if (item.line == Line.DONE)
                {
                    Console.WriteLine($"Başlık      :{item.Baslik}");
                    Console.WriteLine($"İçerik      :{item.Icerik}");
                    Console.WriteLine($"Atanan Kişi :{item.kullanıcı}");
                    Console.WriteLine($"Büyüklük    :{item.buyuklukler}");
                    Console.WriteLine();



                }

            }
            if (isNull == true)
                Console.WriteLine(" ~ BOŞ ~");


Console.WriteLine("Ana sayfaya yönlendiriliyor.");
selectionPage();
        }

        public static void BoardaKartEkleme()
        {
            Card card = new Card();
            Console.WriteLine(" Başlik Giriniz                                  :");
            card.Baslik = Console.ReadLine();
            Console.WriteLine(" İçerik Giriniz                                  :");
            card.Icerik = Console.ReadLine();
            Console.WriteLine(" Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            int sayi;
            while (true)
            {
                sayi = Int32.Parse(Console.ReadLine());
                if (sayi > 0 && sayi < 6)
                    break;
                else
                {
                    Console.WriteLine("Dogru tuslama yapiniz.");
                }
            }
            card.buyuklukler = (Buyuklukler)sayi;

            while (true)
            {
                Console.WriteLine(" Kişi Seçiniz                                    : ");
                sayi = Int32.Parse(Console.ReadLine());
                if (kullanicilar.ContainsKey(sayi))
                    break;
                else
                    Console.WriteLine("Hatali girişler yaptiniz!");

            }
            card.kullanıcı = kullanicilar[sayi];
            Console.WriteLine("Line giriniz -> TODO(1),inPROGRESS(2),DONE(3) ");
            sayi = Int32.Parse(Console.ReadLine());
            card.line = (Line)sayi;
            board.Add(card);

            Console.WriteLine("Kart basariyla eklendi . Ana sayfaya yönlendiriliyorsunuz");
            selectionPage();

        }
        public static void BoardtanKartSilme()
        {
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
            string baslik = Console.ReadLine();
            bool control = false;
            foreach (var item in board)
            {
                if (item.Baslik == baslik)
                {
                    board.Remove(item);
                    control = true;
                    Console.WriteLine("Board'dan basarıyla silindi");
                    Console.WriteLine("Ana sayfaya geçiliyor");
                    selectionPage();
                }
            }
            if (control == false)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n * Silmeyi sonlandırmak için : (1)\n * Yeniden denemek için : (2)");

                while (true)
                {
                    int selection = Int32.Parse(Console.ReadLine());
                    if (selection == 1)
                    {
                        selectionPage();
                        break;
                    }

                    else if (selection == 2)
                    {
                        BoardtanKartSilme();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Yanlış tuslama tekrar");
                    }
                }

            }
        }
        public static void KartTasimak()
        {

            Console.WriteLine("Öncelikle tasimak istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
            string baslik = Console.ReadLine();
            bool control = false;
            foreach (var item in board)
            {
                if (item.Baslik == baslik)
                {
                    control = true;

                    Console.WriteLine("Bulunan Kart Bilgileri:\n**************************************");
                    Console.WriteLine($"Başlık      :{item.Baslik}");
                    Console.WriteLine($"İçerik      :{item.Icerik}");
                    Console.WriteLine($"Atanan Kişi :{item.kullanıcı}");
                    Console.WriteLine($"Büyüklük    :{item.buyuklukler}");
                    Console.WriteLine($"Line    :{item.line}");

                    Console.WriteLine("Lütfen Tasimak isteediğiniz Line'ı seçiniz");
                    Console.WriteLine(" (1) TODO\n (2) IN PROGRESS\n (3) DONE");
                    int selection;
                    while (true)
                    {
                        selection = Int32.Parse(Console.ReadLine());
                        if (selection < 4 && selection > 0)
                            break;
                        else
                        {
                            Console.WriteLine("Yanlış seçim tekrar deneyiniz");
                        }

                    }

                    item.line = (Line)selection;
                    Console.WriteLine("Basariyla istenilen line'a tasındı . Ana sayfaya yönlendiriliyor.");

                    selectionPage();
                }
            }
            if (control == false)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n * Tasimayi sonlandırmak için : (1)\n * Yeniden denemek için : (2)");

                while (true)
                {
                    int selection = Int32.Parse(Console.ReadLine());
                    if (selection == 1)
                    {
                        selectionPage();
                        break;
                    }

                    else if (selection == 2)
                    {
                        KartTasimak();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Yanlış tuslama tekrar");
                    }
                }

            }
        }

    }
}
