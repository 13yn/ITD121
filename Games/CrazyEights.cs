using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameObjects;

namespace Games {
    /// <summary>
    /// Simulate Crazy Eights rules
    /// 
    /// Student Name: Tong Xuan Bao
    /// STudent ID  : n10274472
    /// 
    /// </summary>
    public static class CrazyEights {
        public enum ActionResult {
            /// <summary>
            /// A card was played that won the game
            /// </summary>
            WinningPlay,
            /// <summary>
            /// A valid card was played
            /// </summary>
            ValidPlay,
            /// <summary>
            /// A suit is required to continue play
            /// </summary>
            SuitRequired,
            /// <summary>
            /// Attempted to play an invalid card
            /// </summary>
            InvalidPlay,
            /// <summary>
            /// Attempted to play an invalid card when no cards can be played
            /// </summary>
            InvalidPlayAndMustDraw,
            /// <summary>
            /// A valid card was played, and the other player cannot play
            /// </summary>
            ValidPlayAndExtraTurn,
            /// <summary>
            /// Drew a playable card
            /// </summary>
            DrewPlayableCard,
            /// <summary>
            /// Drew an unplayable card
            /// </summary>
            DrewUnplayableCard,
            /// <summary>
            /// Drew an unplayable card and filled the hand
            /// </summary>
            DrewAndNoMovePossible,
            /// <summary>
            /// Drew an unplayable card and filled the hand, leaving both
            /// players unable to play, so piles were reset so that the
            /// the other player can continue play (rule 9)
            /// </summary>
            DrewAndResetPiles,
            /// <summary>
            /// Attempted to draw a card while moves were still possible
            /// </summary>
            CannotDraw,
            /// <summary>
            /// Flipped the discard pile to use as the new draw pile (rule 10)
            /// </summary>
            FlippedDeck
        }

        private const int FULL_HAND = 13;

        private static CardPile _drawPile = new CardPile(true);
        private static CardPile _discardPile = new CardPile();

        public static Card TopDiscard { get { return _discardPile.GetLastCardInPile(); } }

        public static bool IsDrawPileEmpty { get { return (_drawPile.GetCount() == 0); } }

        public static Hand ComputerHand { get; set; }
        public static Hand UserHand { get; set; }
        public static bool IsUserTurn { get; set; } = true;
        public static bool IsPlaying { get; set; } = false;

        /// <summary>
        /// Sets up a game of Crazy Eights according to the normal rules.
        /// </summary>
        public static void StartGame() {
            // Sets up the initial state
            _drawPile = new CardPile(true);
            _drawPile.ShufflePile();
            UserHand = new Hand();
            ComputerHand = new Hand();
            IsPlaying = true;
            IsUserTurn = true;
            // Deal each hand eight cards
            for (int count = 1; count <= 8; count++) {
                UserHand.AddCard(_drawPile.DealOneCard());
                ComputerHand.AddCard(_drawPile.DealOneCard());
            }
            // Get one card to discard pile
            _discardPile = new CardPile();
            _discardPile.AddCard(_drawPile.DealOneCard());
        }

        /// <summary>
        /// Sets up a game of Crazy Eights using the given hands and card piles.
        /// The user still plays first.
        /// </summary>
        /// <param name="userHand">User's Hand</param>
        /// <param name="computerHand">Computer's Hand</param>
        /// <param name="discardPile">Discard Pile</param>
        /// <param name="drawPile">Draw Pile</param>
        public static void StartGame(Hand userHand, Hand computerHand,
            CardPile discardPile, CardPile drawPile) {
            UserHand = userHand;
            ComputerHand = computerHand;
            _discardPile = discardPile;
            _drawPile = drawPile;
            IsPlaying = true;
            IsUserTurn = true;
        }

        /// <summary>
        /// Sorts the user’s hand.
        /// </summary>
        public static void SortUserHand() {
            if (!IsPlaying) {
                throw new Exception();
            } else {
                UserHand.SortHand();
            }
        }

        /// <summary>
        /// Attempt to draw a card for the user, performing actions according
        /// to the rules.
        /// </summary>
        /// <returns>Return the action according to the rules</returns>
        public static ActionResult UserDrawCard() {
            if (!IsPlaying || !IsUserTurn) {
                throw new Exception();
            }

            return DrawCard(UserHand, ComputerHand);

        }

        /// <summary>
        /// Attempt to play the chosen card for the user according to the rules
        /// of the game.
        /// </summary>
        /// <param name="cardNum"> Card's index in hand</param>
        /// <param name="chosenSuit">Suit if the card is eight</param>
        /// <returns>Return the action according to the rules</returns>
        public static ActionResult UserPlayCard(int cardNum, Suit? chosenSuit = null) {
            Card cardPlayed = UserHand.GetCard(cardNum);
            Suit newSuit = chosenSuit == null ? cardPlayed.GetSuit() : (Suit)chosenSuit;

            if (!IsPlaying || !IsUserTurn) {
                throw new Exception();
            }

            if (cardPlayed.GetFaceValue() == FaceValue.Eight && chosenSuit == null) {
                return ActionResult.SuitRequired;
            }

            return PlayCard(UserHand, cardNum, newSuit, ComputerHand);
        }

