using System;
using Deckr.BLL.CardHandling;
using Deckr.BLL.Cards;
using Xunit;

namespace Deckr.Tests.BLL.CardHandling
{
    public class CardShufflerTests 
    {              
        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, -1)]     
        public void TestShuffles(int seed, int expectedOutcome)
        {           
            var cardOne = Card.Get(Rank.Deuce, Suit.Spades);
            var cardTwo = Card.Get(Rank.Ace, Suit.Diamonds);

            var shufflerUnderTest = new CardShuffler(seed);

            var result = shufflerUnderTest.Compare(cardOne, cardTwo);

            Assert.Equal(expectedOutcome, result);
        }
    }
}
