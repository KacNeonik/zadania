using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Struktura produkt
    public struct Produkt
    {
        public string Kod;
        public string Nazwa;
        public decimal Cena;

        public Produkt(string kod, string nazwa, decimal cena)
        {
            Kod = kod;
            Nazwa = nazwa;
            Cena = cena;
        }
    }

    // Struktura pozycji koszyka
    public struct PozycjaKoszyka
    {
        public Produkt Produkt;
        public int Ilosc;

        public PozycjaKoszyka(Produkt produkt, int ilosc)
        {
            Produkt = produkt;
            Ilosc = ilosc;
        }
    }

    static void Main(string[] args)
    {
        // Lista dostępnych produktów
        List<Produkt> produkty = new List<Produkt>()
        {
            new Produkt("1001", "Chleb", 4.50m),
            new Produkt("1002", "Masło", 6.20m),
            new Produkt("1003", "Mleko", 3.80m),
            new Produkt("1004", "Ser Żółty", 8.99m),
            new Produkt("1005", "Jabłka (kg)", 3.20m),
            new Produkt("1006", "Kawa", 15.50m),
            new Produkt("1007", "Cukier", 4.10m),
            new Produkt("1008", "Woda 1.5L", 2.30m),
            new Produkt("1009", "Makaron", 3.70m),
            new Produkt("1010", "Szynka", 7.80m)
        };

        List<PozycjaKoszyka> koszyk = new List<PozycjaKoszyka>(); // Koszyk

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SKLEP TERMINALOWY ===");
            Console.WriteLine("1 - Wyświetl listę produktów");
            Console.WriteLine("2 - Dodaj produkt do koszyka (kod 4-cyfrowy)");
            Console.WriteLine("3 - Drukuj paragon");
            Console.WriteLine("4 - Usuń wszystkie produkty z koszyka");
            Console.WriteLine("5 - Wyjście");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                // WYŚWIETLANIE PRODUKTÓW
                case "1":
                    Console.Clear();
                    Console.WriteLine("=== LISTA PRODUKTÓW ===");
                    foreach (var p in produkty)
                    {
                        Console.WriteLine($"{p.Kod} - {p.Nazwa} - {p.Cena} zł");
                    }
                    Console.WriteLine("\nWciśnij ENTER aby wrócić...");
                    Console.ReadLine();
                    break;

                // DODAWANIE PRODUKTÓW
                case "2":
                    Console.Clear();
                    Console.WriteLine("=== DODAWANIE PRODUKTÓW ===");
                    Console.WriteLine("Wpisz kod produktu lub '\\' aby wrócić.");

                    while (true)
                    {
                        Console.Write("\nKod: ");
                        string kod = Console.ReadLine();

                        if (kod == "\\")
                            break;

                        var znaleziony = produkty.FirstOrDefault(p => p.Kod == kod);

                        if (znaleziony.Kod == null)
                        {
                            Console.WriteLine("Nie znaleziono produktu o takim kodzie!");
                            continue;
                        }

                        Console.Write("Podaj ilość: ");
                        if (int.TryParse(Console.ReadLine(), out int ilosc) && ilosc > 0)
                        {
                            koszyk.Add(new PozycjaKoszyka(znaleziony, ilosc));
                            Console.WriteLine($"Dodano: {znaleziony.Nazwa} x {ilosc}");
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowa ilość!");
                        }
                    }
                    break;

                // PARAGON
                case "3":
                    Console.Clear();
                    Console.WriteLine("=== PARAGON ===");

                    if (koszyk.Count == 0)
                    {
                        Console.WriteLine("Koszyk jest pusty!");
                    }
                    else
                    {
                        decimal suma = 0;

                        Console.WriteLine("========================================");
                        Console.WriteLine("               PARAGON                 ");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"{"Nazwa produktu",-25} {"Ilość",6} {"Cena",10}");
                        Console.WriteLine("----------------------------------------");

                        foreach (var poz in koszyk)
                        {
                            decimal razem = poz.Produkt.Cena * poz.Ilosc;
                            suma += razem;

                            Console.WriteLine($"{poz.Produkt.Nazwa,-25} x{poz.Ilosc,-5} {razem,10:F2} zł");
                        }

                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"{"SUMA:",-31} {suma,10:F2} zł");
                        Console.WriteLine("========================================");
                    }

                    Console.WriteLine("\nWciśnij ENTER aby wrócić...");
                    Console.ReadLine();
                    break;

                // CZYSZCZENIE KOSZYKA
                case "4":
                    Console.Clear();
                    koszyk.Clear();
                    Console.WriteLine("Wyczyszczono cały koszyk!");
                    Console.WriteLine("\nWciśnij ENTER aby wrócić...");
                    Console.ReadLine();
                    break;

                // WYJŚCIE
                case "5":
                    return;

                default:
                    Console.WriteLine("Niepoprawna opcja!");
                    break;
            }
        }
    }
}
