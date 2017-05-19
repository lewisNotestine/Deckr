using System;
using Deckr;
using Deckr.BLL.Cards;

namespace Deckr.Console.CommandLine
{
    public class CmdLine
    {
        private const string CREATEDECK = "1";
        private const string SORTDECK = "2";
        private const string SHUFFLEDECK = "3";
        private const string EXIT = "4";

        private readonly IDeckr Deckr;
        private readonly DeckPrinter Printer;

        private Deck CurrentDeck;

        public CmdLine(IDeckr deckr, DeckPrinter printer)
        {
            Deckr = deckr;
            Printer = printer;
        }

        public void PrintUsage()
        {
            System.Console.Write(
$@"
----------------
Usage: 
{CREATEDECK}. Create a deck
{SORTDECK}. Sort the deck (once created)
{SHUFFLEDECK}. Shuffle the deck (once created)
{EXIT}. Exit 

");
        }

        public CmdLineAction TakeInstructions()
        {
            var instruction = System.Console.ReadKey().KeyChar.ToString();
            switch (instruction)
            {
                case CREATEDECK:
                    return CmdLineAction.CreateDeck;
                case SORTDECK:
                    return CmdLineAction.SortDeck;             
                case SHUFFLEDECK:
                    return CmdLineAction.ShuffleDeck;
                case EXIT:
                    return CmdLineAction.Quit;
                default:
                    return CmdLineAction.Invalid;                    
            }
        }

        public void ExecuteInstructions(CmdLineAction action)
        {
            switch (action)
            {
                case CmdLineAction.CreateDeck:
					System.Console.WriteLine($"\nCreating Deck!\n");
					CurrentDeck = Deckr.GetDeck();
                    Printer.PrintDeck(CurrentDeck);
					break;
                case CmdLineAction.SortDeck:
					System.Console.WriteLine($"\nSorting Deck!\n");					
					CurrentDeck = Deckr.SortDeck(CurrentDeck);
                    Printer.PrintDeck(CurrentDeck);
					break;
                case CmdLineAction.ShuffleDeck:
					System.Console.WriteLine($"\nShuffling Deck!\n");
					CurrentDeck = Deckr.ShuffleDeck(CurrentDeck);
                    Printer.PrintDeck(CurrentDeck);
                    break;
                case CmdLineAction.Invalid:
                    System.Console.WriteLine($"Invalid Input.");

                    break;
                default:
                    break;                    
			}

            PrintUsage();
            
        }
    }
}
