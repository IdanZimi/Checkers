using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersLogic;

namespace Ex05_UI
{
    public class CheckersGame
    {
        private GameForm m_GameForm = new GameForm();

        public void Run() 
        {
            m_GameForm.ShowDialog();
        }
    }
}
