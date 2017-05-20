using System;
using System.ComponentModel;
namespace Deckr.Console.CommandLine
{
    public enum CmdLineAction
    {
        [Obsolete("don't assign this")]
        Undefined,

        [Description("Creating Deck")]
        CreateDeck,

        [Description("Sorting Deck")]
        SortDeck,

        [Description("Shuffling Deck")]
        ShuffleDeck, 

        [Description("Exiting")]
        Quit,

        [Description("Invalid Input!")]
        Invalid
    }
}
