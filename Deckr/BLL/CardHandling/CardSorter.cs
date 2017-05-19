using System;
using System.Collections.Generic;
using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{
	internal class CardSorter : IComparer<Card>
	{
		public int Compare(Card x, Card y)
		{
			return x.DefaultOrder.CompareTo(y.DefaultOrder);
		}
	}
}
