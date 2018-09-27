using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects {

    /// <summary>
    /// Simulate a hand
    /// </summary>
    public class Hand : IEnumerable {
        private List<Card> _hand;

        /// <summary>
        /// Constructs an empty hand
        /// </summary>
        public Hand() {
            _hand = new List<Card>();
        }

        /// <summary>
        /// Constructs a hand with given cards
        /// </summary>
        /// <param name="obj">Given cards</param>
        public Hand(List<Card> obj) {
            _hand = new List<Card>(obj);
        }


        /// <summary>
        /// Return the number of Cards in the Hand
        /// </summary>
        /// <returns>number of Cards</returns>
        public int GetCount() {
            return _hand.Count;
        }

        /// <summary>
        /// Return the Card at the given position in the Hand
        /// </summary>
        /// <param name="idx">Position</param>
        /// <returns>Card at the given position</returns>
        public Card GetCard(int idx) {
            return _hand[idx];
        }

        /// <summary>
        /// Add the given Card to the Hand
        /// </summary>
        /// <param name="obj">Given card</param>
        public void AddCard(Card obj) {
            _hand.Add(obj);
        }

        /// <summary>
        /// Return true if the given Card is in the Hand
        /// </summary>
        /// <param name="obj">Given card</param>
        /// <returns>true if the given Card is in the Hand</returns>
        public bool ContainsCard(Card obj) {
            return _hand.Contains(obj);
        }

        /// <summary>
        /// Remove the given Card from the Hand, if possible.
        /// </summary>
        /// <param name="obj">Given Card</param>
        /// <returns>true if successful</returns>
        public bool RemoveCard(Card obj) {
            return _hand.Remove(obj);
        }

        /// <summary>
        /// Remove the Card at the index given by the integer parameter. 
        /// </summary>
        /// <param name="idx">Position</param>
        /// <returns>Return true if successful.</returns>
        public bool RemoveCardAt(int idx) {
            if (idx < 0 || idx >= _hand.Count) {
                return false;
            } else {
                _hand.RemoveAt(idx);
                return true;
            }
        }

        /// <summary>
        /// Sort the Hand first by Suit, and then by FaceValue
        /// </summary>
        public void SortHand() {
            _hand.Sort();
        }

        /// <summary>
        /// Gets an enumerator over the Hand
        /// </summary>
        /// <returns>Enumerator of the Hand</returns>
        public IEnumerator GetEnumerator() {
            return _hand.GetEnumerator();
        }
    }

}
