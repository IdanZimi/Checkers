using System;
using System.Drawing;
using System.Windows.Forms;
using CheckersLogic;

namespace Ex05_UI
{
    public partial class GameForm : Form
    {
        private readonly GameSettingsForm r_GameSettingsForm = new GameSettingsForm();
        private Button[,] m_ButtonMatrix;
        private Position m_LastClickedPosition;
        private CheckersLogic.CheckersLogic m_CheckersLogic;
        private int m_RowOfCellClicked;
        private int m_ColOfCellClicked;

        public GameForm()
        {
            InitializeComponent();
            timer1.Interval = 500;
        }

        private void GameInit()
        {
            string player1Name = r_GameSettingsForm.Player1Name;
            string Player2Name;
            int boardSize = r_GameSettingsForm.BoardSize;
            ePlayerType secondPlayerType = r_GameSettingsForm.IsPc ? ePlayerType.Ai : ePlayerType.Human;
            Player player1 = new Player(player1Name, ePlayerType.Human, eColor.black);
            Player player2 = null;

            switch (secondPlayerType)
            {
                case ePlayerType.Human:
                    Player2Name = r_GameSettingsForm.Player2Name;
                    player2 = new Player(Player2Name, ePlayerType.Human, eColor.white);
                    break;

                case ePlayerType.Ai:
                    player2 = new Player("Computer", ePlayerType.Ai, eColor.white);
                    break;
            }

            m_CheckersLogic = new CheckersLogic.CheckersLogic(boardSize, player2, player1);
            m_CheckersLogic.LastMovePlayer = null;
            m_CheckersLogic.CurrentPlayer = m_CheckersLogic.BlackPlayer;
            m_CheckersLogic.Board.InitBoard(m_CheckersLogic.BoardSize);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            r_GameSettingsForm.FormClosed += this.r_GameSettingsForm_Closed;
            r_GameSettingsForm.ShowDialog();
            if (r_GameSettingsForm.SettingsFormClosedByDone)
            {
                GameInit();
            }
            else
            {
                this.Close();
            }
        }

        private void r_GameSettingsForm_Closed(object sender, EventArgs e)
        {
            buildBoardUI();
            initBoardUI();
        }

