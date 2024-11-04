using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint_2
{
    public class HUD
    {
        private SpriteFont font;
        private int score;
        private int coins;
        private string world;
        private int time;
        private int lives;
        private List<ScorePopup> scorePopups;

        public HUD(SpriteFont font)
        {
            this.font = font;
            score = 0;
            coins = 0;
            world = "1-1";
            time = 400;
            lives = 3;
            scorePopups = new List<ScorePopup>();
        }

        public void AddScore(int points, Vector2 position)
        {
            score += points;
            scorePopups.Add(new ScorePopup(points, position));
        }

        public void Update(GameTime gameTime)
        {
            time -= (int)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = scorePopups.Count - 1; i >= 0; i--)
            {
                scorePopups[i].Update(gameTime);
                if (scorePopups[i].IsExpired)
                {
                    scorePopups.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // 定义顶部元素的起始位置和间隔
            Vector2 startPosition = new Vector2(50, 10);
            int spacing = 150;  // 每个元素之间的间隔

            // 绘制并排的 HUD 元素
            spriteBatch.DrawString(font, $"Score: {score}", startPosition, Color.White);
            spriteBatch.DrawString(font, $"Coins: {coins}", startPosition + new Vector2(spacing, 0), Color.Yellow);
            spriteBatch.DrawString(font, $"World: {world}", startPosition + new Vector2(2 * spacing, 0), Color.White);
            spriteBatch.DrawString(font, $"Time: {time}", startPosition + new Vector2(3 * spacing, 0), Color.White);
            spriteBatch.DrawString(font, $"Lives: {lives}", startPosition + new Vector2(4 * spacing, 0), Color.White);

            // 绘制短暂显示的得分
            foreach (var popup in scorePopups)
            {
                popup.Draw(spriteBatch, font);
            }
        }
    }

    public class ScorePopup
    {
        private int points;
        private Vector2 position;
        private float timer;
        private Color color;

        public bool IsExpired => timer <= 0;

        public ScorePopup(int points, Vector2 position)
        {
            this.points = points;
            this.position = position;
            this.timer = 1.5f;
            this.color = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y -= 20 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            color = Color.White * MathHelper.Clamp(timer / 1.5f, 0, 1);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, points.ToString(), position, color);
        }
    }
}
