using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu
    {
        private Arrow arrow;
        private Button newGame;
        private Button credits;
        private Button quit;
        private Button currentButton;
        private List<Button> buttons = new List<Button>();
        public MainMenu()
        {
            newGame = new Button(250f, 300f, "Textures/Buttons/start.png", 1f, 1f);
            buttons.Add(newGame);
            credits = new Button(225f, 450f, "Textures/Buttons/credits.png", 1f, 1f);
            buttons.Add(credits);
            quit = new Button(250f, 600f, "Textures/Buttons/quit.png", 1f, 1f);
            buttons.Add(quit);

            newGame.Buttons(null, credits);
            credits.Buttons(newGame, quit);
            quit.Buttons(credits, null);

            currentButton = newGame;
            arrow = new Arrow();
            arrow.Update(currentButton.PosX, currentButton.PosY);
        }
        public void Update()
        {
            currentButton = currentButton.Update();
            arrow.Update(currentButton.PosX, currentButton.PosY);
            if (Engine.GetKey(Keys.SPACE))
            {
                EnterButton();
            }
        }
        public void Render()
        {
            Engine.Draw("Textures/Background.png");
            Engine.Draw("Textures/Title.png", 75, 50, 1f, 1f);

            foreach (var button in buttons)
            {
                button.Render();
            }
            arrow.Render();
        }
        private void EnterButton()
        {
            if (currentButton == newGame)
            {
                GameManager.Instance.ChangeGameState(GameState.Level);
            }
            else if (currentButton == credits)
            {
                GameManager.Instance.ChangeGameState(GameState.Credits);
            }
            else if (currentButton == quit)
            {
                Environment.Exit(1);
            }
        }
    }
    
}
