using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        private float angle;
        private float scale;
        private float speed;
        private bool isMoveRightKeyPressed;
        private bool isMoveLeftKeyPressed;
        private bool isShootingKeyPressed;
        private float currentShootingCooldown;
        private float shootingCooldown = 0.5f;
        private LifeController lifeController;
        private Animation idleAnimation;
        private Animation currentAnimation;
        public Vector2 Position { get; set; } = Vector2.Zero;

        public Player (Vector2 position,float scale,float angle,float speed, int maxLife)
        {
            Position = position;
            this.lifeController = new LifeController(maxLife);
            this.scale = scale;
            this.angle = angle;
            this.speed = speed;

            CreateAnimations();
            currentAnimation = idleAnimation;
        }
        public void Update()
        {
            currentShootingCooldown -= Program.DeltaTime;
            if (isMoveRightKeyPressed)
            {
                Position = new Vector2(Position.X + speed * Program.DeltaTime, Position.Y);
            }
            else if (isMoveLeftKeyPressed)
            {
                Position = new Vector2(Position.X - speed * Program.DeltaTime, Position.Y);
            }
            if (isShootingKeyPressed && currentShootingCooldown <= 0)
            {
                ShootBullet();
            }
            currentAnimation.Update();
        }
        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, Position.X, Position.Y, scale, scale, angle, GetOffsetX(), GetOffsetY());
        }

        public void InputDetection()
        {
            isMoveLeftKeyPressed = Engine.GetKey(Keys.A);
            isMoveRightKeyPressed = Engine.GetKey(Keys.D);
            isShootingKeyPressed = Engine.GetKey(Keys.SPACE);
        }

        private void ShootBullet()
        {
            currentShootingCooldown = shootingCooldown;
            Bullet bullet = new Bullet(Position, 0.75f, 0f, 300f, 50);
        }

        private float GetOffsetX()
        {
            return (currentAnimation.CurrentFrame.Width * scale) / 2f;
        }

        private float GetOffsetY()
        {
            return (currentAnimation.CurrentFrame.Height * scale) / 2f;
        }

        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 0; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Textures/Player/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation(idleTextures, 0.1f, true, "Idle");
        }
    }
}
