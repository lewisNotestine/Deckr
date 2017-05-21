using System;
using System.Collections.Generic;
using System.Linq;
using Deckr.BLL.Cards;
using Deckr.Extensions;
using Deckr.Web.Models.Home;

namespace Deckr.Web.Extensions
{
    /// <summary>
    /// These extensions basically serve as an adapter/anti-corruption layer between the models in Deckr.BLL.Cards, and the consuming code in the web app.
    /// </summary>
    public static class ModelExtensions
    {
        public static Deck GetDeck(this DeckModel deckModel)
        {
            if (deckModel?.Cards == null)
            {
                throw new ArgumentNullException("deckModel or cards is null");
            }

            var deckrCards = deckModel.Cards.Select(c => Card.Get(rank: (Rank)Enum.Parse(typeof(Rank), c.Rank), suit: (Suit)Enum.Parse(typeof(Suit), c.Suit))).ToList();
            return new Deck(deckrCards);
        }

        public static DeckModel GetDeckModel(this Deck deck)
        {
            if (deck?.Cards == null)
            {
                throw new ArgumentNullException("Deck or cards is null");
            }

            return  new DeckModel(deck.Cards.Select(c => new CardModel(c.Suit.ToString(), c.Suit.GetDescription(), c.Rank.ToString(), c.Rank.GetDescription())).ToArray());
        }
    }
}
