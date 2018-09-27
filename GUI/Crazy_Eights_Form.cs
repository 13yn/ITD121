using GameObjects;
using Games;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI {

    public partial class Crazy_Eights_Form : Form {

        public Crazy_Eights_Form() {

            InitializeComponent();
            /*
            picDrawPile.Image = Images.GetBackOfCardImage();
            picDiscardPile.Image = Images.GetCardImage(new Card(Suit.Hearts, FaceValue.Queen));

            Hand userHand = new Hand(new List<Card> {
                            new Card(Suit.Diamonds, FaceValue.Three),
                            new Card(Suit.Spades, FaceValue.King)
                            });
            DisplayHand(userHand, tblUser);
            Hand computerHand = new Hand(new List<Card> {
                            new Card(Suit.Clubs, FaceValue.King),
                            new Card(Suit.Diamonds, FaceValue.King),
                            new Card(Suit.Hearts, FaceValue.Five)
                            });
            DisplayHand(computerHand, tblComputer);*/

        }

        /// <summary>
        /// Update the state of the game
        /// </summary>
        private void UpdateGame() {
            DisplayHand(CrazyEights.UserHand, tblUser);
            DisplayHand(CrazyEights.ComputerHand, tblComputer);
            if (CrazyEights.IsDrawPileEmpty) {
                picDrawPile.Image = null;
            } else {
                picDrawPile.Image = Images.GetBackOfCardImage();
            }
            picDiscardPile.Image = Images.GetCardImage(CrazyEights.TopDiscard);
            picDiscardPile.Refresh();
            picDrawPile.Refresh();
        }

        /// <summary>
        /// Computer's action
        /// </summary>
        private void ComputerPlaying() {
            if (!CrazyEights.IsPlaying) {
                return;
            }
            while (!CrazyEights.IsUserTurn && CrazyEights.IsPlaying) {
                UpdateInstructions("Computer's turn \nThinking...", true);
                CrazyEights.ActionResult result = CrazyEights.ComputerAction();
                if (result == CrazyEights.ActionResult.WinningPlay) {
                    UpdateInstructions("Computer win!!!");
                }
                UpdateGame();
            }
            if (CrazyEights.IsPlaying) {
                UpdateInstructions("Your turn!");
            }
        }

        /// <summary>
        /// Update the instrutions label
        /// </summary>
        /// <param name="message">Given string</param>
        /// <param name="wait">Wait for 1 second</param>
        private void UpdateInstructions(string message, bool wait = false) {
            lblInstructions.Text = message;
            lblInstructions.Refresh();
            if (wait) {
                System.Threading.Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Display a hand
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <param name="panel">Panel</param>
        private void DisplayHand(Hand hand, TableLayoutPanel panel) {
            // remove any previous card images
            panel.Controls.Clear();
            // repeat for each card in the hand
            for (int i = 0; i < hand.GetCount(); i++) {
                // add a picture box to the panel with the appropriate image
                PictureBox picCard = new PictureBox();
                picCard.SizeMode = PictureBoxSizeMode.AutoSize;
                picCard.Image = Images.GetCardImage(hand.GetCard(i));
                panel.Controls.Add(picCard, i, 0);
                // add an event handler if it is being added to the user’s panel
                if (panel == tblUser) {
                    picCard.Click += new System.EventHandler(this.picPlayCard_Click);
                }
            }
            panel.Refresh();
        }

        private void picPlayCard_Click(object sender, EventArgs e) {
            // get the picturebox that was clicked
            PictureBox picCard = (PictureBox)sender;
            // determine the position of the picturebox that was clicked
            int columnNum = ((TableLayoutPanel)((Control)sender).Parent).GetPositionFromControl(picCard).Column;
            // ...you will need to continue this yourself in part C...
            // MessageBox.Show(string.Format("Clicked column {0}", columnNum)); // temporary
            if (!CrazyEights.IsPlaying || !CrazyEights.IsUserTurn) {
                return;
            }
            CrazyEights.ActionResult result = CrazyEights.UserPlayCard(columnNum);
            UpdateGame();
            if (result == CrazyEights.ActionResult.SuitRequired) {
                Choose_Suit_Form suitForm = new Choose_Suit_Form();
                suitForm.ShowDialog();
                RadioButton chosenSuit = suitForm.GetChosenSuit();
                Suit newSuit;
                switch (chosenSuit.Text) {
                    case "Clubs":
                        newSuit = Suit.Clubs;
                        break;
                    case "Diamonds":
                        newSuit = Suit.Diamonds;
                        break;
                    case "Hearts":
                        newSuit = Suit.Hearts;
                        break;
                    default:
                        newSuit = Suit.Spades;
                        break;
                }
                CrazyEights.UserPlayCard(columnNum, newSuit);
            } else if (result == CrazyEights.ActionResult.InvalidPlay) {
                UpdateInstructions("Invalid Play!", true);
            } else if (result == CrazyEights.ActionResult.InvalidPlayAndMustDraw) {
                UpdateInstructions("You must draw!", true);
            } else if (result == CrazyEights.ActionResult.WinningPlay) {
                CrazyEights.IsPlaying = false;
                UpdateInstructions("You win!!!", true);
            } else if (result == CrazyEights.ActionResult.ValidPlayAndExtraTurn) {
                UpdateInstructions("You got an extra turn!", true);
            }
            ComputerPlaying();
        }

        private void btnDeal_Click(object sender, EventArgs e) {
            //Choose_Suit_Form suitForm = new Choose_Suit_Form();
            //suitForm.ShowDialog();
            //RadioButton chosenSuit = suitForm.GetChosenSuit();
            //UpdateInstructions(string.Format("You chose {0}.", chosenSuit.Text), wait: true);
            //UpdateInstructions("Click Deal to start the game.");
            CrazyEights.StartGame();
            UpdateInstructions("Your turn!");
            UpdateGame();
            btnDeal.Enabled = false;
            btnSortHand.Enabled = true;
        }

        private void btnSortHand_Click(object sender, EventArgs e) {
            if (!CrazyEights.IsPlaying || !CrazyEights.IsUserTurn) {
                return;
            }
            CrazyEights.SortUserHand();
            UpdateGame();
        }

        private void picDrawPile_Click(object sender, EventArgs e) {
            if (!CrazyEights.IsPlaying || !CrazyEights.IsUserTurn) {
                return;
            }
            CrazyEights.ActionResult result = CrazyEights.UserDrawCard();
            if (result == CrazyEights.ActionResult.CannotDraw) {
                UpdateInstructions("Cannot Draw!");
            }
            UpdateGame();
            ComputerPlaying();
        }

        private void cmbScenario_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox box = (ComboBox)sender;
            switch (box.SelectedIndex) {
                case 0:
                    CrazyEights.StartGame();
                    break;
                case 1:
                    Scenarios.StartUserLoseDemo();
                    break;
                case 2:
                    Scenarios.StartUserWinDemo();
                    break;
                case 3:
                    Scenarios.StartUserFlipDeckDemo();
                    break;
                case 4:
                    Scenarios.StartComputerFlipDeckDemo();
                    break;
                case 5:
                    Scenarios.StartOneEightInDiscardDemo();
                    break;
                case 6:
                    Scenarios.StartOneEightInDiscardDemo();
                    CrazyEights.IsUserTurn = false;
                    UpdateGame();
                    ComputerPlaying();
                    break;
                case 7:
                    Scenarios.StartNoUserMovesDemo();
                    break;
                case 8:
                    Scenarios.StartNoComputerMovesDemo();
                    break;
                case 9:
                    Scenarios.StartNobodyCanPlayAfterUserDrawsDemo();
                    break;
                default:
                    Scenarios.StartNobodyCanPlayAfterComputerDrawsDemo();
                    break;
            }
            UpdateInstructions("Your turn!");
            UpdateGame();
            btnDeal.Enabled = false;
            btnSortHand.Enabled = true;
        }

        private void btnEndGame_Click(object sender, EventArgs e) {
            Application.Restart();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys) {
            switch (keys) {
                case Keys.B | Keys.Control:
                    cmbScenario.Visible = !cmbScenario.Visible;

                    return true; // signal that we've processed this key
            }

            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }
    }

    /// <summary>
    /// This class contains logic used to manipulate CardPiles.
    /// The methods are necessary for some of the above unit tests.
    /// </summary>
    public static class Utility {
        public static CardPile CreateCardPile(List<Card> cards) {
            CardPile cardPile = new CardPile();
            foreach (Card card in cards) {
                cardPile.AddCard(card);
            }
            return cardPile;
        }
        public static List<Card> FullDeckInOrder() {
            CardPile cardPile = new CardPile(true);
            List<Card> allCards = cardPile.DealCards(cardPile.GetCount());
            allCards.Reverse();
            return allCards;
        }
        public static void RemoveHand(List<Card> cards, Hand hand) {
            foreach (Card card in hand) {
                cards.Remove(card);
            }
        }
    }

    /// <summary>
    /// This class contains logic to start games of Crazy Eights in 
    /// particular scenarios. 
    /// 
    /// The methods are useful because they create scenarios which may
    /// only occur rarely during normal play.
    /// </summary>
    public static class Scenarios {
        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the user will inevitably lose
        /// </summary>
        public static void StartUserLoseDemo() {
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Clubs, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Spades, FaceValue.Ace),
            });

            CardPile drawPile = new CardPile(true);
            drawPile.ShufflePile();

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the user will inevitably win
        /// </summary>
        public static void StartUserWinDemo() {
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Spades, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Clubs, FaceValue.Ace),
            });

            CardPile drawPile = new CardPile(true);
            drawPile.ShufflePile();


            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ten));

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the user will reach a full hand
        /// </summary>
        public static void StartNoUserMovesDemo() {
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Spades, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Jack)
            });

            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Clubs, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Queen));

            List<Card> drawCards = Utility.FullDeckInOrder();
            Utility.RemoveHand(drawCards, userHand);
            Utility.RemoveHand(drawCards, computerHand);
            drawCards.Remove(new Card(Suit.Clubs, FaceValue.Queen));
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.King));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.King));
            drawCards.Reverse();
            CardPile drawPile = Utility.CreateCardPile(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the computer will reach a full hand
        /// </summary>
        public static void StartNoComputerMovesDemo() {
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Spades, FaceValue.Ace),
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Diamonds, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Diamonds, FaceValue.Jack)
            });
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Clubs, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Diamonds, FaceValue.Seven)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.FullDeckInOrder();
            Utility.RemoveHand(drawCards, userHand);
            Utility.RemoveHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Spades, FaceValue.Nine));
            drawCards.Add(new Card(Suit.Spades, FaceValue.Nine));
            drawCards.Reverse();
            CardPile drawPile = Utility.CreateCardPile(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where both players reach a full hand 
        /// during the user's turn, so the decks must be shuffled and reset
        /// </summary>
        public static void StartNobodyCanPlayAfterUserDrawsDemo() {
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Spades, FaceValue.Seven),
                new Card(Suit.Spades, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten),
                new Card(Suit.Spades, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.King),
                new Card(Suit.Hearts, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three)
            });
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Five),
                new Card(Suit.Hearts, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Hearts, FaceValue.Queen),
                new Card(Suit.Hearts, FaceValue.King),
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.FullDeckInOrder();
            Utility.RemoveHand(drawCards, userHand);
            Utility.RemoveHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Reverse();
            CardPile drawPile = Utility.CreateCardPile(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where both players reach a full hand
        /// during the computer's turn, so the decks must be shuffled and reset
        /// </summary>
        public static void StartNobodyCanPlayAfterComputerDrawsDemo() {
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Hearts, FaceValue.Four),
                new Card(Suit.Hearts, FaceValue.Five),
                new Card(Suit.Hearts, FaceValue.Six),
                new Card(Suit.Hearts, FaceValue.Seven),
                new Card(Suit.Hearts, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Ten),
                new Card(Suit.Hearts, FaceValue.Jack),
                new Card(Suit.Hearts, FaceValue.Queen),
                new Card(Suit.Hearts, FaceValue.King),
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Diamonds, FaceValue.Three),
                new Card(Suit.Diamonds, FaceValue.Four)
            });
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Spades, FaceValue.Two),
                new Card(Suit.Spades, FaceValue.Three),
                new Card(Suit.Spades, FaceValue.Four),
                new Card(Suit.Spades, FaceValue.Five),
                new Card(Suit.Spades, FaceValue.Six),
                new Card(Suit.Spades, FaceValue.Seven),
                new Card(Suit.Spades, FaceValue.Nine),
                new Card(Suit.Spades, FaceValue.Ten),
                new Card(Suit.Spades, FaceValue.Jack),
                new Card(Suit.Spades, FaceValue.Queen),
                new Card(Suit.Spades, FaceValue.King),
                new Card(Suit.Hearts, FaceValue.Two)
            });

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Ace));

            List<Card> drawCards = Utility.FullDeckInOrder();
            Utility.RemoveHand(drawCards, userHand);
            Utility.RemoveHand(drawCards, computerHand);
            drawCards.Remove(discardPile.GetLastCardInPile());
            drawCards.Remove(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Add(new Card(Suit.Diamonds, FaceValue.Five));
            drawCards.Remove(new Card(Suit.Hearts, FaceValue.Three));
            drawCards.Add(new Card(Suit.Hearts, FaceValue.Three));
            drawCards.Reverse();
            CardPile drawPile = Utility.CreateCardPile(drawCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the draw pile will become empty 
        /// during the user's turn
        /// </summary>
        public static void StartUserFlipDeckDemo() {
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Seven),
            });
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three),
            });

            CardPile drawPile = new CardPile();
            drawPile.AddCard(new Card(Suit.Clubs, FaceValue.Five));

            List<Card> discardCards = Utility.FullDeckInOrder();
            Utility.RemoveHand(discardCards, computerHand);
            Utility.RemoveHand(discardCards, userHand);
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Two));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Two));
            CardPile discardPile = Utility.CreateCardPile(discardCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the draw pile will become empty 
        /// during the computer's turn
        /// </summary>
        public static void StartComputerFlipDeckDemo() {
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Seven),
            });
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three),
            });

            CardPile drawPile = Utility.CreateCardPile(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Ten)
            });

            List<Card> discardCards = Utility.FullDeckInOrder();
            Utility.RemoveHand(discardCards, computerHand);
            Utility.RemoveHand(discardCards, userHand);
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Two));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Two));
            CardPile discardPile = Utility.CreateCardPile(discardCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstration game of Crazy Eights where the draw pile will become empty 
        /// during the computer's turn - the computer flips to reveal an Eight
        /// </summary>
        public static void StartOneEightAfterComputerFlipsDeckDemo() {
            Hand computerHand = new Hand(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Nine),
                new Card(Suit.Hearts, FaceValue.Seven),
            });
            Hand userHand = new Hand(new List<Card> {
                new Card(Suit.Clubs, FaceValue.Two),
                new Card(Suit.Hearts, FaceValue.Three),
            });

            CardPile drawPile = Utility.CreateCardPile(new List<Card> {
                new Card(Suit.Diamonds, FaceValue.Ten)
            });

            List<Card> discardCards = Utility.FullDeckInOrder();
            Utility.RemoveHand(discardCards, computerHand);
            Utility.RemoveHand(discardCards, userHand);
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Eight));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Eight));
            discardCards.Reverse();
            discardCards.Remove(new Card(Suit.Spades, FaceValue.Two));
            discardCards.Add(new Card(Suit.Spades, FaceValue.Two));
            CardPile discardPile = Utility.CreateCardPile(discardCards);

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }

        /// <summary>
        /// Starts a demonstrationg ame of Crazy Eights where there is one Eight in the discard pile
        /// </summary>
        public static void StartOneEightInDiscardDemo() {
            CardPile drawPile = new CardPile(true);
            drawPile.ShufflePile();

            Hand userHand = new Hand(drawPile.DealCards(8));
            Hand computerHand = new Hand(drawPile.DealCards(8));

            CardPile discardPile = new CardPile();
            discardPile.AddCard(new Card(Suit.Clubs, FaceValue.Eight));

            CrazyEights.StartGame(userHand, computerHand, discardPile, drawPile);
        }
    }
}
