using System;
using Deckr.BLL.CardHandling;
using Deckr.BLL.Cards;

namespace Deckr 
{

    /// <summary>
    /// This is the consumable interface of the Card handling suite that is Deckr. 
    /// Responsibilities: 
    /// 1. Generating card decks.
    /// 2. Sorting card decks. 
    /// 3. Shuffling card decks.
    /// </summary>
    public class Deckr : IDeckr
    {
        private readonly ICardArranger CardArranger;
        private readonly IDeckFactory DeckFactory;

        private Deckr(ICardArranger cardArranger, IDeckFactory deckFactory)
        {
            CardArranger = cardArranger;
            DeckFactory = deckFactory;
        }

        public static IDeckr GetDefault()
        {
            return new Deckr(new CardArranger(CardShuffler.GetDefault(), new CardSorter()), new DeckFactory());
        }

        public Deck GetDeck()
        {
            return DeckFactory.GenerateDeck();
        }

        public Deck ShuffleDeck(Deck inputDeck)
        {
            return CardArranger.ShuffleDeck(inputDeck);
        }

        public Deck SortDeck(Deck inputDeck)
        {
            return CardArranger.SortDeck(inputDeck);
        }
    }
}