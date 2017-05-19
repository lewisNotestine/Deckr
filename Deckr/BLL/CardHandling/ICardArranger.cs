using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{
	internal interface ICardArranger
	{
		Deck ShuffleDeck(Deck input);

		Deck SortDeck(Deck input);
	}

}
