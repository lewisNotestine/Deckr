using System;
namespace Deckr.BLL.Cards.Extensions
{
    //TODO: is this a central concern or should it live in the console app? 
    public static class CardExtensions
    {
        public static string GetSymbol(this Card card)
        {
            return $"{card.GetSuitSymbol()}{card.GetRankSymbol()}";   
        }

        public static string GetRankSymbol(this Card card)
        {
            switch(card.Rank)
            {
                case Rank.Deuce:
                    return "2";
                case Rank.Three:
                    return "3";
                case Rank.Four:
                    return "4";
                case Rank.Five:
                    return "5";
                case Rank.Six:
                    return "6";
                case Rank.Seven:
                    return "7";
                case Rank.Eight:
                    return "8";
                case Rank.Nine:
                    return "9";
                case Rank.Ten:
                    return "10";
                case Rank.Jack:
                    return "J";
                case Rank.Queen:
                    return "Q";
                case Rank.King:
                    return "K";
                case Rank.Ace:
                    return "A";
                default:
                    throw new ArgumentException("Bad rank");
            }
        }

        public static string GetSuitSymbol(this Card card)
        {
            switch (card.Suit)
            {
                case Suit.Spades:
                    return "♠";
                case Suit.Hearts:
                    return "♥";
                case Suit.Clubs:
                    return "♣";        
                case Suit.Diamonds:
                    return "♦";
                default:
                    throw new ArgumentException("bad suit");
            }
        }
    }
}
