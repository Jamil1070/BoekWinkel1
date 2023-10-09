class Bestelling<T>
{
    public delegate void BestellingEventHandler(string bericht);

    public event BestellingEventHandler BoekBesteldEvent;


    private static int volgnummerCounter = 1;

    private readonly int id;
    public T Item { get; }
    public DateTime Datum { get; }
    public int Aantal { get; }
    public Verschijningsperiode? Periode { get; }

    public Bestelling(T item, int aantal, Verschijningsperiode? periode = null)
    {
        id = volgnummerCounter++;
        Item = item;
        Datum = DateTime.Now;
        Aantal = aantal;
        Periode = periode;
    }
    public decimal TotalePrijs
    {
        get
        {
            if (Item is Boek boek)
            {
                return boek.Prijs * Aantal;
            }
            else
            {
                return 0; // Geef 0 terug voor tijdschriften (of andere onbekende typen)
            }
        }
    }
    public void bestel()
    {
        string isbn = (Item is Boek boek) ? boek.Isbn : null;

        Console.WriteLine($"Bestelling {id} bevestigd: {Aantal} exemplaren van '{Item}' ({Periode}) zijn besteld. Totale prijs: {TotalePrijs:C}");
    }


    public Tuple<string, int, decimal> Bestel()
    {
        string isbn = (Item is Boek boek) ? boek.Isbn : null;
        decimal totalePrijs = (Item is Boek Boek) ? Boek.Prijs * Aantal : 0;

        Console.WriteLine($"Bestelling {id} bevestigd: {Aantal} exemplaren van '{Item}' ({Periode}) zijn besteld. Totale prijs: {TotalePrijs:C}");
        return Tuple.Create(isbn, Aantal, totalePrijs);
        BoekBesteldEvent?.Invoke($"Bestelling Geplaatst!");
    }
}

