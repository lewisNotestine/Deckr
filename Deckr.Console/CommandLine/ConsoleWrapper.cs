using System;
using Deckr.BLL.Cards;
using Deckr.Extensions;

namespace Deckr.Console.CommandLine
{
    public interface IConsoleWrapper
    {
        string TakeUserInput();
        void PrintDeck(Deck deck);

        void PrintUsage(bool deckExists);

        void PrintDeckMissing();

        void PrintInvalidOperation();

        void PrintAction(CmdLineAction action);
    }

    internal class ConsoleWrapper : IConsoleWrapper
    {
        private const int ROW_SIZE = 13;
		public const string CREATEDECK = "1";
		public const string SORTDECK = "2";
		public const string SHUFFLEDECK = "3";
		public const string EXIT = "4";

        public void PrintDeck(Deck deck)
        {
			System.Console.Write("\n Current Deck \n ----------------\n");
            int rowCount = 0;
			foreach (var card in deck.Cards)
			{
                
                if (rowCount >= ROW_SIZE)
                {
                    System.Console.WriteLine();
                    rowCount = 0;
                }
				System.Console.Write($"{card.GetSymbol()} ");
                rowCount++;
			}
        }

        public void PrintDeckMissing()
        {
            System.Console.WriteLine("\nmust create a deck first\n");
        }

        public void PrintInvalidOperation()
        {
            System.Console.WriteLine("\nInvalid input!\n");
        }

        public void PrintUsage(bool deckExists)
		{
			System.Console.Write(
$@"
----------------
Options: 
----------------

{CREATEDECK}. Create a deck

");

			if (deckExists)
			{
				System.Console.Write(
$@"{SORTDECK}. Sort the deck

{SHUFFLEDECK}. Shuffle the deck 

");
			}

			System.Console.Write(
$@"{EXIT}. Exit

");
		}

        public void PrintAction(CmdLineAction action)
        {
            System.Console.WriteLine($"\n{action.GetDescription()}\n");
        }

        public string TakeUserInput()
        {
            return System.Console.ReadKey().KeyChar.ToString();
        }
    }
}
