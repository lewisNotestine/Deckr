using System.ComponentModel;

namespace Deckr.BLL.Cards
{
    public enum Rank
    {      
        [Description("2")]
        Deuce = 1,

        [Description("3")]
        Three = 2,

        [Description("4")]
        Four = 3,

        [Description("5")]
        Five = 4,

        [Description("6")]
        Six = 5,

        [Description("7")]
        Seven = 6,

        [Description("8")]
        Eight = 7,

        [Description("9")]
        Nine = 8,

        [Description("10")]
        Ten = 9,

        [Description("J")]
        Jack = 10,

        [Description("Q")]
        Queen = 11,

        [Description("K")]
        King = 12,

        [Description("A")]
        Ace = 13
    }
}