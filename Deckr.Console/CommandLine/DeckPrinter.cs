using System;
using Deckr.BLL.Cards;
using Deckr.BLL.Cards.Extensions;

namespace Deckr.Console.CommandLine
{
    public class DeckPrinter
    {
        private const int ROW_SIZE = 13;

        public void PrintDeck(Deck deck)
        {
			System.Console.Write("\n Current Deck \n ----------------\n");
            int rowCount = 0;
			foreach (var card in deck.Cards)
			{
                
                if (rowCount >= ROW_SIZE)
                {
                    System.Console.WriteLine();
                    rowCount = 0;
                }
				System.Console.Write($"{card.GetSymbol()} ");
                rowCount++;
			}
        }
    }
}
