using System;
using System.Collections.Generic;
using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{
    internal class CardArranger : ICardArranger
    {
        private readonly IComparer<Card> Shuffler;
        private readonly IComparer<Card> Sorter;

        public CardArranger(IComparer<Card> shuffler, IComparer<Card> sorter)
        {
            Shuffler = shuffler;
            Sorter = sorter;
        }
         
        public void ShuffleDeck(Deck input)
        {
            if (input?.Cards == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            input.Cards.Sort(Shuffler);
        }

        public void SortDeck(Deck input)
        {
			if (input?.Cards == null)
			{
                throw new ArgumentNullException(nameof(input));
			}
            input.Cards.Sort(Sorter);
        }

  
    }
}