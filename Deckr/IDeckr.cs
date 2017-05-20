using System;
using Deckr.BLL.Cards;

namespace Deckr
{
    public interface IDeckr
    {
        Deck GetDeck();

        void SortDeck(Deck inputDeck);

        void ShuffleDeck(Deck inputDeck);
    }
}
