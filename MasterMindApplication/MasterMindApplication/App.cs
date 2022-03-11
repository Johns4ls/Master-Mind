using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindApplication
{
    public class App
    {
        #region Main Method
        public static void Main()
        {
            //Instantiate our Mastermind game object
            MasterMind masterMind = new MasterMind();
            //Start the game
            masterMind.StartGame();
        }
        #endregion
    }
}
