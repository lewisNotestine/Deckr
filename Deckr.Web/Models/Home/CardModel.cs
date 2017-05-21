using System;
namespace Deckr.Web.Models.Home
{
	public class CardModel
	{
		[Obsolete("for deserialization only")]
		public CardModel()
		{ }

		public CardModel(string suit, string suitSymbol, string rank, string rankSymbol)
		{
			Suit = suit;
			SuitSymbol = suitSymbol;
			Rank = rank;
			RankSymbol = rankSymbol;
		}

        public string Suit { get; set; }
		public string SuitSymbol { get; set; }
		public string Rank { get; set; }
		public string RankSymbol { get; set; }
	}

}
