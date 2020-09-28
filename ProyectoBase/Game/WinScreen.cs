using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void WinCondition();
    public class WinScreen
    {
        public const string TEXTURE = "Textures/Screens/youWin.png";
        public WinCondition OnWin;
        public WinScreen()
        {

        }
        public void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.ChangeGameState(GameState.MainMenu);
            }
        }
        public void Render()
        {
            Engine.Draw("Textures/Background.png");

            Engine.Draw(TEXTURE, 0, 0);
        }
    }
}
