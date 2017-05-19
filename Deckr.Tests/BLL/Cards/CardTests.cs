using System;
using Deckr.BLL.Cards;
using Xunit;

namespace Deckr.Tests.BLL.Cards
{

    public class CardTests
    {
        [Theory]
        [InlineData(Rank.Deuce, Suit.Spades, Rank.Three, Suit.Spades, false)]
        [InlineData(Rank.Deuce, Suit.Spades, Rank.Deuce, Suit.Diamonds, false)]
        [InlineData(Rank.Deuce, Suit.Spades, Rank.Deuce, Suit.Spades, true)]
        public void EqualityInequality_ComparesCorrectly(Rank cardOneRank, Suit cardOneSuit, Rank cardTwoRank, Suit cardTwoSuit, bool expectedMatch)
        {
            var lowCard = Card.Get(cardOneRank, cardOneSuit);
            var highCard = Card.Get(cardTwoRank, cardTwoSuit);

            Assert.Equal(expectedMatch, lowCard == highCard);
            Assert.Equal(!expectedMatch, lowCard != highCard);
            Assert.Equal(expectedMatch, lowCard.Equals(highCard));
            Assert.Equal(!expectedMatch, !lowCard.Equals(highCard));
        }


        [Theory]
        [InlineData(Rank.Deuce, Suit.Spades, 1)]
        [InlineData(Rank.Ace, Suit.Spades, 13)]
        [InlineData(Rank.Deuce, Suit.Hearts, 14)]
        [InlineData(Rank.Ace, Suit.Hearts, 26)]
        [InlineData(Rank.Deuce, Suit.Clubs, 27)]
        [InlineData(Rank.Ace, Suit.Clubs, 39)]
        [InlineData(Rank.Deuce, Suit.Diamonds, 40)]
        [InlineData(Rank.Ace, Suit.Diamonds, 52)]
        public void DefaultOrder_IsCalculatedCorrectly(Rank rank, Suit suit, int expectedOrder)
        {
            var card = Card.Get(rank, suit);

            Assert.Equal(expectedOrder, card.DefaultOrder);
        }

        [Theory]
        [InlineData(20, 4)]
        [InlineData(10, 6)]
        [InlineData(0, 1)]
        [InlineData(2, 0)]
        public void ConstructsWithOutOfBoundsInput_Throws(int rank, int suit)
        {
            Assert.Throws<InvalidOperationException>(() => { var card = Card.Get((Rank)rank, (Suit)suit); });            
        }



	}
}