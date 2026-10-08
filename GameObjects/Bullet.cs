using Space_Invaders_starter.Utils;
using Raylib_cs;

namespace Space_Invaders_starter.GameObjects
{
    public class Bullet : GameObject
    {
        public bool IsPlayerBullet { get; }

        public Bullet(Vector2D position, bool isPlayerBullet) :
            base(position, Constants.BULLET_SIZE, Color.White)
        {
            IsPlayerBullet = isPlayerBullet;
        }

        public override void Update()
        {
            Move(new Vector2D(0, IsPlayerBullet ? -Constants.BULLET_SPEED : Constants.BULLET_SPEED));
        }
    }
}