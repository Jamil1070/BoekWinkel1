using System;
using System.Collections.Generic;

// Enum voor de verschijningsperiode van tijdschriften
enum Verschijningsperiode
{
    Dagelijks,
    Wekelijks,
    Maandelijks
}

// Basisklasse Boek
class Boek
{
    private string isbn;
    private string naam;
    private string uitgever;
    private decimal prijs;

    public Boek(string isbn, string naam, string uitgever, decimal prijs)
    {
        Isbn = isbn;
        Naam = naam;
        Uitgever = uitgever;
        Prijs = prijs;
    }

    public string Isbn
    {
        get { return isbn; }
        set { isbn = value; }
    }

    public string Naam
    {
        get { return naam; }
        set { naam = value; }
    }

    public string Uitgever
    {
        get { return uitgever; }
        set { uitgever = value; }
    }

    public decimal Prijs
    {
        get { return prijs; }
        set
        {
            if (value >= 5 && value <= 50)
            {
                prijs = value;
            }
            else
            {
                throw new ArgumentException("Prijs moet tussen 5€ en 50€ liggen.");
            }
        }
    }

    public virtual string Lees()
    {
        return $"Lees het boek '{Naam}' van {Uitgever}";
    }

    public override string ToString()
    {
        return $"ISBN: {Isbn}, Naam: {Naam}, Uitgever: {Uitgever}, Prijs: {Prijs:C}";
    }
}

