using System;
using Deckr.BLL.Cards;

namespace Deckr
{
    public interface IDeckr
    {
        Deck GetDeck();

        Deck SortDeck(Deck inputDeck);

        Deck ShuffleDeck(Deck inputDeck);
    }
}
