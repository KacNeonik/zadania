using System;
using System.Collections.Generic;

class Program
{
    class Produkt
    {
        public string Kod;
        public string Nazwa;
        public decimal Cena;
    }

    static void Main()
    {
        List<Produkt> produkty = new List<Produkt>()
        {
            new Produkt { Kod = "10", Nazwa = "Chleb", Cena = 4.50m },
            new Produkt { Kod = "11", Nazwa = "Mleko", Cena = 3.20m },
            new Produkt { Kod = "12", Nazwa = "Masło", Cena = 7.99m },
            new Produkt { Kod = "13", Nazwa = "Ser", Cena = 6.50m },
            new Produkt { Kod = "14", Nazwa = "Jajka (10 szt.)", Cena = 8.00m },
            new Produkt { Kod = "15", Nazwa = "Cukier", Cena = 4.00m },
            new Produkt { Kod = "16", Nazwa = "Makaron", Cena = 3.80m },
            new Produkt { Kod = "17", Nazwa = "Ryż", Cena = 4.20m },
            new Produkt { Kod = "18", Nazwa = "Szynka", Cena = 9.50m },
            new Produkt { Kod = "19", Nazwa = "Jogurt", Cena = 2.50m }
        };

        // Koszyk
        List<Produkt> koszyk = new List<Produkt>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== TERMINAL KASOWY ===");
            Console.WriteLine("1 - Lista produktów");
            Console.WriteLine("2 - Skanowanie produktów");
            Console.WriteLine("3 - Paragon końcowy");
            Console.WriteLine("4 - Wyjście");
            Console.Write("\nWybierz opcję: ");

            string wybor = Console.ReadLine();

            // 1 - Lista produktów
            if (wybor == "1")
            {
                Console.Clear();
                Console.WriteLine("=== LISTA PRODUKTÓW ===\n");
                foreach (var p in produkty)
                {
                    Console.WriteLine($"{p.Kod} | {p.Nazwa} - {p.Cena} zł");
                }
                Console.WriteLine("\nENTER - powrót do menu");
                Console.ReadLine();
            }

            // 2 - Skanowanie
            else if (wybor == "2")
            {
                Console.Clear();
                Console.WriteLine("=== SKANOWANIE PRODUKTÓW ===");
                Console.WriteLine("Wpisz kod produktu");
                Console.WriteLine("\\ - powrót do menu\n");

                while (true)
                {
                    Console.Write("Kod: ");
                    string kod = Console.ReadLine();

                    if (kod == "\\")
                        break;

                    Produkt znaleziony = produkty.Find(p => p.Kod == kod);

                    if (znaleziony != null)
                    {
                        koszyk.Add(znaleziony);
                        Console.WriteLine($"Dodano: {znaleziony.Nazwa} ({znaleziony.Cena} zł)");
                    }
                    else
                    {
                        Console.WriteLine("Nieznany kod produktu!");
                    }
                }
            }

            // 3 - Paragon
            else if (wybor == "3")
            {
                Console.Clear();
                Console.WriteLine("=== PARAGON ===\n");

                if (koszyk.Count == 0)
                {
                    Console.WriteLine("Brak produktów w koszyku.");
                }
                else
                {
                    decimal suma = 0;

                    foreach (var p in koszyk)
                    {
                        Console.WriteLine($"{p.Nazwa} - {p.Cena} zł");
                        suma += p.Cena;
                    }

                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine($"ILOŚĆ PRODUKTÓW: {koszyk.Count}");
                    Console.WriteLine($"SUMA DO ZAPŁATY: {suma} zł");
                    Console.WriteLine("-------------------------");
                }

                koszyk.Clear(); // reset koszyka po paragonie
                Console.WriteLine("\nENTER - powrót do menu");
                Console.ReadLine();
            }

            // 4 - Wyjście
            else if (wybor == "4")
            {
                Console.WriteLine("Zamykanie programu...");
                break;
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór!");
                Console.ReadLine();
            }
        }
    }
}
