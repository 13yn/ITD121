using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI {
    public partial class Choose_Suit_Form : Form {
        RadioButton suitChosen = new RadioButton();

        public Choose_Suit_Form() {
            InitializeComponent();
        }

        private void btnPlayCard_Click(object sender, EventArgs e) {
            this.Close();
        }
        
        /// <summary>
        /// Get the chosen suit
        /// </summary>
        /// <returns>Chosen suit</returns>
        public RadioButton GetChosenSuit() {
            return suitChosen;
        }
        
        private void rdoSuits_CheckedChanged(object sender, EventArgs e) {
            suitChosen = (RadioButton)sender;
        }
    }
}
