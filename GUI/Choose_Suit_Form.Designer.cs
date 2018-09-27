namespace GUI {
    partial class Choose_Suit_Form {
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
            this.lblInstruction = new System.Windows.Forms.Label();
            this.grpChooseASuit = new System.Windows.Forms.GroupBox();
            this.btnPlayCard = new System.Windows.Forms.Button();
            this.rdoClubs = new System.Windows.Forms.RadioButton();
            this.rdoDiamonds = new System.Windows.Forms.RadioButton();
            this.rdoHearts = new System.Windows.Forms.RadioButton();
            this.rdoSpades = new System.Windows.Forms.RadioButton();
            this.picClubs = new System.Windows.Forms.PictureBox();
            this.picDiamonds = new System.Windows.Forms.PictureBox();
            this.picHearts = new System.Windows.Forms.PictureBox();
            this.picSpades = new System.Windows.Forms.PictureBox();
            this.grpChooseASuit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClubs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiamonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHearts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpades)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(32, 19);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(230, 48);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "You chose an Eight!\r\nYou get to choose the Suit\r\n";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpChooseASuit
            // 
            this.grpChooseASuit.Controls.Add(this.picSpades);
            this.grpChooseASuit.Controls.Add(this.picHearts);
            this.grpChooseASuit.Controls.Add(this.picDiamonds);
            this.grpChooseASuit.Controls.Add(this.picClubs);
            this.grpChooseASuit.Controls.Add(this.rdoSpades);
            this.grpChooseASuit.Controls.Add(this.rdoHearts);
            this.grpChooseASuit.Controls.Add(this.rdoDiamonds);
            this.grpChooseASuit.Controls.Add(this.rdoClubs);
            this.grpChooseASuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChooseASuit.Location = new System.Drawing.Point(36, 85);
            this.grpChooseASuit.Name = "grpChooseASuit";
            this.grpChooseASuit.Size = new System.Drawing.Size(226, 153);
            this.grpChooseASuit.TabIndex = 1;
            this.grpChooseASuit.TabStop = false;
            this.grpChooseASuit.Text = "Choose a Suit";
            // 
            // btnPlayCard
            // 
            this.btnPlayCard.Location = new System.Drawing.Point(36, 244);
            this.btnPlayCard.Name = "btnPlayCard";
            this.btnPlayCard.Size = new System.Drawing.Size(226, 48);
            this.btnPlayCard.TabIndex = 2;
            this.btnPlayCard.Text = "Play card";
            this.btnPlayCard.UseVisualStyleBackColor = true;
            this.btnPlayCard.Click += new System.EventHandler(this.btnPlayCard_Click);
            // 
            // rdoClubs
            // 
            this.rdoClubs.AutoSize = true;
            this.rdoClubs.Location = new System.Drawing.Point(69, 25);
            this.rdoClubs.Name = "rdoClubs";
            this.rdoClubs.Size = new System.Drawing.Size(67, 24);
            this.rdoClubs.TabIndex = 0;
            this.rdoClubs.TabStop = true;
            this.rdoClubs.Text = "Clubs";
            this.rdoClubs.UseVisualStyleBackColor = true;
            this.rdoClubs.CheckedChanged += new System.EventHandler(this.rdoSuits_CheckedChanged);
            // 
            // rdoDiamonds
            // 
            this.rdoDiamonds.AutoSize = true;
            this.rdoDiamonds.Location = new System.Drawing.Point(69, 55);
            this.rdoDiamonds.Name = "rdoDiamonds";
            this.rdoDiamonds.Size = new System.Drawing.Size(99, 24);
            this.rdoDiamonds.TabIndex = 1;
            this.rdoDiamonds.TabStop = true;
            this.rdoDiamonds.Text = "Diamonds";
            this.rdoDiamonds.UseVisualStyleBackColor = true;
            this.rdoDiamonds.CheckedChanged += new System.EventHandler(this.rdoSuits_CheckedChanged);
            // 
            // rdoHearts
            // 
            this.rdoHearts.AutoSize = true;
            this.rdoHearts.Location = new System.Drawing.Point(69, 87);
            this.rdoHearts.Name = "rdoHearts";
            this.rdoHearts.Size = new System.Drawing.Size(75, 24);
            this.rdoHearts.TabIndex = 2;
            this.rdoHearts.TabStop = true;
            this.rdoHearts.Text = "Hearts";
            this.rdoHearts.UseVisualStyleBackColor = true;
            this.rdoHearts.CheckedChanged += new System.EventHandler(this.rdoSuits_CheckedChanged);
            // 
            // rdoSpades
            // 
            this.rdoSpades.AutoSize = true;
            this.rdoSpades.Location = new System.Drawing.Point(69, 117);
            this.rdoSpades.Name = "rdoSpades";
            this.rdoSpades.Size = new System.Drawing.Size(82, 24);
            this.rdoSpades.TabIndex = 3;
            this.rdoSpades.TabStop = true;
            this.rdoSpades.Text = "Spades";
            this.rdoSpades.UseVisualStyleBackColor = true;
            this.rdoSpades.CheckedChanged += new System.EventHandler(this.rdoSuits_CheckedChanged);
            // 
            // picClubs
            // 
            this.picClubs.Image = global::GUI.Properties.Resources.clubs;
            this.picClubs.Location = new System.Drawing.Point(39, 25);
            this.picClubs.Name = "picClubs";
            this.picClubs.Size = new System.Drawing.Size(24, 24);
            this.picClubs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClubs.TabIndex = 4;
            this.picClubs.TabStop = false;
            // 
            // picDiamonds
            // 
            this.picDiamonds.Image = global::GUI.Properties.Resources.diamonds;
            this.picDiamonds.Location = new System.Drawing.Point(39, 55);
            this.picDiamonds.Name = "picDiamonds";
            this.picDiamonds.Size = new System.Drawing.Size(24, 24);
            this.picDiamonds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDiamonds.TabIndex = 5;
            this.picDiamonds.TabStop = false;
            // 
            // picHearts
            // 
            this.picHearts.Image = global::GUI.Properties.Resources.hearts;
            this.picHearts.Location = new System.Drawing.Point(39, 85);
            this.picHearts.Name = "picHearts";
            this.picHearts.Size = new System.Drawing.Size(24, 24);
            this.picHearts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHearts.TabIndex = 6;
            this.picHearts.TabStop = false;
            // 
            // picSpades
            // 
            this.picSpades.Image = global::GUI.Properties.Resources.spades;
            this.picSpades.Location = new System.Drawing.Point(39, 117);
            this.picSpades.Name = "picSpades";
            this.picSpades.Size = new System.Drawing.Size(24, 24);
            this.picSpades.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSpades.TabIndex = 7;
            this.picSpades.TabStop = false;
            // 
            // Choose_Suit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 306);
            this.ControlBox = false;
            this.Controls.Add(this.btnPlayCard);
            this.Controls.Add(this.grpChooseASuit);
            this.Controls.Add(this.lblInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Choose_Suit_Form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose a Suit";
            this.TopMost = true;
            this.grpChooseASuit.ResumeLayout(false);
            this.grpChooseASuit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClubs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiamonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHearts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.GroupBox grpChooseASuit;
        private System.Windows.Forms.PictureBox picClubs;
        private System.Windows.Forms.RadioButton rdoSpades;
        private System.Windows.Forms.RadioButton rdoHearts;
        private System.Windows.Forms.RadioButton rdoDiamonds;
        private System.Windows.Forms.RadioButton rdoClubs;
        private System.Windows.Forms.Button btnPlayCard;
        private System.Windows.Forms.PictureBox picSpades;
        private System.Windows.Forms.PictureBox picHearts;
        private System.Windows.Forms.PictureBox picDiamonds;
    }
}