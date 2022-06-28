using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05_UI
{
    public partial class GameSettingsForm : Form
    {
        private int SC_CLOSE = 0xF060;
        private int WM_SYSCOMMAND = 0x0112;
        private bool xClick = false;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                xClick = true;
            }

            base.WndProc(ref m);
        }

        public bool SettingsFormClosedByDone { get; set; }

        public bool IsPc
        {
            get { return !Player2CheckBox.Checked; }
        }

        public string Player1Name
        {
            get { return Player1NameTextBox.Text; }
        }

        public string Player2Name
        {
            get { return Player2NameTextBox.Text; }
        }

        public int BoardSize
        {
            get
            {
                return checkBoardSize();
            }
        }

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private int checkBoardSize()
        {
            int BoardSize;

            if (SmallSizeBoardRadioButton.Checked)
            {
                BoardSize = 6;
            }
            else if (MediumSizeBoardRadioButton.Checked)
            {
                BoardSize = 8;
            }
            else
            {
                BoardSize = 10;
            }

            return BoardSize;
        }

        private void Player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Player2CheckBox.Checked)
            {
                this.Player2NameTextBox.Enabled = true;
                this.Player2NameTextBox.Text = string.Empty;
            }
            else
            {
                this.Player2NameTextBox.Enabled = false;
                this.Player2NameTextBox.Text = "[Computer]";
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Player1NameTextBox.Text) || string.IsNullOrEmpty(Player2NameTextBox.Text))
            {
                MessageBox.Show("Please fill all required details", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
            }
        }

        private void GameSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!xClick)
            {
                SettingsFormClosedByDone = true;
            }
        }
    }
}
