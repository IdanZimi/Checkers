using System;
using System.Collections.Generic;

namespace CheckersLogic
{
    public class CheckersLogic
    {
        private readonly int r_BoardSize;
        private Board m_Board;
        private Player m_WhitePlayer;
        private Player m_BlackPlayer;
        private Player m_LastMovePlayer;
        private Player m_CurrentPlayer;

        public Board Board
        {
            get { return m_Board; }
        }

        public Player WhitetPlayer
        {
            get { return m_WhitePlayer; }
        }

        public Player BlackPlayer
        {
            get { return m_BlackPlayer; }
        }

        public int BoardSize
        {
            get { return r_BoardSize; }
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
        }

        public Player LastMovePlayer
        {
            get { return m_LastMovePlayer; }
            set { m_LastMovePlayer = value; }
        }

        public CheckersLogic(int i_BoardSize, Player i_Player1, Player i_Player2)
        {
            m_WhitePlayer = i_Player1;
            m_BlackPlayer = i_Player2;
            m_CurrentPlayer = m_BlackPlayer;
            m_LastMovePlayer = null;
            r_BoardSize = i_BoardSize;
            m_Board = new Board(i_BoardSize);
        }

        public void SwitchCurrentPlayer()
        {
            m_CurrentPlayer = opponent(m_CurrentPlayer);
        }

        public bool ExecuteMove(Move i_NextMove, Board i_Board = null)
        {
            Board board = i_Board == null ? m_Board : i_Board;
            bool moveExecuted = false;
            int rowTo = i_NextMove.GetMoveCheckerTo.row;
            int rowFrom = i_NextMove.GetMoveCheckerFrom.row;
            int colTo = i_NextMove.GetMoveCheckerTo.col;
            int colFrom = i_NextMove.GetMoveCheckerFrom.col;

            if (board.CheckIfMoveIsValid(i_NextMove, m_CurrentPlayer))
            {
                board[rowTo, colTo] = board[rowFrom, colFrom];
                board[rowFrom, colFrom] = null;
                moveExecuted = true;
                LastMovePlayer = m_CurrentPlayer;

                if (Math.Abs(rowTo - rowFrom) == 2)
                {
                    board[(rowFrom + rowTo) / 2, (colTo + colFrom) / 2] = null;
                    if (!board.GetPossibleMoves(rowTo, colTo).Exists(x => Math.Abs(rowTo - x.row) == 2))
                    {
                        board[rowTo, colTo].madeSkip = false;
                        if (board == m_Board)
                        {
                            SwitchCurrentPlayer();
                        }
                    }
                }
                else
                {
                    board[rowTo, colTo].madeSkip = false;
                    if (board == m_Board)
                    {
                        SwitchCurrentPlayer();
                    }
                }
                ////check if became king 
                if ((rowTo == 0 && board[rowTo, colTo].Color == eColor.black) || (rowTo == r_BoardSize - 1 && board[rowTo, colTo].Color == eColor.white))
                {
                    board[rowTo, colTo].isKing = true;
                }
            }

            return moveExecuted;
        }

        public Move GetNextMoveFromAI()
        {
            int depth = 3; 
            int alpha = int.MinValue;
            int newScore;
            Move bestMove = null;
            List<Move> allComputersPossibleMoves = m_Board.GetPlayerAllPossibleMoves(m_CurrentPlayer);
            Board boardAfterMove;
            
            foreach (Move move in allComputersPossibleMoves)
            {
                boardAfterMove = new Board(m_Board);
                ExecuteMove(move, boardAfterMove);
                newScore = -Negamax(boardAfterMove, depth - 1, opponent(m_CurrentPlayer), int.MinValue, -alpha);
                if (newScore > alpha)
                {
                    alpha = newScore;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        private Player opponent(Player i_CurrPlayer)
        {
            Player opponentPlayer = null;

            switch (i_CurrPlayer.color)
            {
                case eColor.black:
                    opponentPlayer = WhitetPlayer;
                    break;
                case eColor.white:
                    opponentPlayer = BlackPlayer;
                    break;
            }

            return opponentPlayer;
        }

        private int Negamax(Board i_Board, int i_Depth, Player i_CurrPlayer, int i_Alpha, int i_Beta)
        {
            List<Move> allCurrPlayerPossibleMoves = i_Board.GetPlayerAllPossibleMoves(i_CurrPlayer);
            Board boardAfterMove;

            if (i_Depth == 0)
            {
                return i_Board.EvaluatePlayersCheckers(m_BlackPlayer);
            }

            foreach (Move move in allCurrPlayerPossibleMoves)
            {
                boardAfterMove = new Board(i_Board);
                ExecuteMove(move, boardAfterMove);

                int newScore = -Negamax(boardAfterMove, i_Depth - 1, opponent(i_CurrPlayer), -i_Beta, -i_Alpha);
                if (newScore >= i_Beta)
                {
                    return newScore;
                }

                if (newScore > i_Alpha)
                {
                    i_Alpha = newScore;
                }
            }

            return i_Alpha;
        }
    }
}