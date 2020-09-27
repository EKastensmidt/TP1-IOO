using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        #region • Private fields/variables
        private static float deltaTime;
        private static DateTime startTime;
        private static float lastFrameTime;
        private float eY = -200;
        #endregion

        public static float DeltaTime { get => deltaTime;}


        public static Player player;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();

        static void Main(string[] args)
        {
            Initialization();
            while(true)
            {
                InputDetection();
                Update();
                Render();
            }
        }
        private static void Initialization()
        {
            startTime = DateTime.Now;
            Engine.Initialize("Jueguito",800,800);
            player = new Player(new Vector2(400, 750), 1f, 0f, 200, 100);

            Random random = new Random();

            float x = 0;
            float y = -200;

            for (int j = 0; j < 5; j++)
            {
                y += 100;
                x = 0;
                for (int i = 0; i < 7; i++)
                {
                    x += 100;
                    Enemy enemy = new Enemy(new Vector2(x, y), 0.75f, 0f, 100f, 100);
                    enemies.Add(enemy);
                }
            }
        }
        
        private static void InitAudio()
        {

        }
        
        private static void Update()
        {
            UpdateTime();
            if (player!= null)
            {
                player.Update();
            }
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update();
            }
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Update();
            }
        }
        private static void InputDetection()
        {
            player.InputDetection();
        }
        private static void Render()
        {
            Engine.Clear();
            if (player != null)
            {
                player.Render();
            }
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Render();
            }
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Render();
            }
            Engine.Show();
        }
        
        private static void UpdateTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }

    }
}