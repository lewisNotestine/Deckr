using System;
using Deckr.BLL.CardHandling;
using Xunit;
using System.Linq;

namespace Deckr.Tests.BLL.CardHandling
{
    public class DeckFactoryTests
    {
        [Fact]
        public void GeneratesAppropriateNumberOfCards()
        {
            var factoryUnderTest = new DeckFactory();
            var deck = factoryUnderTest.GenerateDeck();

            Assert.Equal(52, deck.Cards.Count);
        }

        [Fact]
        public void GeneratesAppropriateNumberOfEachSuit()
        {
			var factoryUnderTest = new DeckFactory();
			var deck = factoryUnderTest.GenerateDeck();

            Assert.Equal(13, deck.Cards.GroupBy(c => c.Rank).Count());
        }

        [Fact]
        public void GeneratesAppropriateNumberForEachRank()
        {
			var factoryUnderTest = new DeckFactory();
			var deck = factoryUnderTest.GenerateDeck();

			Assert.Equal(4, deck.Cards.GroupBy(c => c.Suit).Count());
        }
    }
}
