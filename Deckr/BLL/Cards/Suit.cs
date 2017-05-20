using System.ComponentModel;

namespace Deckr.BLL.Cards
{
    public enum Suit
    {
        [Description("♠")]
        Spades = 1,

        [Description("♥")]
        Hearts = 2,

        [Description("♣")]
        Clubs = 3,

        [Description("♦")]
        Diamonds = 4
    }
}