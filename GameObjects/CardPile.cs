using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects {

    /// <summary>
    /// Simulate a card pile
    /// </summary>
    public class CardPile {

        private List<Card> _pile = new List<Card>();
        private static Random _numberGenerator = new Random();

        /// <summary>
        /// Constructs a full deck of cards or an empty deck
        /// </summary>
        /// <param name="isConstructed">A full deck or not</param>
        public CardPile(bool isConstructed = false) {
            if (isConstructed) {
                foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                    foreach (FaceValue facevalue in Enum.GetValues(typeof(FaceValue))) {
                        _pile.Add(new Card(suit, facevalue));
                    }
                }
            }
        }

        /// <summary>
        /// Adds the given Card to the CardPile
        /// </summary>
        /// <param name="obj">Given card</param>
        public void AddCard(Card obj) {
            _pile.Add(obj);
        }

        /// <summary>
        /// Returns the number of Cards in the CardPile
        /// </summary>
        /// <returns>number of Cards in the CardPile</returns>
        public int GetCount() {
            return _pile.Count();
        }

        /// <summary>
        /// Returns the Card at the last position of the CardPile
        /// </summary>
        /// <returns>Card at the last position</returns>
        public Card GetLastCardInPile() {
            if (_pile.Count() == 0) {
                return null;
            } else {
                return _pile[_pile.Count() - 1];
            }
        }

        /// <summary>
        /// Shuffles the CardPile
        /// </summary>
        public void ShufflePile() {
            for (int idx = _pile.Count() - 1; idx >= 0; idx--) {
                int idxSwap = _numberGenerator.Next(0, idx);
                Card tmp = _pile[idx];
                _pile[idx] = _pile[idxSwap];
                _pile[idxSwap] = tmp;
            }
        }

        /// <summary>
        /// Returns the next Card from the CardPile and removes it from the CardPile
        /// </summary>
        /// <returns>next Card</returns>
        public Card DealOneCard() {
            Card tmp = _pile[0];
            _pile.RemoveAt(0);
            return tmp;
        }

        /// <summary>
        /// Deals the number of Cards specified by the parameter, removing them and
        /// returning them as a List of Cards
        /// </summary>
        /// <param name="numCards"> Number of cards</param>
        /// <returns>A list of card to deal</returns>
        public List<Card> DealCards(int numCards) {
            List<Card> tmp = new List<Card>();
            while (numCards-- != 0) {
                tmp.Add(DealOneCard());
            }
            return tmp;
        }
    }

}
