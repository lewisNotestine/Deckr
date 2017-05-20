using Deckr.BLL.Cards;

namespace Deckr.Console.CommandLine
{
    internal class CmdLine
    {
        private readonly IDeckr Deckr;
        private readonly IConsoleWrapper Printer;

        private Deck CurrentDeck;
        private bool DeckExists
        {
            get
            {
                return CurrentDeck != null;
            }
        }

        public CmdLine(IDeckr deckr, IConsoleWrapper printer)
        {
            Deckr = deckr;
            Printer = printer;
        }

        public void DisplayOptions()
        {
            Printer.PrintUsage(DeckExists);
        }

        public CmdLineAction TakeInstructions()
        {
            var instruction = Printer.TakeUserInput();
            switch (instruction)
            {
                case ConsoleWrapper.CREATEDECK:
                    return CmdLineAction.CreateDeck;

                case ConsoleWrapper.SORTDECK:
                    if (!DeckExists)
                    {                      
                        Printer.PrintDeckMissing();
                        return CmdLineAction.Invalid;
                    }
                    return CmdLineAction.SortDeck;

                case ConsoleWrapper.SHUFFLEDECK:
                    if (!DeckExists)
                    {
                        Printer.PrintDeckMissing();
                        return CmdLineAction.Invalid;
                    }
                    return CmdLineAction.ShuffleDeck;

                case ConsoleWrapper.EXIT:
                    return CmdLineAction.Quit;

                default:
                    return CmdLineAction.Invalid;
            }
        }

        public void ExecuteInstructions(CmdLineAction action)
        {
            Printer.PrintAction(action);

            switch (action)
            {
                case CmdLineAction.CreateDeck:                    
                    CurrentDeck = Deckr.GetDeck();
                    Printer.PrintDeck(CurrentDeck);
                    break;

                case CmdLineAction.SortDeck:                    
                    Deckr.SortDeck(CurrentDeck);
                    Printer.PrintDeck(CurrentDeck);
                    break;

                case CmdLineAction.ShuffleDeck:                    
                    Deckr.ShuffleDeck(CurrentDeck);
                    Printer.PrintDeck(CurrentDeck);
                    break;

                default:
                    break;
            }
        }
    }
}
