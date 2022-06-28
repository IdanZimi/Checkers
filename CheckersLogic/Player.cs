namespace CheckersLogic
{
    public class Player
    {
        private readonly ePlayerType r_Type;
        private readonly eColor r_playerColor;
        private readonly string r_Name;
        private int m_Score;

        public eColor color
        {
            get { return r_playerColor; }
        }

        public string Name
        {
            get { return r_Name; }
        }

        public int Score
        {
            get { return m_Score; }
            set
            {
                if (value >= 0)
                {
                    m_Score = value;
                }
            }
        }

        public bool IsComputer
        {
            get { return r_Type == ePlayerType.Ai; }
        }

        public Player(string i_Name, ePlayerType i_Type, eColor i_PlayerColor)
        {
            r_Name = i_Name;
            r_Type = i_Type;
            r_playerColor = i_PlayerColor;
            m_Score = 0;
        }
    }
}