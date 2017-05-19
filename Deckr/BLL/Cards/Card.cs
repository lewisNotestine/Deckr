using System;
using System.Linq;

namespace Deckr.BLL.Cards
{
    public struct Card
    {
        private const int HASH_A = 13;
        private const int HASH_B = 23;
        private static readonly int MaxRank = ((int[])Enum.GetValues(typeof(Rank))).Max();
        private static readonly int MaxSuit = ((int[])Enum.GetValues(typeof(Suit))).Max();
        private static readonly int MinRank = ((int[])Enum.GetValues(typeof(Rank))).Min();
        private static readonly int MinSuit = ((int[])Enum.GetValues(typeof(Suit))).Min();

        public Rank Rank {get;}
        public Suit Suit {get;}

        public int DefaultOrder 
        {
            get
            {                
                return MaxRank * ((int)Suit - 1) + (int)Rank;
            }
        }

        public static Card Get(Rank rank, Suit suit)
        {
			if ((int)rank > MaxRank || (int)suit > MaxSuit
               || (int)rank < MinRank || (int)suit < MinSuit)
			{
				throw new InvalidOperationException("parameter input is out of bounds.");
			}

            return new Card(rank, suit);
        }

        private Card(Rank rank, Suit suit)
        {            
            Rank = rank;
            Suit = suit;
        }

        public override int GetHashCode()
        {   
            
            return (int)Suit * (int)Rank * HASH_A * HASH_B;
        }

        
        public override bool Equals (object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }                        

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var cardObj = (Card) obj;
            return this.Rank == cardObj.Rank && this.Suit == cardObj.Suit;
        } 

        public static bool operator ==(Card one, Card other)
        {
            return one.Equals(other);
        }

        public static bool operator !=(Card one, Card other)
        {
            return !one.Equals(other);
        }
    }
}