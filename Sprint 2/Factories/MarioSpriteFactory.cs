using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
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

        public static MarioSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private Dictionary<string, Rectangle[]> marioSprites = new Dictionary<string, Rectangle[]>
        {
            {"LeftMarioIdle", new Rectangle[]{ new Rectangle(181, 0, 13, 16) } },
            {"RightMarioIdle", new Rectangle[]{new Rectangle(211, 0, 13, 16) } },
            {"LeftSuperMarioIdle", new Rectangle[]{new Rectangle(180, 52, 16, 32)} },
            {"RightSuperMarioIdle", new Rectangle[]{new Rectangle(209, 52, 16, 32)} },
            {"LeftFireMarioIdle", new Rectangle[]{new Rectangle(180, 122, 16, 32) } },
            {"RightFireMarioIdle", new Rectangle[]{new Rectangle(209, 122, 16, 32)} },
            {"LeftSuperMarioCrouch", new Rectangle[]{new Rectangle(0, 57, 16, 22) } },
            {"RightSuperMarioCrouch", new Rectangle[]{new Rectangle(389, 57, 16, 22)} },
            {"LeftFireMarioCrouch", new Rectangle[]{new Rectangle(0, 127, 16, 22) } },
            {"RightFireMarioCrouch", new Rectangle[]{new Rectangle(389, 127, 16, 22) } },
            {"LeftMarioJump", new Rectangle[]{new Rectangle(29, 0, 16, 16)} },
            {"RightMarioJump", new Rectangle[]{new Rectangle(359, 0, 16, 16) } },
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
            {"LeftMarioRun", new Rectangle[]{new Rectangle(150, 0, 14, 16), new Rectangle(121, 0, 12, 16), new Rectangle(89, 0, 16, 16) } },
            {"RightMarioRun", new Rectangle[]{new Rectangle(241, 0, 14, 16), new Rectangle(272, 0, 12, 16), new Rectangle(300, 0, 16, 16) } },
            {"LeftSuperMarioRun", new Rectangle[]{new Rectangle(150, 52, 16, 32), new Rectangle(121, 52, 14, 31), new Rectangle(90, 53, 16, 30) } },
            {"RightSuperMarioRun", new Rectangle[]{new Rectangle(239, 52, 16, 32), new Rectangle(270, 52, 14, 31), new Rectangle(299, 53, 16, 30) } },
            {"LeftFireMarioRun", new Rectangle[]{new Rectangle(152, 122, 16, 32), new Rectangle(128, 122, 14, 31), new Rectangle(102, 123, 16, 30) } },
            {"RightFireMarioRun", new Rectangle[]{new Rectangle(237, 122, 16, 32), new Rectangle(263, 122, 14, 31), new Rectangle(287, 123, 16, 30) } },
            {"DeadMario", new Rectangle[]{new Rectangle(0, 16, 15, 14)} },
            {"LeftMarioSlide", new Rectangle[]{new Rectangle(60, 0, 14, 16)} },
            {"RightMarioSlide", new Rectangle[]{new Rectangle(331,0, 14, 16)} },
            {"LeftSuperMarioSlide", new Rectangle[]{new Rectangle(329, 52, 16, 32)} },
            {"RightSuperMarioSlide", new Rectangle[]{new Rectangle(60, 52, 16, 32)} },
            {"LeftFireMarioSlide", new Rectangle[]{new Rectangle(337, 122, 16, 32)} },
            {"RightFireMarioSlide", new Rectangle[]{new Rectangle(52, 122, 16, 32)} },
            {"LeftFireMarioShoot", new Rectangle[]{new Rectangle(77, 123, 16, 30)} },
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
        public ISprite GetMarioSprite(string key)
        {
            /* No fall sprite, so replace fall with jump because its the same sprite */
            if (key.Contains("Fall"))
            {
                key = key.Replace("Fall", "Jump");
            }

            marioSprites.TryGetValue(key, out Rectangle[] frames);
            if (key.Contains("Fire") || key.Contains("Super"))
            {
                return new FrameArrayFormattedSprite(marioSpriteSheet, frames, 1);
            }
            else
            {
                return new FrameArrayFormattedSprite(marioSpriteSheet, frames, 1);
            }
        }

        /* Do not mess with any of the below functions */
        public ISprite FireBall()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(1, 1, 8, 8), new Rectangle(11, 1, 8, 8), 
                new Rectangle(1, 11, 8, 8), new Rectangle(11, 11, 8, 8) };
            return new FrameArrayFormattedSprite(fireBallSpriteSheet, source, FireBallConstants.scale);
        }
        public ISprite FireballExplosion()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(5, 5, 9, 9), new Rectangle(21, 1, 13, 16), new Rectangle(37, 1, 16, 16) };
            return new FrameArrayFormattedSprite(explosionSpriteSheet, source, FireBallConstants.scale);
        }
        public ISprite DeadMarioSprite()
        {
            marioSprites.TryGetValue("DeadMario", out Rectangle[] frames);
            return new FrameArrayFormattedSprite(marioSpriteSheet, frames, 1);
        }
    }

}
