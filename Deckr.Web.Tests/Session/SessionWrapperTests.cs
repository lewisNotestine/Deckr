using System;
using System.Linq;
using Deckr.Web.Models.Home;
using Deckr.Web.Session;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace Deckr.Web.Tests.Session
{
    public class SessionWrapperTests
    {
        private const string DECK_KEY = "Deck";

        [Fact]
        public void PutsValueInSession_NotAlreadyThere_Creates()
        {
            var tempDataMock = new Mock<ITempDataDictionary>(MockBehavior.Strict);
            var sessionWrapperUnderTest = new SessionWrapper();
			var cards = new CardModel[]
			{
				new CardModel("Diamonds", "♦", "Ace", "A"),
				new CardModel("Diamonds", "♦", "Deuce", "2")
			};
			var dModel = new DeckModel(cards);

            tempDataMock.Setup(t => t.ContainsKey(DECK_KEY)).Returns(false).Verifiable();
            tempDataMock.Setup(t => t.Add(DECK_KEY, It.IsAny<string>())).Verifiable();

            sessionWrapperUnderTest.StoreDeckInTempData(dModel, tempDataMock.Object);
            tempDataMock.Verify();
        }

        [Fact]
        public void PutsValueInSession_AlreadyThere_Overwrites()
        {
            var serialized = "{\"Cards\":[{\"Suit\":\"Diamonds\",\"SuitSymbol\":\"♦\",\"Rank\":\"Ace\",\"RankSymbol\":\"A\"},{\"Suit\":\"Diamonds\",\"SuitSymbol\":\"♦\",\"Rank\":\"Deuce\",\"RankSymbol\":\"2\"}]}";
			var tempDataMock = new Mock<ITempDataDictionary>(MockBehavior.Strict);
			var sessionWrapperUnderTest = new SessionWrapper();
			var cards = new CardModel[]
			{
				new CardModel("Diamonds", "♦", "Ace", "A"),
				new CardModel("Diamonds", "♦", "Deuce", "2")
			};
			var dModel = new DeckModel(cards);

			tempDataMock.Setup(t => t.ContainsKey(DECK_KEY)).Returns(true).Verifiable();
            tempDataMock.SetupSet(t => t[DECK_KEY] = serialized).Verifiable();

			sessionWrapperUnderTest.StoreDeckInTempData(dModel, tempDataMock.Object);
			tempDataMock.Verify();
        }

        [Fact]
        public void GetsValueFromSession_Exists_ReturnsDeserialized()
        {
            var tempDataMock = new Mock<ITempDataDictionary>(MockBehavior.Strict);
            var serialized = "{\"Cards\":[{\"Suit\":\"Diamonds\",\"SuitSymbol\":\"♦\",\"Rank\":\"Ace\",\"RankSymbol\":\"A\"},{\"Suit\":\"Diamonds\",\"SuitSymbol\":\"♦\",\"Rank\":\"Deuce\",\"RankSymbol\":\"2\"}]}";
            			
            var sessionWrapperUnderTest = new SessionWrapper();
            tempDataMock.Setup(t => t.ContainsKey(DECK_KEY)).Returns(true).Verifiable();
            tempDataMock.Setup(t => t[DECK_KEY]).Returns(serialized).Verifiable();

            var outputDeck = sessionWrapperUnderTest.GetDeckFromTempData(tempDataMock.Object, () => { throw new InvalidOperationException("this shouldn't get called"); });

            Assert.True(outputDeck.Cards.Any(c => c.Rank == "Ace" && c.Suit == "Diamonds"));
            Assert.True(outputDeck.Cards.Any(c => c.Rank == "Deuce" && c.Suit == "Diamonds"));
        }

        [Fact]
        public void GetsValueFromSession_DoesNotExist_GetsFromElseWhere()
        {
			var tempDataMock = new Mock<ITempDataDictionary>(MockBehavior.Strict);			

			var cards = new CardModel[]
			{
				new CardModel("Diamonds", "♦", "Ace", "A"),
				new CardModel("Diamonds", "♦", "Deuce", "2")
			};
			var dModel = new DeckModel(cards);

			var sessionWrapperUnderTest = new SessionWrapper();
			tempDataMock.Setup(t => t.ContainsKey(DECK_KEY)).Returns(false).Verifiable();			

            var outputDeck = sessionWrapperUnderTest.GetDeckFromTempData(tempDataMock.Object, () => { return dModel; });

			Assert.True(outputDeck.Cards.Any(c => c.Rank == "Ace" && c.Suit == "Diamonds"));
			Assert.True(outputDeck.Cards.Any(c => c.Rank == "Deuce" && c.Suit == "Diamonds"));
        }
    }

}
