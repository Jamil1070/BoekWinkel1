class Tijdschrift : Boek
{
    public Verschijningsperiode Verschijningsperiode { get; set; }

    public Tijdschrift(string isbn, string naam, string uitgever, decimal prijs, Verschijningsperiode verschijningsperiode)
        : base(isbn, naam, uitgever, prijs)
    {
        Verschijningsperiode = verschijningsperiode;
    }

    public override string Lees()
    {
        return $"Lees het tijdschrift '{Naam}' ({Verschijningsperiode}) van {Uitgever}";
    }
}