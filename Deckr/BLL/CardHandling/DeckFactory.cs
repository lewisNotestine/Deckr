using System;
using Deckr.BLL.Cards;
using System.Collections.Generic;

namespace Deckr.BLL.CardHandling
{
    internal class DeckFactory : IDeckFactory
    {
        public Deck GenerateDeck()
        {
            return new Deck(new List<Card>(GenerateCards()));
        }

        private IEnumerable<Card> GenerateCards()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    yield return Card.Get(rank, suit);
                }
            }
        }
    }
}