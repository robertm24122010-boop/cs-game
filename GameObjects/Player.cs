using System;
using Space_Invaders_starter.Utils;
using Raylib_cs;

namespace Space_Invaders_starter.GameObjects
{
    public class Player : GameObject
    {
        public Player() : base(new Vector2D(400, 550), Constants.PLAYER_SIZE, Color.Blue)
        {
        }

        public void MoveLeft()
        {
            Move(new Vector2D(-Constants.PLAYER_SPEED, 0));
        }

        public void MoveRight()
        {
            Move(new Vector2D(Constants.PLAYER_SPEED, 0));
        }

        public override void Update()
        {
            var clampedX = Math.Clamp(Position.X, Size.X / 2, Constants.WINDOW_WIDTH - Size.X / 2);
            SetPosition(new Vector2D(clampedX, Position.Y));
        }

        public Bullet Shoot()
        {
            return new Bullet(new Vector2D(Position.X, Position.Y - Size.Y / 2), true);
        }
    }
}