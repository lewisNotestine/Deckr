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
        private bool DeckExists
        {
            get
            {
                return CurrentDeck != null;
            }
        }

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
----------------

{CREATEDECK}. Create a deck
");

            if (DeckExists)
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

        public CmdLineAction TakeInstructions()
        {
            var instruction = System.Console.ReadKey().KeyChar.ToString();
            switch (instruction)
            {
                case CREATEDECK:
                    return CmdLineAction.CreateDeck;
                case SORTDECK:
                    if (!DeckExists)
                    {
                        System.Console.WriteLine("must create a deck first");
                        return CmdLineAction.Invalid;
                    }
                    return CmdLineAction.SortDeck;
                case SHUFFLEDECK:
                    if (!DeckExists)
                    {
                        System.Console.WriteLine("must create a deck first");
                        return CmdLineAction.Invalid;
                    }
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
                    Deckr.SortDeck(CurrentDeck);
                    Printer.PrintDeck(CurrentDeck);
                    break;
                case CmdLineAction.ShuffleDeck:
                    System.Console.WriteLine($"\nShuffling Deck!\n");
                    Deckr.ShuffleDeck(CurrentDeck);
                    Printer.PrintDeck(CurrentDeck);
                    break;
                case CmdLineAction.Invalid:
                    System.Console.Write(
$@"
Invalid Input.
");

                    break;
                default:
                    break;
            }
        }
    }
}
