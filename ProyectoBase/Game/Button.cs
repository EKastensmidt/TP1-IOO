using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button
    {
        #region • Private fields/variables (9)
        private float posX;
        private float posY;
        private float escalaX;
        private float escalaY;
        private Button botonUp;
        private Button botonDown;
        private string texture;
        private float timer = 0f;
        private float tiempoParaApretar = 0.25f;
        #endregion

        #region • Public fields/variables (2)
        public float PosY { get => posY; set => posY = value; }
        public float PosX { get => posX; set => posX = value; }
        #endregion

        public Button(float posX, float posY, string texture, float escalaX, float escalaY)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.texture = texture;
            this.escalaX = escalaX;
            this.escalaY = escalaY;
        }

        public void Buttons(Button up, Button down)
        {
            botonUp = up;
            botonDown = down;
        }

        public Button Update()
        {
            timer += Program.DeltaTime;

            if (Engine.GetKey(Keys.W) && timer >= tiempoParaApretar)
            {
                timer = 0f;
                return GetUp();
            }
            else if (Engine.GetKey(Keys.S) && timer >= tiempoParaApretar)
            {
                timer = 0f;
                return GetDown();
            }
            else return this;
        }

        public void Render()
        {
            Engine.Draw(texture, PosX, PosY, escalaX, escalaY);
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