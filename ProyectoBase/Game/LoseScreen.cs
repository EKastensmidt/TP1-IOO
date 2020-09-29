﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void LoseCondition();
    public class LoseScreen
    {
        public const string TEXTURE = "Textures/Screens/gameOver.png";
        public LoseCondition OnLose;
        public LoseScreen()
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
            Engine.Draw("Textures/Escape.png", 50, 700, 0.5f, 0.5f);
            Engine.Draw(TEXTURE, 150, 250);
        }
    }
}
