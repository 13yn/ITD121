namespace GUI {
    partial class Crazy_Eights_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crazy_Eights_Form));
            this.btnSortHand = new System.Windows.Forms.Button();
            this.lblComputer = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tblComputer = new System.Windows.Forms.TableLayoutPanel();
            this.tblUser = new System.Windows.Forms.TableLayoutPanel();
            this.picDrawPile = new System.Windows.Forms.PictureBox();
            this.picDiscardPile = new System.Windows.Forms.PictureBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnDeal = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnEndGame = new System.Windows.Forms.Button();
            this.cmbScenario = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawPile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiscardPile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSortHand
            // 
            this.btnSortHand.BackColor = System.Drawing.Color.DarkSeaGreen;
            resources.ApplyResources(this.btnSortHand, "btnSortHand");
            this.btnSortHand.Name = "btnSortHand";
            this.btnSortHand.TabStop = false;
            this.btnSortHand.UseVisualStyleBackColor = false;
            this.btnSortHand.Click += new System.EventHandler(this.btnSortHand_Click);
            // 
            // lblComputer
            // 
            resources.ApplyResources(this.lblComputer, "lblComputer");
            this.lblComputer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblComputer.Name = "lblComputer";
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUser.Name = "lblUser";
            // 
            // tblComputer
            // 
            resources.ApplyResources(this.tblComputer, "tblComputer");
            this.tblComputer.Name = "tblComputer";
            // 
            // tblUser
            // 
            resources.ApplyResources(this.tblUser, "tblUser");
            this.tblUser.Name = "tblUser";
            // 
            // picDrawPile
            // 
            this.picDrawPile.BackColor = System.Drawing.Color.SeaGreen;
            resources.ApplyResources(this.picDrawPile, "picDrawPile");
            this.picDrawPile.Name = "picDrawPile";
            this.picDrawPile.TabStop = false;
            this.picDrawPile.Click += new System.EventHandler(this.picDrawPile_Click);
            // 
            // picDiscardPile
            // 
            this.picDiscardPile.BackColor = System.Drawing.Color.SeaGreen;
            resources.ApplyResources(this.picDiscardPile, "picDiscardPile");
            this.picDiscardPile.Name = "picDiscardPile";
            this.picDiscardPile.TabStop = false;
            // 
            // lblInstructions
            // 
            resources.ApplyResources(this.lblInstructions, "lblInstructions");
            this.lblInstructions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInstructions.Name = "lblInstructions";
            // 
            // btnDeal
            // 
            this.btnDeal.BackColor = System.Drawing.Color.DarkOrange;
            resources.ApplyResources(this.btnDeal, "btnDeal");
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.UseVisualStyleBackColor = false;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnEndGame
            // 
            this.btnEndGame.BackColor = System.Drawing.Color.DarkOrange;
            resources.ApplyResources(this.btnEndGame, "btnEndGame");
            this.btnEndGame.Name = "btnEndGame";
            this.btnEndGame.UseVisualStyleBackColor = false;
            this.btnEndGame.Click += new System.EventHandler(this.btnEndGame_Click);
            // 
            // cmbScenario
            // 
            this.cmbScenario.FormattingEnabled = true;
            this.cmbScenario.Items.AddRange(new object[] {
            resources.GetString("cmbScenario.Items"),
            resources.GetString("cmbScenario.Items1"),
            resources.GetString("cmbScenario.Items2"),
            resources.GetString("cmbScenario.Items3"),
            resources.GetString("cmbScenario.Items4"),
            resources.GetString("cmbScenario.Items5"),
            resources.GetString("cmbScenario.Items6"),
            resources.GetString("cmbScenario.Items7"),
            resources.GetString("cmbScenario.Items8"),
            resources.GetString("cmbScenario.Items9"),
            resources.GetString("cmbScenario.Items10")});
            resources.ApplyResources(this.cmbScenario, "cmbScenario");
            this.cmbScenario.Name = "cmbScenario";
            this.cmbScenario.SelectedIndexChanged += new System.EventHandler(this.cmbScenario_SelectedIndexChanged);
            // 
            // Crazy_Eights_Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.cmbScenario);
            this.Controls.Add(this.btnEndGame);
            this.Controls.Add(this.btnSortHand);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.picDiscardPile);
            this.Controls.Add(this.picDrawPile);
            this.Controls.Add(this.tblUser);
            this.Controls.Add(this.tblComputer);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblComputer);
            this.Name = "Crazy_Eights_Form";
            ((System.ComponentModel.ISupportInitialize)(this.picDrawPile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiscardPile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TableLayoutPanel tblComputer;
        private System.Windows.Forms.TableLayoutPanel tblUser;
        private System.Windows.Forms.PictureBox picDrawPile;
        private System.Windows.Forms.PictureBox picDiscardPile;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnDeal;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnEndGame;
        private System.Windows.Forms.Button btnSortHand;
        private System.Windows.Forms.ComboBox cmbScenario;
    }
}