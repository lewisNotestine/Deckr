using System;
using System.Collections.Generic;
using System.Linq;
using Deckr.BLL.Cards;
using Deckr.Web.Extensions;
using Deckr.Web.Models.Home;
using Xunit;

namespace Deckr.Web.Tests.Extensions
{
    public class ModelExtensionsTests
    {
        [Fact]
        public void GetDeckModelFromDeck_GetsDeckModel()
        {
			var cards = new List<Card>()
			{
				Card.Get(Rank.Deuce, Suit.Spades),
				Card.Get(Rank.Ace, Suit.Diamonds)
			};
			var deck = new Deck(cards);

            var deckModel = deck.GetDeckModel();

			Assert.True(deckModel.Cards.Count() == 2);
			Assert.True(deckModel.Cards.Any(c => c.Rank == "Deuce" && c.Suit == "Spades"));
			Assert.True(deckModel.Cards.Any(c => c.Rank == "Ace" && c.Suit == "Diamonds"));
		}

        [Fact]
        public void GetDeckModelFromDeck_NullInput_ThrowsArgumentNull()
        {
            Deck deck = null;

            Assert.Throws<ArgumentNullException>(() => deck.GetDeckModel());
        }

        [Fact]
        public void GetDeckFromDeckModel_GetsDeck()
        {
			var cards = new CardModel[]
			{
				new CardModel("Diamonds", "♦", "Ace", "A"),
				new CardModel("Diamonds", "♦", "Deuce", "2")
			};
			var dModel = new DeckModel(cards);
            var deck = dModel.GetDeck();

            Assert.True(deck.Cards.Count == 2);
            Assert.True(deck.Cards.Any(c => c.Rank == Rank.Ace && c.Suit == Suit.Diamonds));
            Assert.True(deck.Cards.Any(c => c.Rank == Rank.Deuce && c.Suit == Suit.Diamonds));
        }

        [Fact]
        public void GetDeckFromDeckmodel_NullInput_ThrowsArgumentNull()
        {
            DeckModel dModel = null;

            Assert.Throws<ArgumentNullException>(() => dModel.GetDeck());
        }

    }
}
