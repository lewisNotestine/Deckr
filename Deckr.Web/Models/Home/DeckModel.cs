using System;
namespace Deckr.Web.Models.Home
{
    public class DeckModel
    {
        public CardModel[] Cards { get; set; }

        [Obsolete("For deserialization")]
        public DeckModel()
        {}

        public DeckModel(CardModel[] cards)
        {
            Cards = cards;
        }
    }
}
