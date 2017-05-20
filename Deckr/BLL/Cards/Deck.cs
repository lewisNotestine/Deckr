using System.Collections.Generic;

namespace Deckr.BLL.Cards
{
    public class Deck
    {
        public List<Card> Cards {get;}

        public Deck(List<Card> cards)
        {
            Cards = cards;
        }    
    }
}