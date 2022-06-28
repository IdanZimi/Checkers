using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_UI
{
    public class GameSettingsFilledEventArgs : EventArgs
    {
        private bool m_IsPc;
        private string m_Player1Name;
        private string m_Player2Name;
        private int m_BoardSize;

        public GameSettingsFilledEventArgs(bool i_IsPc, string i_Player1Name, string i_Player2Name, int i_BoardSize)
        {
            m_IsPc = i_IsPc;
            m_Player1Name = i_Player1Name;
            m_Player2Name = i_Player2Name;
            m_BoardSize = i_BoardSize;
        }

        public bool IsPc
        {
            get { return m_IsPc; }
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
        }

        public string Player2Name
        {
            get { return m_Player2Name; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
        }
    }
}
