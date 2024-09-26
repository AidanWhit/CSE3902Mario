using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Sprint_2.Sprites.MarioSprites;
using Sprint_2.Constants;
using System.Diagnostics;
using System.Net.Http.Headers;
using Sprint_2.Interfaces;

namespace Sprint_2.Factories
{
    public class MarioSpriteFactory
    {
        private Texture2D marioSpriteSheet;
        private Texture2D fireBallSpriteSheet;
        private Texture2D explosionSpriteSheet;

        private static MarioSpriteFactory instance = new MarioSpriteFactory();
        private Vector2 marioSize = new Vector2(4 * 17, 4 * 16);
        private Vector2 superMarioSize = new Vector2(4 * 16, 4 * 32);

        private float climbSpeed = 0.2f;
        private float runSpeed = 0.1f;
        public static MarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private Dictionary<string, Rectangle[]> marioSprites = new Dictionary<string, Rectangle[]>
        {
            {"LeftMarioIdle", new Rectangle[]{ new Rectangle(181, 0, 16, 16) } },
            {"RightMarioIdle", new Rectangle[]{new Rectangle(211, 0, 16, 16) } },
            {"LeftSuperMarioIdle", new Rectangle[]{new Rectangle(180, 52, 16, 32)} },
            {"RightSuperMarioIdle", new Rectangle[]{new Rectangle(209, 52, 16, 32)} },
            {"LeftFireMarioIdle", new Rectangle[]{new Rectangle(180, 122, 16, 32) } },
            {"RightFireMarioIdle", new Rectangle[]{new Rectangle(209, 122, 16, 32)} },
            {"LeftSuperMarioCrouch", new Rectangle[]{new Rectangle(0, 57, 16, 30) } },
            {"RightSuperMarioCrouch", new Rectangle[]{new Rectangle(389, 57, 16, 30)} },
            {"LeftFireMarioCrouch", new Rectangle[]{new Rectangle(0, 127, 16, 30) } },
            {"RightFireMarioCrouch", new Rectangle[]{new Rectangle(389, 127, 16, 30) } },
            {"LeftMarioJump", new Rectangle[]{new Rectangle(29, 0, 17, 16)} },
            {"RightMarioJump", new Rectangle[]{new Rectangle(359, 0, 17, 16) } },
            {"LeftSuperMarioJump", new Rectangle[]{new Rectangle(30, 52, 16, 32) } },
            {"RightSuperMarioJump", new Rectangle[]{new Rectangle(359, 52, 16, 32) } },
            {"LeftFireMarioJump", new Rectangle[]{new Rectangle(27, 122, 16, 32) } },
            {"RightFireMarioJump", new Rectangle[]{new Rectangle(362, 122, 16, 32) } },
            {"LeftMarioClimb", new Rectangle[]{new Rectangle(30, 30, 16, 16), new Rectangle(61, 30, 16, 16) } },
            {"RightMarioClimb", new Rectangle[]{new Rectangle(361, 30, 16, 16), new Rectangle(331, 30, 16, 16) } },
            {"LeftSuperMarioClimb", new Rectangle[]{new Rectangle(1, 88, 16, 32), new Rectangle(28, 89, 16, 32) } },
            {"RightSuperMarioClimb", new Rectangle[]{new Rectangle(390, 88, 16, 32), new Rectangle(363, 89, 16, 32) } },
            {"LeftFireMarioClimb", new Rectangle[]{new Rectangle(1, 158, 16, 32), new Rectangle(28, 159, 16, 32) } },
            {"RightFireMarioClimb", new Rectangle[]{new Rectangle(390, 158, 16, 32), new Rectangle(363, 159, 16, 32) } },
            {"LeftMarioRun", new Rectangle[]{new Rectangle(150, 0, 16, 16), new Rectangle(121, 0, 16, 16), new Rectangle(89, 0, 16, 16) } },
            {"RightMarioRun", new Rectangle[]{new Rectangle(241, 0, 16, 16), new Rectangle(272, 0, 16, 16), new Rectangle(300, 0, 16, 16) } },
            {"LeftSuperMarioRun", new Rectangle[]{new Rectangle(150, 52, 16, 32), new Rectangle(121, 52, 16, 32), new Rectangle(90, 53, 16, 32) } },
            {"RightSuperMarioRun", new Rectangle[]{new Rectangle(239, 52, 16, 32), new Rectangle(270, 52, 16, 32), new Rectangle(299, 53, 16, 32) } },
            {"LeftFireMarioRun", new Rectangle[]{new Rectangle(152, 122, 16, 32), new Rectangle(128, 122, 16, 32), new Rectangle(102, 123, 16, 32) } },
            {"RightFireMarioRun", new Rectangle[]{new Rectangle(237, 122, 16, 32), new Rectangle(263, 122, 16, 32), new Rectangle(287, 123, 16, 32) } },
            {"DeadMario", new Rectangle[]{new Rectangle(0, 16, 16, 16)} },
            {"LeftMarioSlide", new Rectangle[]{new Rectangle(60, 0, 16, 16)} },
            {"RightMarioSlide", new Rectangle[]{new Rectangle(331,0, 16, 16)} },
            {"LeftSuperMarioSlide", new Rectangle[]{new Rectangle(329, 52, 16, 32)} },
            {"RightSuperMarioSlide", new Rectangle[]{new Rectangle(60, 52, 16, 32)} },
            {"LeftFireMarioSlide", new Rectangle[]{new Rectangle(337, 122, 16, 32)} },
            {"RightFireMarioSlide", new Rectangle[]{new Rectangle(52, 122, 16, 32)} },
            {"LeftFireMarioShoot", new Rectangle[]{new Rectangle(77, 123, 16, 32)} },
            {"RightFireMarioShoot", new Rectangle[]{new Rectangle(312, 123, 16, 30)} }

        };
        private MarioSpriteFactory()
        {
        }
        public void LoadAllContent(ContentManager content)
        {
            marioSpriteSheet = content.Load<Texture2D>("marioSpriteSheet");
            fireBallSpriteSheet = content.Load<Texture2D>("MarioFireBallSpriteSheet");
            explosionSpriteSheet = content.Load<Texture2D>("MarioFireBallExplosionSpriteSheet");

        }

        /* Next 3 functions are used to try and implement player without States */
        public ISprite GetAnimatedMarioSprite(string key, Vector2 size)
        {
            marioSprites.TryGetValue(key, out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, size, runSpeed);
        }
        public ISprite GetStaticMarioSprite(string key, Vector2 size)
        {
            if (key.Contains("Fall"))
            {
                key = key.Replace("Fall", "Jump");
            }
            marioSprites.TryGetValue(key, out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, size);
        }
        public ISprite GetMarioSprite(string key, Vector2 size)
        {
            if (key.Contains("Run") || key.Contains("Climb"))
            {
                return GetAnimatedMarioSprite(key, size);
            }
            else
            {
                return GetStaticMarioSprite(key, size);
            }
        }

        /* Do not mess with any of the below functions */
        public ISprite FireBall()
        {
            return new AnimatedSprite(fireBallSpriteSheet, FireBallConstants.animationDelay, 2, 2, FireBallConstants.scale);
        }
        public ISprite FireballExplosion()
        {
            return new FireballExplosionSprite(explosionSpriteSheet, FireBallConstants.animationDelay, 1, 3, FireBallConstants.scale);
        }
        public ISprite DeadMarioSprite()
        {
            marioSprites.TryGetValue("DeadMario", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, marioSize);
        }
    }

}
