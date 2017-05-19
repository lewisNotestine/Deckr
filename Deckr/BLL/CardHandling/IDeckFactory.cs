using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{
    internal interface IDeckFactory
    {
        Deck GenerateDeck();            
    }
}