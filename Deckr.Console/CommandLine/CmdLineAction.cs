using System;
namespace Deckr.Console.CommandLine
{
    public enum CmdLineAction
    {
        [Obsolete("don't assign this")]
        Undefined,
        CreateDeck,
        SortDeck,
        ShuffleDeck, 
        Quit,
        Invalid
    }
}