        private void buildBoardUI()
        {
            int boardSize = r_GameSettingsForm.BoardSize;
            int cellNumber = 0;

            m_ButtonMatrix = new Button[r_GameSettingsForm.BoardSize, r_GameSettingsForm.BoardSize];
            this.ClientSize = new Size(boardSize * 50, boardSize * 50);
            Player1NameLabel.Text = r_GameSettingsForm.Player1Name;
            Player2NameLabel.Text = r_GameSettingsForm.Player2Name;
            Player1ScoreLabel.Text = "0";
            Player2ScoreLabel.Text = "0";
            this.Controls.Add(Player1NameLabel);
            this.Controls.Add(Player2NameLabel);
            this.Controls.Add(Player1ScoreLabel);
            this.Controls.Add(Player2ScoreLabel);

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    m_ButtonMatrix[i, j] = new Button();
                    m_ButtonMatrix[i, j].Width = 50;
                    m_ButtonMatrix[i, j].Height = 50;
                    m_ButtonMatrix[i, j].Location = new Point(i * 50, (j * 50) + 40);
                    m_ButtonMatrix[i, j].Tag = cellNumber;
                    m_ButtonMatrix[i, j].Click += Button_Click;

                    cellNumber++;

                    this.Controls.Add(m_ButtonMatrix[i, j]);

                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1))
                    {
                        m_ButtonMatrix[i, j].BackColor = Color.Black;
                        m_ButtonMatrix[i, j].Enabled = false;
                    }
                    else
                    {
                        m_ButtonMatrix[i, j].BackColor = Color.White;
                    }
                }
            }
        }

        private void initBoardUI()
        {
            int col;
            int boardSize = r_GameSettingsForm.BoardSize;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    m_ButtonMatrix[i, j].BackgroundImage = null;
                }
            }

            for (int row = 0; row < (boardSize - 2) / 2; row++)
            {
                if (row % 2 == 0)
                {
                    col = 1;
                }
                else
                {
                    col = 0;
                }

                for (; col < boardSize; col += 2)
                {
                    m_ButtonMatrix[col, row].BackgroundImage = Ex05_UI.Properties.Resources.whiteChecker;
                    m_ButtonMatrix[col, row].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }

            for (int row = (boardSize / 2) + 1; row < boardSize; row++)
            {
                if (row % 2 == 0)
                {
                    col = 1;
                }
                else
                {
                    col = 0;
                }

                for (; col < boardSize; col += 2)
                {
                    m_ButtonMatrix[col, row].BackgroundImage = Ex05_UI.Properties.Resources.blackChecker;
                    m_ButtonMatrix[col, row].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void markChecker()
        {
            if (m_CheckersLogic.Board[m_RowOfCellClicked, m_ColOfCellClicked] != null && m_CheckersLogic.Board[m_RowOfCellClicked, m_ColOfCellClicked].Color == m_CheckersLogic.CurrentPlayer.color)
            {
                m_LastClickedPosition = new Position(m_RowOfCellClicked, m_ColOfCellClicked);
                if (m_CheckersLogic.Board[m_RowOfCellClicked, m_ColOfCellClicked].isKing)
                {
                    if (m_CheckersLogic.CurrentPlayer.color == eColor.black)
                    {
                        m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.blackCheckerKingMarked;
                    }
                    else
                    {
                        m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.whiteCheckerKingMarked;
                    }
                }
                else
                {
                    if (m_CheckersLogic.CurrentPlayer.color == eColor.black)
                    {
                        m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.blackCheckerMarked;
                    }
                    else
                    {
                        m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.whiteCheckerMarked;
                    }
                }
            }
        }

        private void unMarkChecker()
        {
            if (m_CheckersLogic.Board[m_RowOfCellClicked, m_ColOfCellClicked].isKing)
            {
                if (m_CheckersLogic.CurrentPlayer.color == eColor.black)
                {
                    m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.blackKingChecker;
                }
                else
                {
                    m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.whiteKingChecker;
                }
            }
            else
            {
                if (m_CheckersLogic.CurrentPlayer.color == eColor.black)
                {
                    m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.blackChecker;
                }
                else
                {
                    m_ButtonMatrix[m_ColOfCellClicked, m_RowOfCellClicked].BackgroundImage = Ex05_UI.Properties.Resources.whiteChecker;
                }
            }

            m_LastClickedPosition = null;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int cellNumber = (int)(sender as Button).Tag;
            m_RowOfCellClicked = cellNumber % r_GameSettingsForm.BoardSize;
            m_ColOfCellClicked = cellNumber / r_GameSettingsForm.BoardSize;
            Move nextMove;
            bool moveExecuted;

            if (m_LastClickedPosition is null)
            {
                markChecker();
            }
            else if (m_RowOfCellClicked == m_LastClickedPosition.row && m_ColOfCellClicked == m_LastClickedPosition.col)
            {
                unMarkChecker();
            }
            else 
            {
                nextMove = getNextMove(m_CheckersLogic.CurrentPlayer, m_RowOfCellClicked, m_ColOfCellClicked);
                moveExecuted = m_CheckersLogic.ExecuteMove(nextMove);
                if (!moveExecuted)
                {
                    MessageBox.Show("Invalid Move!");
                }
                else
                {
                    ExecuteMoveInUI(nextMove);
                    m_LastClickedPosition = null;
                    checkIfWinnerOrTie();
                    if (m_CheckersLogic.CurrentPlayer.IsComputer)
                    {
                        timer1.Start();
                    }
                }
            }
        }

        private void checkIfWinnerOrTie()
        {
            Player winner;
            DialogResult result;

            winner = m_CheckersLogic.Board.CheckIfThereISAWinner(m_CheckersLogic.BlackPlayer, m_CheckersLogic.WhitetPlayer);
            if (winner != null)
            {
                winner.Score += m_CheckersLogic.Board.EvaluatePlayersCheckers(winner);

                result = MessageBox.Show(
                    $"CONGRATULATIONS! the winner is: {winner.Name}" + Environment.NewLine + $"Another Round?",
                    "Damka",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    startOver();
                }
            }
            else if (m_CheckersLogic.Board.CheckIfThereIsATie())
            {
                result = MessageBox.Show("IT'S A TIE !", "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    startOver();
                }
            }
        }

        private void startOver()
        {
            Player1ScoreLabel.Text = m_CheckersLogic.BlackPlayer.Score.ToString();
            Player2ScoreLabel.Text = m_CheckersLogic.WhitetPlayer.Score.ToString();
            m_CheckersLogic.Board.InitBoard(m_CheckersLogic.BoardSize);
            m_CheckersLogic.CurrentPlayer = m_CheckersLogic.BlackPlayer;
            initBoardUI();
        }

        private void ExecuteMoveInUI(Move i_NextMove)
        {
            int colFrom = i_NextMove.GetMoveCheckerFrom.col;
            int rowFrom = i_NextMove.GetMoveCheckerFrom.row;
            int colTo = i_NextMove.GetMoveCheckerTo.col;
            int rowTo = i_NextMove.GetMoveCheckerTo.row;

            m_ButtonMatrix[colFrom, rowFrom].BackgroundImage = null;

            if (Math.Abs(rowTo - rowFrom) == 2)
            {
                m_ButtonMatrix[(colTo + colFrom) / 2, (rowFrom + rowTo) / 2].BackgroundImage = null;
            }

            if (m_CheckersLogic.Board[rowTo, colTo].isKing)
            {
                if (m_CheckersLogic.Board[rowTo, colTo].Color == eColor.black)
                {
                    m_ButtonMatrix[colTo, rowTo].BackgroundImage = Ex05_UI.Properties.Resources.blackKingChecker;
                }
                else
                {
                    m_ButtonMatrix[colTo, rowTo].BackgroundImage = Ex05_UI.Properties.Resources.whiteKingChecker;
                }
            }
            else
            {
                if (m_CheckersLogic.Board[rowTo, colTo].Color == eColor.black)
                {
                    m_ButtonMatrix[colTo, rowTo].BackgroundImage = Ex05_UI.Properties.Resources.blackChecker;
                }
                else
                {
                    m_ButtonMatrix[colTo, rowTo].BackgroundImage = Ex05_UI.Properties.Resources.whiteChecker;
                }
            }

            m_ButtonMatrix[colTo, rowTo].BackgroundImageLayout = ImageLayout.Stretch;
        }
    
        private Move getNextMove(Player i_CurrentPlayer, int i_RowOfCellClicked, int i_ColOfCellClicked)
        {
            Move nextMove = null;

            if (i_CurrentPlayer.IsComputer)
            {
                nextMove = m_CheckersLogic.GetNextMoveFromAI();
            }
            else
            {
                nextMove = new Move(m_LastClickedPosition, new Position(i_RowOfCellClicked, i_ColOfCellClicked));
            }

            return nextMove;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Move nextMove = getNextMove(m_CheckersLogic.CurrentPlayer, m_RowOfCellClicked, m_ColOfCellClicked);
            m_CheckersLogic.ExecuteMove(nextMove);
            ExecuteMoveInUI(nextMove);
            checkIfWinnerOrTie();
            timer1.Stop();
        }
    }
}
