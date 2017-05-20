using System;
using System.Collections.Generic;

namespace Deckr.Web.Models.Home
{
    public class CardModel
    {
        [Obsolete("for deserialization only")]
        public CardModel()
        {}

        public CardModel(string suit, string suitSymbol, string rank, string rankSymbol)
        {
            Suit = suit;
            SuitSymbol = suitSymbol;
            Rank = rank;
            RankSymbol = rankSymbol;
        }

        public string Suit;
        public string SuitSymbol;
        public string Rank;
        public string RankSymbol;
    }

    public class IndexModel
    {
        [Obsolete("For deserialization")]
        public IndexModel()
        {}

        public IndexModel(List<CardModel> cards)
        {
            Cards = cards;
        }

        public List<CardModel> Cards;
    }
}