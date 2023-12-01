namespace CardsGame.Core.Classes
{
    public class Deck
    {
        public readonly List<Card> cards;
        private readonly string[] ranks = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        private readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        public Deck()
        {
            cards = InitializeDeck();
        }

        public void Shuffle()
        {
            Random random = new Random();
            int deckSize = cards.Count;

            for (int currentIndex = deckSize - 1; currentIndex > 0; currentIndex--)
            {
                int randomIndex = random.Next(0, currentIndex + 1);
                SwapCards(currentIndex, randomIndex);
            }
        }

        public Card Deal()
        {
            if (cards.Count > 0)
            {
                Card cardToDeal = cards[0];
                cards.RemoveAt(0);
                return cardToDeal;
            }
            else
            {
                throw new InvalidOperationException("The deck is empty.");
            }
        }

        private List<Card> InitializeDeck()
        {
            List<Card> deck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card(suit, rank));
                }
            }

            return deck;
        }

        private void SwapCards(int index1, int index2)
        {
            Card temp = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = temp;
        }
    }
}
