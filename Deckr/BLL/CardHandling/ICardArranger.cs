using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{
	internal interface ICardArranger
	{
		void ShuffleDeck(Deck input);

		void SortDeck(Deck input);
	}

}
