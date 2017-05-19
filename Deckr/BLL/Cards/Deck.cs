using System.Collections.Generic;

namespace Deckr.BLL.Cards
{
    public class Deck
    {
        public ISet<Card> Cards {get;}

        public Deck(ISet<Card> cards)
        {
            Cards = cards;
        }    
    }
}