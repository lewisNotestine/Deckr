using System;
using Xunit;
using Deckr.Web.Controllers;
using Moq;
using Deckr.Web.Session;
using System.Linq;
using System.Collections.Generic;
using Deckr.BLL.Cards;
using Deckr.Web.Models.Home;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Deckr.Web.Tests.Controllers
{
    public class HomeControllerTests : IDisposable
    {
        private Mock<IDeckr> DeckrMock;
        private Mock<ISessionWrapper> SessionMock;
        
        public HomeControllerTests()
        {
            DeckrMock = new Mock<IDeckr>(MockBehavior.Strict);
            SessionMock = new Mock<ISessionWrapper>(MockBehavior.Strict);
        }

        public void Dispose()
        {
            DeckrMock.Verify();
            SessionMock.Verify();
        }

        [Fact]
        public void GetCards_ReturnsDeckModelAfterStoringInSession()
        {
            var cards = new List<Card>()
            {
                Card.Get(Rank.Deuce, Suit.Spades),
                Card.Get(Rank.Ace, Suit.Diamonds)
            };
            var deck = new Deck(cards);

            DeckrMock.Setup(d => d.GetDeck()).Returns(deck).Verifiable();
            SessionMock.Setup(s => s.StoreDeckInTempData(It.IsAny<DeckModel>(), It.IsAny<ITempDataDictionary>())).Verifiable();

            var controllerUnderTest = new HomeController(DeckrMock.Object, SessionMock.Object);

            var result = controllerUnderTest.GetCards();
            Assert.True(result.Value is DeckModel);

            var deckResult = result.Value as DeckModel;
            Assert.True(deckResult.Cards.Count() == 2);
            Assert.True(deckResult.Cards.Any(c => c.Rank == "Deuce" && c.Suit == "Spades"));
            Assert.True(deckResult.Cards.Any(c => c.Rank == "Ace" && c.Suit == "Diamonds"));                        
        }

        [Fact]
        public void UpdateCards_Shuffles()
        {
            var cards = new CardModel[]
            {
                new CardModel("Diamonds", "♦", "Ace", "A"),
                new CardModel("Diamonds", "♦", "Deuce", "2")
            };
            var dModel = new DeckModel(cards);

            SessionMock.Setup(s => s.GetDeckFromTempData(It.IsAny<ITempDataDictionary>(), It.IsAny<Func<DeckModel>>()))
                       .Returns(dModel)
                       .Verifiable();

            DeckrMock.Setup(d => d.ShuffleDeck(It.IsAny<Deck>())).Verifiable();
            SessionMock.Setup(s => s.StoreDeckInTempData(It.IsAny<DeckModel>(), It.IsAny<ITempDataDictionary>())).Verifiable();

            var controllerUnderTest = new HomeController(DeckrMock.Object, SessionMock.Object);

            var result = controllerUnderTest.UpdateCards("Shuffle");
            Assert.True(result.Value is DeckModel);

			var deckResult = result.Value as DeckModel;
			Assert.True(deckResult.Cards.Count() == 2);
			Assert.True(deckResult.Cards.Any(c => c.Rank == "Deuce" && c.Suit == "Diamonds"));
			Assert.True(deckResult.Cards.Any(c => c.Rank == "Ace" && c.Suit == "Diamonds"));
		}

        [Fact]
        public void UpdateCards_Sorts()
        {
			var cards = new CardModel[]
			{
				new CardModel("Diamonds", "♦", "Ace", "A"),
				new CardModel("Diamonds", "♦", "Deuce", "2")
			};
			var dModel = new DeckModel(cards);

			SessionMock.Setup(s => s.GetDeckFromTempData(It.IsAny<ITempDataDictionary>(), It.IsAny<Func<DeckModel>>()))
					   .Returns(dModel)
					   .Verifiable();

            DeckrMock.Setup(d => d.SortDeck(It.IsAny<Deck>())).Verifiable();
			SessionMock.Setup(s => s.StoreDeckInTempData(It.IsAny<DeckModel>(), It.IsAny<ITempDataDictionary>())).Verifiable();

			var controllerUnderTest = new HomeController(DeckrMock.Object, SessionMock.Object);

			var result = controllerUnderTest.UpdateCards("Sort");
			Assert.True(result.Value is DeckModel);

			var deckResult = result.Value as DeckModel;
			Assert.True(deckResult.Cards.Count() == 2);
			Assert.True(deckResult.Cards.Any(c => c.Rank == "Deuce" && c.Suit == "Diamonds"));
			Assert.True(deckResult.Cards.Any(c => c.Rank == "Ace" && c.Suit == "Diamonds"));
        }

        [Fact]
        public void UpdateCards_Invalid_ThrowsArgumentException()
        {
             var controllerUnderTest = new HomeController(DeckrMock.Object, SessionMock.Object);

            Assert.Throws<ArgumentException>(() => controllerUnderTest.UpdateCards("Blarf"));
        }
    }
}
