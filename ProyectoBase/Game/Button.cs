using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button
    {
        private float posX;
        private float posY;
        private float escalaX;
        private float escalaY;
        private Button botonUp;
        private Button botonDown;
        private string texture;
        private float timer = 0f;
        private float tiempoParaApretar = 0.25f;

        public Button(float posX, float posY, string texture, float escalaX, float escalaY)
        {
            this.posX = posX;
            this.posY = posY;
            this.texture = texture;
            this.escalaX = escalaX;
            this.escalaY = escalaY;
        }
        void Buttons(Button up, Button down)
        {
            botonUp = up;
            botonDown = down;
        }
        public Button Update()
        {
            timer += Program.DeltaTime;

            if (Engine.GetKey(Keys.UP) && timer >= tiempoParaApretar)
            {
                timer = 0f;
                return GetUp();
            }
            else if (Engine.GetKey(Keys.DOWN) && timer >= tiempoParaApretar)
            {
                timer = 0f;
                return GetDown();
            }
            else return this;
        }
        public void Draw()
        {
            Engine.Draw(texture, posX, posY, escalaX, escalaY);
        }

        public Button GetUp()
        {
            if (botonUp != null)
            {
                return botonUp;
            }
            else return this;
        }

        public Button GetDown()
        {
            if (botonDown != null)
            {
                return botonDown;
            }
            else return this;
        }
    }
}
