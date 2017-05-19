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
         
        public Deck ShuffleDeck(Deck input)
        {
            return new Deck(new SortedSet<Card>(input.Cards, CardShuffler.GetDefault()));
        }

        public Deck SortDeck(Deck input)
        {
            return new Deck(new SortedSet<Card>(input.Cards, Sorter));
        }

  
    }
}