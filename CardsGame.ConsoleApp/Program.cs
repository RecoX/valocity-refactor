using CardsGame.Core.Classes;

class Program
{
    static void Main(string[] args)
    {
        Deck deck = new Deck();

        deck.Shuffle();

        for (int i = 0; i < 5; i++)
        {
            Card card = deck.Deal();
            Console.WriteLine($"Received: {card.Rank} of {card.Suit}");
        }

        Console.ReadLine();
    }
}
