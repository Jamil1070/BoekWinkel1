using System;
using System.Collections.Generic;

class Program
{
    static List<Boek> boeken = new List<Boek>();
    static List<Tijdschrift> tijdschriften = new List<Tijdschrift>();
    static List<Bestelling<Boek>> bestellingenBoek = new List<Bestelling<Boek>>();
    static List<Bestelling<Tijdschrift>> bestellingenTijdschrift = new List<Bestelling<Tijdschrift>>();


    static void Main()
    {


        // Voeg enkele boeken toe aan de lijst
        boeken.Add(new Boek("978-0452284234", "To Kill a Mockingbird", "Harper Lee", 10.99m));
        boeken.Add(new Boek("978-0061120084", "1984", "George Orwell", 9.99m));
        boeken.Add(new Boek("978-0141988477", "The Great Gatsby", "F. Scott Fitzgerald", 8.49m));

        // Voeg enkele tijdschriften toe aan de lijst
        tijdschriften.Add(new Tijdschrift("12345", "National Geographic", "National Geographic Society", 6m, Verschijningsperiode.Maandelijks));
        tijdschriften.Add(new Tijdschrift("67890", "Time Magazine", "Time", 5.99m, Verschijningsperiode.Wekelijks));
        tijdschriften.Add(new Tijdschrift("54321", "Scientific American", "Springer Nature", 6.49m, Verschijningsperiode.Maandelijks));

        foreach (var bestelling in bestellingenBoek)
        {
            bestelling.BoekBesteldEvent += BoekBesteldEventHandler;
        }


        while (true)
        {
            Console.WriteLine("Welkom bij de boekwinkel!");
            Console.WriteLine("1. Bestel een boek");
            Console.WriteLine("2. Bestel een tijdschrift");
            Console.WriteLine("3. Toon bestellingen");
            Console.WriteLine("4. Afsluiten");

            int keuze = GetIntegerInput("Voer uw keuze in: ");

            switch (keuze)
            {
                case 1:
                    BestelBoek();
                    break;
                case 2:
                    BestelTijdschrift();
                    break;
                case 3:
                    ToonBestellingen();
                    break;
                case 4:
                    Console.WriteLine("Bedankt voor uw bezoek aan de boekwinkel. Tot ziens!");
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                    break;
            }
        }
    }

    static void BestelBoek()
    {
        Console.WriteLine("Beschikbare boeken:");
        for (int i = 0; i < boeken.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {boeken[i]}");
        }

        int boekIndex = GetIntegerInput("Selecteer een boek om te bestellen (geef het nummer in): ") - 1;
        if (boekIndex >= 0 && boekIndex < boeken.Count)
        {
            int aantal = GetIntegerInput("Hoeveel exemplaren wilt u bestellen? ");
            Bestelling<Boek> boekBestelling = new Bestelling<Boek>(boeken[boekIndex], aantal);
            bestellingenBoek.Add(boekBestelling); // Add the order to the list
            boekBestelling.Bestel();
            Console.WriteLine("Boekbestelling geplaatst.");

        }
        else
        {
            Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
        }
    }

    static void BestelTijdschrift()
    {
        Console.WriteLine("Beschikbare tijdschriften:");
        for (int i = 0; i < tijdschriften.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tijdschriften[i]}");
        }

        int tijdschriftIndex = GetIntegerInput("Selecteer een tijdschrift om te bestellen (geef het nummer in): ") - 1;
        if (tijdschriftIndex >= 0 && tijdschriftIndex < tijdschriften.Count)
        {
            int aantal = GetIntegerInput("Hoeveel exemplaren wilt u bestellen? ");
            Bestelling<Tijdschrift> tijdschriftBestelling = new Bestelling<Tijdschrift>(tijdschriften[tijdschriftIndex], aantal, tijdschriften[tijdschriftIndex].Verschijningsperiode);
            bestellingenTijdschrift.Add(tijdschriftBestelling); // Add the order to the list
            tijdschriftBestelling.Bestel();
            Console.WriteLine("Tijdschriftbestelling geplaatst.");
        }
        else
        {
            Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
        }
    }
    static void ToonBestellingen()
    {
        Console.WriteLine("Bestellingen:");

        // Loop through the list of book orders
        foreach (var bestelling in bestellingenBoek)
        {
            Console.WriteLine($"Boek: {bestelling.Item.Naam}, Aantal: {bestelling.Aantal}, Totale prijs: {bestelling.TotalePrijs:C}");
        }

        // Loop through the list of magazine orders
        foreach (var bestelling in bestellingenTijdschrift)
        {
            Console.WriteLine($"Tijdschrift: {bestelling.Item.Naam} ({bestelling.Item.Verschijningsperiode}), Aantal: {bestelling.Aantal}, Totale prijs: {bestelling.TotalePrijs:C}");
        }
    }

    static void BoekBesteldEventHandler(string bericht)
    {
        Console.WriteLine(bericht);
    }


    static int GetIntegerInput(string prompt)
    {
        int input;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Voer een geldig getal in.");
            }
        }
    }
}
