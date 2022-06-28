namespace Ex05_UI
{
    public partial class GameSettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BoardSizeLabel = new System.Windows.Forms.Label();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.SmallSizeBoardRadioButton = new System.Windows.Forms.RadioButton();
            this.MediumSizeBoardRadioButton = new System.Windows.Forms.RadioButton();
            this.LargeSizeBoardRadioButton = new System.Windows.Forms.RadioButton();
            this.Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSizeLabel
            // 
            this.BoardSizeLabel.AutoSize = true;
            this.BoardSizeLabel.Location = new System.Drawing.Point(12, 16);
            this.BoardSizeLabel.Name = "BoardSizeLabel";
            this.BoardSizeLabel.Size = new System.Drawing.Size(83, 20);
            this.BoardSizeLabel.TabIndex = 0;
            this.BoardSizeLabel.Text = "Board Size:";
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Location = new System.Drawing.Point(12, 80);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(58, 20);
            this.PlayersLabel.TabIndex = 1;
            this.PlayersLabel.Text = "Players:";
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(38, 127);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(64, 20);
            this.Player1Label.TabIndex = 2;
            this.Player1Label.Text = "Player 1:";
            // 
            // SmallSizeBoardRadioButton
            // 
            this.SmallSizeBoardRadioButton.AutoSize = true;
            this.SmallSizeBoardRadioButton.Location = new System.Drawing.Point(38, 44);
            this.SmallSizeBoardRadioButton.Name = "SmallSizeBoardRadioButton";
            this.SmallSizeBoardRadioButton.Size = new System.Drawing.Size(67, 24);
            this.SmallSizeBoardRadioButton.TabIndex = 3;
            this.SmallSizeBoardRadioButton.TabStop = true;
            this.SmallSizeBoardRadioButton.Text = "6 X 6 ";
            this.SmallSizeBoardRadioButton.UseVisualStyleBackColor = true;
            // 
            // MediumSizeBoardRadioButton
            // 
            this.MediumSizeBoardRadioButton.AutoSize = true;
            this.MediumSizeBoardRadioButton.Location = new System.Drawing.Point(135, 44);
            this.MediumSizeBoardRadioButton.Name = "MediumSizeBoardRadioButton";
            this.MediumSizeBoardRadioButton.Size = new System.Drawing.Size(63, 24);
            this.MediumSizeBoardRadioButton.TabIndex = 4;
            this.MediumSizeBoardRadioButton.TabStop = true;
            this.MediumSizeBoardRadioButton.Text = "8 X 8";
            this.MediumSizeBoardRadioButton.UseVisualStyleBackColor = true;
            // 
            // LargeSizeBoardRadioButton
            // 
            this.LargeSizeBoardRadioButton.AutoSize = true;
            this.LargeSizeBoardRadioButton.Location = new System.Drawing.Point(219, 44);
            this.LargeSizeBoardRadioButton.Name = "LargeSizeBoardRadioButton";
            this.LargeSizeBoardRadioButton.Size = new System.Drawing.Size(79, 24);
            this.LargeSizeBoardRadioButton.TabIndex = 5;
            this.LargeSizeBoardRadioButton.TabStop = true;
            this.LargeSizeBoardRadioButton.Text = "10 X 10";
            this.LargeSizeBoardRadioButton.UseVisualStyleBackColor = true;
            // 
            // Player1NameTextBox
            // 
            this.Player1NameTextBox.Location = new System.Drawing.Point(173, 120);
            this.Player1NameTextBox.Name = "Player1NameTextBox";
            this.Player1NameTextBox.Size = new System.Drawing.Size(125, 27);
            this.Player1NameTextBox.TabIndex = 6;
            // 
            // Player2NameTextBox
            // 
            this.Player2NameTextBox.Enabled = false;
            this.Player2NameTextBox.Location = new System.Drawing.Point(173, 166);
            this.Player2NameTextBox.Name = "Player2NameTextBox";
            this.Player2NameTextBox.Size = new System.Drawing.Size(125, 27);
            this.Player2NameTextBox.TabIndex = 7;
            this.Player2NameTextBox.Text = "[Computer]";
            // 
            // Player2CheckBox
            // 
            this.Player2CheckBox.AutoSize = true;
            this.Player2CheckBox.Location = new System.Drawing.Point(38, 169);
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.Size = new System.Drawing.Size(86, 24);
            this.Player2CheckBox.TabIndex = 8;
            this.Player2CheckBox.Text = "Player 2:";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            this.Player2CheckBox.CheckedChanged += new System.EventHandler(this.Player2CheckBox_CheckedChanged);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(204, 216);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(94, 29);
            this.DoneButton.TabIndex = 9;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(329, 265);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.Player2CheckBox);
            this.Controls.Add(this.Player2NameTextBox);
            this.Controls.Add(this.Player1NameTextBox);
            this.Controls.Add(this.LargeSizeBoardRadioButton);
            this.Controls.Add(this.MediumSizeBoardRadioButton);
            this.Controls.Add(this.SmallSizeBoardRadioButton);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.BoardSizeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameSettingsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BoardSizeLabel;
        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.RadioButton SmallSizeBoardRadioButton;
        private System.Windows.Forms.RadioButton MediumSizeBoardRadioButton;
        private System.Windows.Forms.RadioButton LargeSizeBoardRadioButton;
        private System.Windows.Forms.TextBox Player1NameTextBox;
        private System.Windows.Forms.TextBox Player2NameTextBox;
        private System.Windows.Forms.CheckBox Player2CheckBox;
        private System.Windows.Forms.Button DoneButton;
    }
}