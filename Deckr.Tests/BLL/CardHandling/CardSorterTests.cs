using System;
using Deckr.BLL.CardHandling;
using Deckr.BLL.Cards;
using Xunit;

namespace Deckr.Tests.BLL.CardHandling
{
    public class CardSorterTests
    {   
        [Theory]
        [InlineData(Rank.Deuce, Suit.Spades, Rank.Three, Suit.Spades, -1)]
        [InlineData(Rank.Three, Suit.Spades, Rank.Deuce, Suit.Spades, 1)]
        [InlineData(Rank.Three, Suit.Diamonds, Rank.Three, Suit.Diamonds, 0)]
        [InlineData(Rank.Ace, Suit.Clubs, Rank.Ace, Suit.Diamonds, -1)]
        [InlineData(Rank.King, Suit.Hearts, Rank.King, Suit.Spades, 1)]
        public void Sorts(Rank rank1, Suit suit1, Rank rank2, Suit suit2, int expectedOutcome)
        {
            var card1 = Card.Get(rank1, suit1);
            var card2 = Card.Get(rank2, suit2);
            var sorterUnderTest = new CardSorter();

            Assert.Equal(expectedOutcome, sorterUnderTest.Compare(card1, card2));
        }
    }
}
