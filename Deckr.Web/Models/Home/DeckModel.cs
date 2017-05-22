using System;
namespace Deckr.Web.Models.Home
{
    public class DeckModel
    {
        public CardModel[] Cards { get; set; }

        [Obsolete("For deserialization", error: true)]
        public DeckModel()
        {}

        public DeckModel(CardModel[] cards)
        {
            Cards = cards;
        }
    }
}
