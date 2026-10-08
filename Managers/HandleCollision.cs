using Space_Invaders_starter.GameObjects;
using Space_Invaders_starter.Utils;
using System.Collections.Generic;

namespace Space_Invaders_starter.Managers
{
    public static class CollisionManager
    {
        public static void HandleCollisions(Player player, List<Enemy> enemies, List<Bullet> bullets)
        {
            foreach (var bullet in bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (bullet.CollidesWith(enemy))
                    {
                        bullet.IsActive = false;
                        enemy.IsActive = false;
                        GameManager.AddScore(100); // Dodano argument punktów
                    }
                }
            }
            bullets.RemoveAll(b => !b.IsActive);
            enemies.RemoveAll(e => !e.IsActive);

            foreach (var enemy in enemies)
            {
                if (enemy.CollidesWith(player))
                {
                    player.IsActive = false;
                    GameManager.SetGameState(GameState.Lost);
                    break;
                }
            }

            foreach (var enemy in enemies)
            {
                if (enemy.Position.Y + enemy.Size.Y / 2 >= Constants.WINDOW_HEIGHT)
                {
                    GameManager.SetGameState(GameState.Lost);
                    break;
                }
            }
        }
    }
}