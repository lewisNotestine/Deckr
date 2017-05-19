using System;
using Deckr.BLL.CardHandling;
using Deckr.BLL.Cards;
using Xunit;

namespace Deckr.Tests.BLL.CardHandling
{
    public class CardShufflerTests 
    {              
        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(2, 1, 1)]
        [InlineData(1, 1, 0)]
        public void TestShuffles(int seed1, int seed2, int expectedOutcome)
        {
            Func<int> one = () => seed1;
            Func<int> two = () => seed2;

            var cardOne = Card.Get(Rank.Deuce, Suit.Spades);
            var cardTwo = Card.Get(Rank.Ace, Suit.Diamonds);

            var shufflerUnderTest = new CardShuffler(one, two);

            var result = shufflerUnderTest.Compare(cardOne, cardTwo);

            Assert.Equal(expectedOutcome, result);
        }
    }
}
