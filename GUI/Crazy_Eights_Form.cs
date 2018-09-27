using GameObjects;
using Games;
using System;
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
            UpdateGame();
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
}
