using System;
using Deckr.BLL.Cards;

namespace Deckr.Extensions
{    
    public static class CardExtensions
    {
        public static string GetSymbol(this Card card)
        {
            return $"{card.Suit.GetDescription()}{card.Rank.GetDescription()}";   
        }
    }
}
