using System;
using System.Collections.Generic;
using Deckr.BLL.Cards;

namespace Deckr.BLL.CardHandling
{

    internal class CardShuffler : IComparer<Card>
	{
        private readonly Func<int> SeedOne;
        private readonly Func<int> SeedTwo;

        public static CardShuffler GetDefault()
        {
            Func<int> nowTix = () => { return (int)DateTime.Now.Ticks % Int32.MaxValue; };
            Func<int> nowNowTix = () => { return (int)DateTime.Now.Ticks % Int32.MaxValue; };
            return new CardShuffler(nowTix, nowNowTix);
        }

        public CardShuffler(Func<int> seedOne, Func<int> seedTwo)
        {
            SeedOne = seedOne;
            SeedTwo = seedTwo;
        }

		public int Compare(Card x, Card y)
		{
			int rand1 = new Random(SeedOne()).Next();
			int rand2 = new Random(SeedTwo()).Next();

			return rand1.CompareTo(rand2);
		}
	}

}
