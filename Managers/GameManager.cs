using System;
using System.Collections.Generic;
using Space_Invaders_starter.GameObjects; // <--- TO NAPRAWIA CS0246
using Space_Invaders_starter.Utils;

namespace Space_Invaders_starter.Managers
{
    public static class GameManager
    {
        public static Player player;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();
        public static int score = 0;
        public static int level = 1;
        public static GameState gameState = GameState.Playing;

        private static Random random = new Random();

        // Domyślna wartość (100) naprawia wywołania bez argumentu AddScore()
        public static void AddScore(int value = 100)
        {
            score += value;
        }

        public static void SetGameState(GameState state)
        {
            gameState = state;
        }

        public static void ResetGame()
        {
            level = 1;
            score = 0;
            Initialize();
        }

        public static void Initialize()
        {
            player = new Player();
            bullets = new List<Bullet>();
            enemies = new List<Enemy>();
            gameState = GameState.Playing;

            int rows = 5;
            int cols = 8;
            float startX = 100;
            float startY = 50;
            float spacingX = 60;
            float spacingY = 50;

            double spawnChance = Math.Min(0.40 + (level * 0.05), 0.85);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (random.NextDouble() < spawnChance)
                    {
                        Vector2D pos = new Vector2D(startX + c * spacingX, startY + r * spacingY);
                        enemies.Add(new Enemy(pos));
                    }
                }
            }

            if (enemies.Count == 0)
            {
                enemies.Add(new Enemy(new Vector2D(startX, startY)));
            }
        }

        public static void Update()
        {
            if (gameState != GameState.Playing)
                return;

            InputManager.HandleInput(player, bullets);

            player.Update();

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update();

                if (bullets[i].Position.Y < 0)
                {
                    bullets.RemoveAt(i);
                }
            }

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Update();
            }

            CollisionManager.HandleCollisions(player, enemies, bullets);

            if (enemies.Count == 0)
            {
                NextLevel();
            }
        }

        public static void Draw()
        {
            Raylib_cs.Raylib.BeginDrawing();
            Raylib_cs.Raylib.ClearBackground(Raylib_cs.Color.Black);

            player.Draw();

            foreach (var bullet in bullets)
            {
                bullet.Draw();
            }

            foreach (var enemy in enemies)
            {
                enemy.Draw();
            }

            Raylib_cs.Raylib.DrawText($"Score: {score}", 10, 10, 20, Raylib_cs.Color.White);
            Raylib_cs.Raylib.DrawText($"Level: {level}", 10, 35, 20, Raylib_cs.Color.White);

            if (gameState == GameState.Lost)
            {
                Raylib_cs.Raylib.DrawText("GAME OVER", 300, 280, 40, Raylib_cs.Color.Red);
            }
            else if (gameState == GameState.Won)
            {
                Raylib_cs.Raylib.DrawText("YOU WIN!", 320, 280, 40, Raylib_cs.Color.Green);
            }

            Raylib_cs.Raylib.EndDrawing();
        }

        private static void NextLevel()
        {
            level++;
            Initialize();
        }
    }
}