        /// <summary>
        /// Perform an action according to the computer’s rules.
        /// </summary>
        /// <returns>Return the action according to the rules</returns>
        public static ActionResult ComputerAction() {
            if (!IsPlaying || IsUserTurn) {
                throw new Exception();
            }

            if (IsHandPlayable(ComputerHand)) {
                int idx = GetCardCanPlay(ComputerHand);
                return PlayCard(ComputerHand, idx, ComputerHand.GetCard(idx).GetSuit(), UserHand);
            } else {
                return DrawCard(ComputerHand, UserHand);

            }

        }

        /// <summary>
        /// Get a card that is playable from a hand
        /// </summary>
        /// <param name="hand">Give hand</param>
        /// <returns>Playable card</returns>
        private static int GetCardCanPlay(Hand hand) {
            int idx = 0;
            for (int i = 0; i < hand.GetCount(); i++) {
                if (hand.GetCard(i).GetFaceValue() == FaceValue.Eight) {
                    idx = i;
                }
            }
            for (int i = 0; i < hand.GetCount(); i++) {
                if (hand.GetCard(i).GetSuit() == TopDiscard.GetSuit() &&
                    hand.GetCard(i).GetFaceValue() != FaceValue.Eight) {
                    idx = i;
                }
            }
            for (int i = 0; i < hand.GetCount(); i++) {
                if (hand.GetCard(i).GetFaceValue() == TopDiscard.GetFaceValue() &&
                    hand.GetCard(i).GetFaceValue() != FaceValue.Eight) {
                    idx = i;
                }
            }
            return idx;
        }

        /// <summary>
        /// Plays the chosen Card (given by cardNum) from the given Hand (given
        /// by hand), with a particular Suit(given by newSuit).
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <param name="cardNum">Card's index</param>
        /// <param name="newSuit">Give suit if the card is eight</param>
        /// <param name="opponentHand">The opponent's hand</param>
        /// <returns></returns>
        private static ActionResult PlayCard(Hand hand, int cardNum, Suit newSuit, Hand opponentHand) {
            // Get the card
            Card cardPlayed = hand.GetCard(cardNum);
            if (!IsCardPlayable(cardPlayed)) {
                if (IsHandPlayable(hand)) {
                    return ActionResult.InvalidPlay;
                } else {
                    return ActionResult.InvalidPlayAndMustDraw;
                }
            } else {
                _discardPile.AddCard(new Card(newSuit, cardPlayed.GetFaceValue()));
                hand.RemoveCardAt(cardNum);
                if (hand.GetCount() == 0) {
                    IsPlaying = false;
                    return ActionResult.WinningPlay;
                } else {
                    if (!IsHandPlayable(opponentHand) && opponentHand.GetCount() == FULL_HAND) {
                        return ActionResult.ValidPlayAndExtraTurn;
                    } else {
                        IsUserTurn = !IsUserTurn;
                        return ActionResult.ValidPlay;
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to draw a Card into the given Hand. 
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <param name="opponentHand">Opponent's hand</param>
        /// <returns>Returns an ActionResult based on the normal rules of the game.</returns>
        private static ActionResult DrawCard(Hand hand, Hand opponentHand) {
            if (IsHandPlayable(hand) || hand.GetCount() >= FULL_HAND) {
                return ActionResult.CannotDraw;
            } else if (!IsDrawPileEmpty) {
                hand.AddCard(_drawPile.DealOneCard());
                if (IsCardPlayable(hand.GetCard(hand.GetCount() - 1))) {
                    return ActionResult.DrewPlayableCard;
                } else {
                    if (hand.GetCount() >= FULL_HAND) {
                        IsUserTurn = !IsUserTurn;
                        if (opponentHand.GetCount() >= FULL_HAND && !IsHandPlayable(opponentHand)) {
                            while (!IsHandPlayable(opponentHand)) {
                                while (_discardPile.GetCount() != 0) {
                                    _drawPile.AddCard(_discardPile.DealOneCard());
                                }
                                _drawPile.ShufflePile();
                                _discardPile.AddCard(_drawPile.DealOneCard());
                            }
                            return ActionResult.DrewAndResetPiles;
                        } else {
                            return ActionResult.DrewAndNoMovePossible;
                        }
                    } else {
                        return ActionResult.DrewUnplayableCard;
                    }
                }
            } else {
                while (_discardPile.GetCount() != 0) {
                    _drawPile.AddCard(_discardPile.DealOneCard());
                }
                _discardPile.AddCard(_drawPile.DealOneCard());
                return ActionResult.FlippedDeck;
            }
        }

        /// <summary>
        /// Check if the hand is playable
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>Returns true if the given Hand contains a playable Card.</returns>
        private static bool IsHandPlayable(Hand hand) {
            if (TopDiscard.GetFaceValue() == FaceValue.Eight) {
                return true;
            }
            foreach (Card card in hand) {
                if (card.GetSuit() == TopDiscard.GetSuit() ||
                    card.GetFaceValue() == TopDiscard.GetFaceValue() ||
                     card.GetFaceValue() == FaceValue.Eight) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the card is playable
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Returns true if the given Card is currently playable.</returns>
        private static bool IsCardPlayable(Card card) {
            if (TopDiscard.GetFaceValue() == FaceValue.Eight) {
                return true;
            }
            if (card.GetSuit() == TopDiscard.GetSuit() || card.GetFaceValue() == TopDiscard.GetFaceValue() ||
                card.GetFaceValue() == FaceValue.Eight) {
                return true;
            } else {
                return false;
            }
        }
    }
}
