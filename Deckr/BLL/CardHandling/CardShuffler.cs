using System;
using System.Collections.Generic;
using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{

    internal class CardShuffler : IComparer<Card>
	{           
        private readonly Random Randomizer;
       
        public static CardShuffler GetDefault()
        {                       
            return new CardShuffler(Environment.TickCount);
        }

        public CardShuffler(int seed)
        {
            Randomizer = new Random(seed);
        }

		public int Compare(Card x, Card y)
		{
            int rand1 = Randomizer.Next();
            int rand2 = Randomizer.Next();

			return rand1.CompareTo(rand2);
		}
	}

}
