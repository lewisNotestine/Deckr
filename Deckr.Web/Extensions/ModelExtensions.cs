using System;
using System.Collections.Generic;
using System.Linq;
using Deckr.BLL.Cards;
using Deckr.Extensions;
using Deckr.Web.Models.Home;

namespace Deckr.Web.Extensions
{
    public static class ModelExtensions
    {
        public static Deck GetDeck(this DeckModel deckModel)
        {
            var deckrCards = deckModel.Cards.Select(c => Card.Get(rank: (Rank)Enum.Parse(typeof(Rank), c.Rank), suit: (Suit)Enum.Parse(typeof(Suit), c.Suit))).ToList();
            return new Deck(deckrCards);
        }

        public static DeckModel GetDeckModel(this Deck deck)
        {
            return  new DeckModel(deck.Cards.Select(c => new CardModel(c.Suit.ToString(), c.Suit.GetDescription(), c.Rank.ToString(), c.Rank.GetDescription())).ToArray());
        }
    }
}
