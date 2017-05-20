using System;
using Deckr.BLL.CardHandling;
using Xunit;
using Moq;
using System.Collections.Generic;
using Deckr.BLL.Cards;

namespace Deckr.Tests.BLL.CardHandling
{
    public class CardArrangerTests : IDisposable
    {
        private readonly Mock<IComparer<Card>> CardSorterMock;
        private readonly Mock<IComparer<Card>> CardShufflerMock;

        public CardArrangerTests()
        {
            CardSorterMock = new Mock<IComparer<Card>>(MockBehavior.Strict);
            CardShufflerMock = new Mock<IComparer<Card>>(MockBehavior.Strict);
        }

        public void Dispose()
        {
            CardSorterMock.Verify();
            CardShufflerMock.Verify();
        }

        [Fact]
        public void Shuffles_ReturnsAShuffledDeck()
        {
            var dummyCardSet = new HashSet<Card>()
            {
                Card.Get(Rank.Four, Suit.Spades),
                Card.Get(Rank.Three, Suit.Spades),
                Card.Get(Rank.Deuce, Suit.Spades)
            };

            var deck = new Deck(dummyCardSet);

            CardShufflerMock.Setup(c => c.Compare(It.IsAny<Card>(), It.IsAny<Card>())).Returns(-1).Verifiable();
                                
            var arrangerUnderTest = new CardArranger(() => CardShufflerMock.Object, CardSorterMock.Object);
            var outputDeck = arrangerUnderTest.ShuffleDeck(deck);

            Assert.Collection<Card>(outputDeck.Cards, c => Assert.True(c.Rank == Rank.Four), d => Assert.True(d.Rank == Rank.Three), e => Assert.True(e.Rank == Rank.Deuce));                                    
        }

        [Fact]
        public void Shuffles_ReturnsDifferentlyShuffledDesks_Successively()
        {
			var dummyCardSet = new HashSet<Card>()
			{
                Card.Get(Rank.Six, Suit.Spades),
				Card.Get(Rank.Five, Suit.Spades),
                Card.Get(Rank.Four, Suit.Spades),
				Card.Get(Rank.Three, Suit.Spades),
				Card.Get(Rank.Deuce, Suit.Spades)
			};

			var deck = new Deck(dummyCardSet);

			CardShufflerMock.Setup(c => c.Compare(It.IsAny<Card>(), It.IsAny<Card>())).Returns(1).Verifiable();

			var arrangerUnderTest = new CardArranger(() => CardShufflerMock.Object, CardSorterMock.Object);
			var outputDeck = arrangerUnderTest.ShuffleDeck(deck);

			Assert.Collection<Card>(outputDeck.Cards, a => Assert.Equal(a.Rank,Rank.Six), b => Assert.Equal(b.Rank, Rank.Five), c => Assert.Equal(c.Rank, Rank.Four), d => Assert.Equal(d.Rank, Rank.Three), e => Assert.Equal(e.Rank, Rank.Deuce));

            CardShufflerMock.Setup(c => c.Compare(It.IsAny<Card>(), It.IsAny<Card>())).Returns(-1).Verifiable();
            var secondOutput = arrangerUnderTest.ShuffleDeck(deck);

            Assert.Collection<Card>(secondOutput.Cards, a => Assert.Equal(Rank.Deuce, a.Rank), b => Assert.Equal(Rank.Three, b.Rank), c => Assert.Equal(Rank.Four, c.Rank), d => Assert.Equal(Rank.Five, d.Rank), e => Assert.Equal(e.Rank,Rank.Six));

		}

        [Fact]
        public void Sorts_ReturnsASortedDeck()
        {
			var dummyCardSet = new HashSet<Card>()
			{
				Card.Get(Rank.Four, Suit.Spades),
				Card.Get(Rank.Three, Suit.Spades),
				Card.Get(Rank.Deuce, Suit.Spades)
			};

			var deck = new Deck(dummyCardSet);

			CardSorterMock.Setup(c => c.Compare(It.IsAny<Card>(), It.IsAny<Card>())).Returns(1).Verifiable();

			var arrangerUnderTest = new CardArranger(() => CardShufflerMock.Object, CardSorterMock.Object);
			var outputDeck = arrangerUnderTest.SortDeck(deck);

            Assert.Collection<Card>(outputDeck.Cards, c => Assert.True(c.Rank == Rank.Deuce), d => Assert.True(d.Rank == Rank.Three), e => Assert.True(e.Rank == Rank.Four));

		}
    }
}
