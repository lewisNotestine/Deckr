using System;
using Deckr.Console.CommandLine;
using Moq;
using Xunit;
using System.Collections.Generic;
using Deckr.BLL.Cards;
using System.Linq;

namespace Deckr.Console.Tests.CommandLine
{
    public class CmdLineTests : IDisposable
    {
        private Mock<IDeckr> DeckrMock;
        private Mock<IConsoleWrapper> ConsoleWrapperMock;

        public CmdLineTests()
        {
            DeckrMock = new Mock<IDeckr>(MockBehavior.Strict);
            ConsoleWrapperMock = new Mock<IConsoleWrapper>(MockBehavior.Strict);
        }

        public void Dispose()
        {
            DeckrMock.Verify();
            ConsoleWrapperMock.Verify();
        }

        [Fact]
        public void DisplaysOutput_PrintsUsageWithNoDeckOnStartup()
        {
            var cmdLineUnderTest = new CmdLine(DeckrMock.Object, ConsoleWrapperMock.Object);

            ConsoleWrapperMock.Setup(p => p.PrintUsage(false));
            cmdLineUnderTest.DisplayOptions();
        }

        [Fact]
        public void DisplaysOutput_PrintsUsageWithFullOptionsAfterDeckCreation()
        {
			var cmdLineUnderTest = new CmdLine(DeckrMock.Object, ConsoleWrapperMock.Object);

			ConsoleWrapperMock.Setup(p => p.PrintUsage(true));
            DeckrMock.Setup(d => d.GetDeck()).Returns(new Deck(new List<Card>()));
            ConsoleWrapperMock.Setup(p => p.PrintAction(CmdLineAction.CreateDeck)).Verifiable();
            ConsoleWrapperMock.Setup(p => p.PrintDeck(It.IsAny<Deck>())).Verifiable();

            cmdLineUnderTest.ExecuteInstructions(CmdLineAction.CreateDeck);
			cmdLineUnderTest.DisplayOptions();
        }

        [Theory]
        [InlineData(ConsoleWrapper.CREATEDECK, CmdLineAction.CreateDeck)]
        [InlineData(ConsoleWrapper.SHUFFLEDECK, CmdLineAction.Invalid)]
        [InlineData(ConsoleWrapper.SORTDECK, CmdLineAction.Invalid)]
        [InlineData(ConsoleWrapper.EXIT, CmdLineAction.Quit)]
        public void TakesInstructions_NoDeck(string inputKey, CmdLineAction expectedResult)
        {
            var cmdLineUnderTest = new CmdLine(DeckrMock.Object, ConsoleWrapperMock.Object);
            var invalidInstructions = new string[] { ConsoleWrapper.SHUFFLEDECK, ConsoleWrapper.SORTDECK };
            if (invalidInstructions.Contains(inputKey))
            {
                ConsoleWrapperMock.Setup(c => c.PrintDeckMissing()).Verifiable();     
            }

            ConsoleWrapperMock.Setup(c => c.TakeUserInput()).Returns(inputKey).Verifiable();
            var resultingAction = cmdLineUnderTest.TakeInstructions();

            Assert.Equal(expectedResult, resultingAction);
        }


		[Theory]
		[InlineData(ConsoleWrapper.CREATEDECK, CmdLineAction.CreateDeck)]
        [InlineData(ConsoleWrapper.SHUFFLEDECK, CmdLineAction.ShuffleDeck)]
		[InlineData(ConsoleWrapper.SORTDECK, CmdLineAction.SortDeck)]
		[InlineData(ConsoleWrapper.EXIT, CmdLineAction.Quit)]
        public void TakesInstructions_HasDeck(string inputKey, CmdLineAction expectedResult)
        {
			var cmdLineUnderTest = new CmdLine(DeckrMock.Object, ConsoleWrapperMock.Object);

			ConsoleWrapperMock.Setup(p => p.PrintAction(CmdLineAction.CreateDeck)).Verifiable();
			ConsoleWrapperMock.Setup(p => p.PrintDeck(It.IsAny<Deck>())).Verifiable();
            DeckrMock.Setup(d => d.GetDeck()).Returns(new Deck(new List<Card>()));
            cmdLineUnderTest.ExecuteInstructions(CmdLineAction.CreateDeck);

			ConsoleWrapperMock.Setup(c => c.TakeUserInput()).Returns(inputKey).Verifiable();
			var resultingAction = cmdLineUnderTest.TakeInstructions();

			Assert.Equal(expectedResult, resultingAction);
        }


        [Fact]
        public void TakesInstructions_DeckCreated_Shuffles()
        {
            var cmdLineUnderTest = new CmdLine(DeckrMock.Object, ConsoleWrapperMock.Object);

            ConsoleWrapperMock.Setup(c => c.PrintAction(CmdLineAction.ShuffleDeck)).Verifiable();
            DeckrMock.Setup(d => d.ShuffleDeck(It.IsAny<Deck>())).Verifiable();
            ConsoleWrapperMock.Setup(p => p.PrintDeck(It.IsAny<Deck>())).Verifiable();

            cmdLineUnderTest.ExecuteInstructions(CmdLineAction.ShuffleDeck);
        }

		[Fact]
		public void TakesInstructions_DeckCreated_Sorts()
		{
			var cmdLineUnderTest = new CmdLine(DeckrMock.Object, ConsoleWrapperMock.Object);

			ConsoleWrapperMock.Setup(c => c.PrintAction(CmdLineAction.SortDeck)).Verifiable();
			DeckrMock.Setup(d => d.SortDeck(It.IsAny<Deck>())).Verifiable();
			ConsoleWrapperMock.Setup(p => p.PrintDeck(It.IsAny<Deck>())).Verifiable();

			cmdLineUnderTest.ExecuteInstructions(CmdLineAction.SortDeck);
		}
    }
}
