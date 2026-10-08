using Space_Invaders_starter.Utils;
using Raylib_cs;

namespace Space_Invaders_starter.GameObjects
{
    public class Enemy : GameObject
    {
        private float direction = 1.0f;

        public Enemy(Vector2D position) : base(position, Constants.ENEMY_SIZE, Color.Red)
        {
        }

        public override void Update()
        {
            float moveX = direction * Constants.ENEMY_SPEED;
            Move(new Vector2D(moveX, 0));

            if (Position.X + Size.X / 2 >= Constants.WINDOW_WIDTH || Position.X - Size.X / 2 <= 0)
            {
                SwitchDirection();
            }
        }

        public void SwitchDirection()
        {
            direction *= -1.0f;
            Move(new Vector2D(0, Constants.ENEMY_DROP_DISTANCE));
        }
    }
}