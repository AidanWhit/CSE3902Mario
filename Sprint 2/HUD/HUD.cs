using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Sprint_2
{
    public class HUD
    {
        private static HUD hud = new HUD();
        public static HUD Instance {get {return hud;} }

        private SpriteFont font;
        private int score;
        private int coins;
        private string world;
        private float time;
        private int lives;
        private List<ScorePopup> scorePopups;
        private bool hideHUD = false;

        public HUD()
        {
            font = Game1.Instance.Content.Load<SpriteFont>("HUDFont");

            score = 0;
            coins = 0;
            world = "1-1";
            time = 400;
            lives = MarioPhysicsConstants.startingLives;
            scorePopups = new List<ScorePopup>();
        }
        
        public void AddScorePopUp(int points, Vector2 position)
        {
            score += points;
            scorePopups.Add(new ScorePopup(points, position));
        }

        public void AddScoreFromCoin(int points)
        {
            coins++;
            score += points;
        }

        public void AddScore(int points)
        {
            score += points;
        }

        public void Update(GameTime gameTime)
        {
            /* Need a better way to do this but it works for now */
            if (time < 0)
            {
                time = 0;
                Game1.Instance.mario.Die();
            }
            else if (time > 0)
            {
                time -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
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
            if (!hideHUD)
            {
                Vector2 startPosition = Game1.Instance.camera.GetLeftScreenBound() + new Vector2(50, 0);
                int spacing = 75;  // 每个元素之间的间隔
                lives = Game1.Instance.mario.RemainingLives;

                // 绘制并排的 HUD 元素
                spriteBatch.DrawString(font, $"Score: {score}", startPosition, Color.White);
                spriteBatch.DrawString(font, $"Coins: {coins}", startPosition + new Vector2(spacing, 0), Color.Yellow);
                spriteBatch.DrawString(font, $"World: {world}", startPosition + new Vector2(2 * spacing, 0), Color.White);
                spriteBatch.DrawString(font, $"Time: {(int)time}", startPosition + new Vector2(3 * spacing, 0), Color.White);
                spriteBatch.DrawString(font, $"Lives: {lives}", startPosition + new Vector2(4 * spacing, 0), Color.White);

                // 绘制短暂显示的得分
                foreach (var popup in scorePopups)
                {
                    popup.Draw(spriteBatch, font);
                }
            }
        }

        public void ResetTime()
        {
            time = 400;
        }

        public void CompleteReset()
        {
            coins = 0;
            score = 0;
            time = 400;

            hideHUD = false;
        }

        public int GetScore()
        {
            return score;
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
