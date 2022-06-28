namespace CheckersLogic
{
    public class Checker
    {
        private readonly eColor r_Color;
        private bool m_IsKing;
        private bool m_MadeSkip;

        public bool madeSkip
        {
            get { return m_MadeSkip; }
            set { m_MadeSkip = value; }
        }

        public bool isKing
        {
            get { return m_IsKing; }
            set { m_IsKing = value; }
        }

        public eColor Color
        {
            get { return r_Color; }
        }

        public Checker(eColor i_Color)
        {
            r_Color = i_Color;
            m_IsKing = false;
            m_MadeSkip = false;
        }

        public Checker(Checker i_Checker)
        {
            r_Color = i_Checker.Color;
            m_IsKing = i_Checker.isKing;
            m_MadeSkip = i_Checker.madeSkip;
        }
    }
}