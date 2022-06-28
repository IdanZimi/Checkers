namespace CheckersLogic
{
    public class Position
    {
        private int m_Row;
        private int m_Col;

        public int row
        {
            get { return m_Row; }
        }

        public int col
        {
            get { return m_Col; }
        }

        public Position(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }

        public override bool Equals(object obj)
        {
            Position position = obj as Position;
            return position.col == m_Col && position.row == m_Row; 
        }
    }
}
