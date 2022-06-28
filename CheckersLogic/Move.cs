namespace CheckersLogic
{
    public class Move
    {
        private Position m_moveCheckerfrom;
        private Position m_moveCheckerTo;

        public Position GetMoveCheckerFrom
        {
            get { return m_moveCheckerfrom; }
            set { m_moveCheckerfrom = value; }
        }

        public Position GetMoveCheckerTo
        {
            get { return m_moveCheckerTo; }
            set { m_moveCheckerTo = value; }
        }

        public Move(Position i_MoveCheckerFrom, Position i_MoveCheckerTo)
        {
            m_moveCheckerfrom = i_MoveCheckerFrom;
            m_moveCheckerTo = i_MoveCheckerTo;
        }
    }
}
