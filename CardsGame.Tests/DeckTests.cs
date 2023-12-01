using Xunit;
using CardsGame.Core.Classes;

namespace CardsGame.Tests
{
    public class DeckTests
    {
        [Fact]
        public void NewDeck_IsNotEmpty()
        {
            Deck deck = new Deck();

            Assert.NotEmpty(deck.cards);
        }

        [Fact]
        public void Shuffle_ShuffledDeckIsDifferent()
        {
            Deck deck = new Deck();
            List<Card> originalDeck = new List<Card>(deck.cards);

            deck.Shuffle();

            Assert.NotEqual(originalDeck, deck.cards);
        }

        [Fact]
        public void Deal_ReturnsTopCard()
        {
            Deck deck = new Deck();

            Card dealtCard = deck.Deal();

            Assert.NotNull(dealtCard);
        }

        [Fact]
        public void Deal_EmptyDeck_ThrowsException()
        {
            Deck deck = new Deck();

            while (deck.cards.Count > 0)
            {
                deck.Deal();
            }

            Assert.Throws<InvalidOperationException>(() => deck.Deal());
        }
    }
}
