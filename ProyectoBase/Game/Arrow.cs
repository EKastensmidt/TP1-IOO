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

        public void Draw()
        {
            Engine.Draw("Indicador.png", posX, posY, 0.15f, 0.15f, 0, 0, 0);
        }
    }
}
