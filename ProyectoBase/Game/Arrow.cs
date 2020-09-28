using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Arrow
    {
        private float posX;
        private float posY;
        private float offset = 30f;

        public void Update(float x, float y)
        {
            posX = x - offset;
            posY = y;
        }

        public void Render()
        {
            Engine.Draw("Textures/indicador.png", posX, posY, 0.05f, 0.05f, 0, 0, 0);
        }
    }
}
