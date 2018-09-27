using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects {
    
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum FaceValue {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine,
        Ten, Jack, Queen, King
    }
    
    /// <summary>
    /// Simulate a Card
    /// </summary>
    public class Card : IEquatable<Card>, IComparable<Card> {

        private FaceValue _facevalue;
        private Suit _suit;
        
        private static string[] suitString = new string[] { "C", "D", "H", "S" };
        private static string[] faceString = new string[] { "A", "2", "3", "4",
            "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

        /// <summary>
        /// Constructs a card with given suits and facevalues
        /// </summary>
        /// <param name="suit">Suit</param>
        /// <param name="facevalue">FaceValue</param>
        public Card(Suit suit, FaceValue facevalue) {
            _suit = suit;
            _facevalue = facevalue;
        }

        /// <summary>
        /// Return the face value of the card
        /// </summary>
        /// <returns>FaceValue of the card</returns>
        public FaceValue GetFaceValue() {
            return _facevalue;
        }

        /// <summary>
        /// Return the suit of the card
        /// </summary>
        /// <returns>Suit of the card</returns>
        public Suit GetSuit() {
            return _suit;
        }

        /// <summary>
        /// Check if this card is equivalent to obj card
        /// </summary>
        /// <param name="obj">Card to compare</param>
        /// <returns>True if equal otherwise false</returns>
        public bool Equals(Card obj) {
            return (_facevalue == obj.GetFaceValue() && _suit == obj.GetSuit());
        }

        /// <summary>
        /// Compare this card to obj card
        /// </summary>
        /// <param name="obj">Card to compare</param>
        /// <returns>Number < 0 if smaller, = 0 if equal and > 0 if bigger</returns>
        public int CompareTo(Card obj) {
            int value = (int)_facevalue + ((int)_suit + 1) * 100;
            int objValue = (int)obj.GetFaceValue() + ((int)obj.GetSuit() + 1) * 100;
            return value - objValue;
        }

        /// <summary>
        /// Return the string represent the card
        /// </summary>
        /// <returns>String represent the card</returns>
        public override string ToString() {
            return faceString[(int)_facevalue] + suitString[(int)_suit];
        }

    }
}
