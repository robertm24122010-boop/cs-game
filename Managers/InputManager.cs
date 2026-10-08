using Space_Invaders_starter.GameObjects;
using Space_Invaders_starter.Utils;
using Raylib_cs;

namespace Space_Invaders_starter.Managers
{
    public static class InputManager
    {
        public static void HandleInput(Player player, List<Bullet> bullets)
        {
            if(Raylib.IsKeyDown(KeyboardKey.Left))
            {
                player.MoveLeft();
            }
            if(Raylib.IsKeyDown(KeyboardKey.Right))
            {
                player.MoveRight();
            }
            if(Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                bullets.Add(player.Shoot());
            }
        }
    }
}