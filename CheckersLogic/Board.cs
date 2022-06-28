using System;
using System.Collections.Generic;

namespace CheckersLogic
{
    public class Board
    {
        private readonly int r_BoardSize;
        private Checker[,] m_Board;

        public Board(int i_BoardSize)
        {
            m_Board = new Checker[i_BoardSize, i_BoardSize];
            r_BoardSize = i_BoardSize;
        }

        public Board(Board i_Board)
        {
            r_BoardSize = i_Board.r_BoardSize;
            m_Board = new Checker[r_BoardSize, r_BoardSize];

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    if (!(i_Board[row, col] is null))
                    {
                        m_Board[row, col] = new Checker(i_Board[row, col]);
                    }
                }
            }
        }

        public Checker this[int i_Row, int i_Col]
        { // used Indexers, instead operator overloading
            get
            {
                return m_Board[i_Row, i_Col];
            }

            set
            {
                m_Board[i_Row, i_Col] = value;
            }
        }

        public void InitBoard(int i_MatrixSize)
        {
            int row;
            int col;

            for (row = (i_MatrixSize - 2) / 2; row < (i_MatrixSize + 2) / 2; row++)
            {
                for (col = 0; col < i_MatrixSize; col++)
                {
                    m_Board[row, col] = null; 
                }
            }
            
            for (row = 0; row < (i_MatrixSize - 2) / 2; row++)
            {
                if (row % 2 == 0)
                {
                    col = 1;
                }
                else
                {
                    col = 0;
                }

                for (; col < i_MatrixSize; col += 2)
                {
                    m_Board[row, col] = new Checker(eColor.white);
                }
            }

            for (row = (i_MatrixSize / 2) + 1; row < i_MatrixSize; row++)
            {
                if (row % 2 == 0)
                {
                    col = 1;
                }
                else
                {
                    col = 0;
                }

                for (; col < i_MatrixSize; col += 2)
                {
                    m_Board[row, col] = new Checker(eColor.black);
                }
            }
        }

        public int CountWhiteCheckers()
        {
            int countPlayer1Checkers = 0; 

            foreach (Checker checker in m_Board)
            {
                if (checker != null)
                {
                    if (checker.Color == eColor.white)
                    {
                        countPlayer1Checkers++;
                    }
                }
            }
            
            return countPlayer1Checkers;
        }

        public int CountBlackCheckers()
        {
            int countPlayer2Checkers = 0;

            foreach (Checker checker in m_Board)
            {
                if (checker != null)
                {
                    if (checker.Color == eColor.black)
                    {
                        countPlayer2Checkers++;
                    }
                }
            }

            return countPlayer2Checkers;
        }

        public List<Position> GetPossibleMoves(int i_Row, int i_Col)
        {
            List<Position> listOfPossibleMoves = new List<Position>();
            Checker checker = m_Board[i_Row, i_Col];

            if (checker.Color == eColor.black || (checker.Color == eColor.white && checker.isKing)) 
            { //// check Up
                CheckDirection(listOfPossibleMoves, i_Row, i_Col, -1, 1); //// up right 
                CheckDirection(listOfPossibleMoves, i_Row, i_Col, -1, -1); //// up left
            }
            
            if (checker.Color == eColor.white || (checker.Color == eColor.black && checker.isKing)) 
            { //// check down
                CheckDirection(listOfPossibleMoves, i_Row, i_Col, 1, 1); //// down right
                CheckDirection(listOfPossibleMoves, i_Row, i_Col, 1, -1); //// down left
            }

            updateListIfPlayerHasToSkip(listOfPossibleMoves, i_Row);

            return listOfPossibleMoves;
        }

        public void CheckDirection(List<Position> io_ListOfPossibleMoves, int i_Row, int i_Col, int i_VerticalOffSet, int i_HorizontalOffSet)
        {
            Checker checker = m_Board[i_Row, i_Col];

            if (checkInBoardLimit(i_Row + i_VerticalOffSet, i_Col + i_HorizontalOffSet))
            {
                if (m_Board[i_Row + i_VerticalOffSet, i_Col + i_HorizontalOffSet] == null && !checker.madeSkip)
                {
                    io_ListOfPossibleMoves.Add(new Position(i_Row + i_VerticalOffSet, i_Col + i_HorizontalOffSet)); 
                }
                else
                {
                    if (m_Board[i_Row + i_VerticalOffSet, i_Col + i_HorizontalOffSet].Color != checker.Color && checkInBoardLimit(i_Row + (i_VerticalOffSet * 2), i_Col + (i_HorizontalOffSet * 2)))    
                    {
                        if (m_Board[i_Row + (i_VerticalOffSet * 2), i_Col + (i_HorizontalOffSet * 2)] == null)
                        {
                            io_ListOfPossibleMoves.Add(new Position(i_Row + (i_VerticalOffSet * 2), i_Col + (i_HorizontalOffSet * 2)));
                        }
                    }
                }
            }
        }

        private bool checkInBoardLimit(int i_Row, int i_Col)
        {
            return i_Row >= 0 && i_Row < r_BoardSize && i_Col >= 0 && i_Col < r_BoardSize;
        }

        private void updateListIfPlayerHasToSkip(List<Position> io_ListOfPossibleMoves, int i_Row)
        {
            bool hasToSkip = false;
            List<int> indexesTodelete = new List<int>(4);

            foreach (Position possibleMove in io_ListOfPossibleMoves)
            {
                if (Math.Abs(possibleMove.row - i_Row) == 2)
                {
                    hasToSkip = true;
                }
            }

            if (hasToSkip)
            {
                foreach (Position possibleMove in io_ListOfPossibleMoves)
                {
                    if (Math.Abs(possibleMove.row - i_Row) == 1)
                    {
                        indexesTodelete.Add(io_ListOfPossibleMoves.FindIndex(x => x.Equals(possibleMove))); 
                    }
                }

                for (int i = indexesTodelete.Count - 1; i >= 0; i--)
                {
                    io_ListOfPossibleMoves.RemoveAt(indexesTodelete[i]);
                }
            }
        }

        public bool CheckIfCheckerCanSkip(int i_Row, int i_Col)
        {
            return GetPossibleMoves(i_Row, i_Col).Exists(x => Math.Abs(i_Row - x.row) == 2);
        }

        public List<Move> GetPlayerAllPossibleMoves(Player i_CurrPlayer)
        {
            List<Move> allPossibleMoves = new List<Move>();
            List<Position> checkerPossibleMoves;
            Position currPosition;
            Move nextMove;

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    if (!(m_Board[row, col] is null) && m_Board[row, col].Color == i_CurrPlayer.color)
                    {
                        currPosition = new Position(row, col);
                        checkerPossibleMoves = GetPossibleMoves(row, col);

                        foreach (Position possibleMove in checkerPossibleMoves)
                        {
                            nextMove = new Move(currPosition, possibleMove);
                            if (CheckIfMoveIsValid(nextMove, i_CurrPlayer))
                            {
                                allPossibleMoves.Add(nextMove);
                            }
                        }
                    }
                }
            }

            return allPossibleMoves;
        }

        public bool CheckIfThereArePossibleMoves(eColor i_Color)
        {
            bool checkIfThereAreNoPossibleMovesRes = false;

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    if (m_Board[row, col] != null)
                    {
                        if (m_Board[row, col].Color == i_Color && GetPossibleMoves(row, col).Count != 0)
                        {
                            checkIfThereAreNoPossibleMovesRes = true;
                            break;
                        }
                    }
                }
            }

            return checkIfThereAreNoPossibleMovesRes;
        }

        public Player CheckIfThereISAWinner(Player i_BlackPlayer, Player i_WhitePlayer)
        {
            Player winnerPlayer = null;

            if (CountWhiteCheckers() == 0 || !CheckIfThereArePossibleMoves(eColor.white))
            {
                winnerPlayer = i_BlackPlayer;
            }
            else if (CountBlackCheckers() == 0 || !CheckIfThereArePossibleMoves(eColor.black))
            {
                winnerPlayer = i_WhitePlayer;
            }

            return winnerPlayer;
        }

        public bool CheckIfThereIsATie()
        {
            return !CheckIfThereArePossibleMoves(eColor.white) && !CheckIfThereArePossibleMoves(eColor.black);
        }

        public bool CheckIfMoveIsValid(Move i_NextMove, Player i_CurrPlayer)
        {
            bool checkIfMoveIsValidRes = true;
            List<Position> posibleMoves;

            if (m_Board[i_NextMove.GetMoveCheckerFrom.row, i_NextMove.GetMoveCheckerFrom.col] is null)
            {
                checkIfMoveIsValidRes = false;
            }

            if (checkIfMoveIsValidRes)
            {
                if (m_Board[i_NextMove.GetMoveCheckerFrom.row, i_NextMove.GetMoveCheckerFrom.col].Color != i_CurrPlayer.color)
                {
                    checkIfMoveIsValidRes = false;
                }
                
                posibleMoves = GetPossibleMoves(i_NextMove.GetMoveCheckerFrom.row, i_NextMove.GetMoveCheckerFrom.col);
                if (posibleMoves.Find(x => x.Equals(i_NextMove.GetMoveCheckerTo)) is null)
                {
                    checkIfMoveIsValidRes = false;
                }

                if (CheckIfOtherCheckerNeedsToSkip(i_NextMove.GetMoveCheckerFrom) && !CheckIfCheckerCanSkip(i_NextMove.GetMoveCheckerFrom.row, i_NextMove.GetMoveCheckerFrom.col))
                {
                    checkIfMoveIsValidRes = false;
                }
            }

            return checkIfMoveIsValidRes;
        }

        public bool CheckIfOtherCheckerNeedsToSkip(Position i_CheckerPos)
        {
            bool thereIsOtherCheckerWaitingToSkip = false;

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    if (!(m_Board[row, col] is null) && (row != i_CheckerPos.row || col != i_CheckerPos.col))
                    {
                        if (m_Board[row, col].Color == m_Board[i_CheckerPos.row, i_CheckerPos.col].Color)
                        {
                            if (CheckIfCheckerCanSkip(row, col))
                            {
                                thereIsOtherCheckerWaitingToSkip = true;
                            }
                        }
                    }
                }
            }

            return thereIsOtherCheckerWaitingToSkip;
        }

        public int EvaluatePlayersCheckers(Player i_Winner)
        {
            int addition;
            int res = 0;

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    if (m_Board[row, col] != null)
                    {
                        if (m_Board[row, col].Color == i_Winner.color)
                        {
                            addition = m_Board[row, col].isKing ? 4 : 1;
                        }
                        else
                        {
                            addition = m_Board[row, col].isKing ? -4 : -1;
                        }

                        res += addition;
                    }
                }
            }

            return res;
        }
    }
}
