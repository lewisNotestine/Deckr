using System;
using System.Collections.Generic;
using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{
    internal class CardArranger : ICardArranger
    {
        private readonly Func<IComparer<Card>> GetShufflerFunc;
        private readonly IComparer<Card> Sorter;

        public CardArranger(Func<IComparer<Card>> getShufflerFunc, IComparer<Card> sorter)
        {
            GetShufflerFunc = getShufflerFunc;
            Sorter = sorter;
        }
         
        public void ShuffleDeck(Deck input)
        {
            input.Cards.Sort(GetShufflerFunc());
        }

        public void SortDeck(Deck input)
        {            
            input.Cards.Sort(Sorter);
        }

  
    }
}