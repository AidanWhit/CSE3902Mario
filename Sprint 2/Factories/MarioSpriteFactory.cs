using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Sprites.MarioSprites;
using Sprint_2.Sprites;
using Sprint_2.Constants;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Sprint_0.Factories
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
            {"LeftSuperMarioCrouch", new Rectangle[]{new Rectangle(0, 57, 16, 32) } },
            {"RightSuperMarioCrouch", new Rectangle[]{new Rectangle(389, 57, 16, 32)} },
            {"LeftFireMarioCrouch", new Rectangle[]{new Rectangle(0, 127, 16, 32) } },
            {"RightFireMarioCrouch", new Rectangle[]{new Rectangle(389, 127, 16, 32) } },
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
                Debug.WriteLine("Key: " + key);
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

        /* Should be able to delete these below fuctions but I will leave them here for now ~ Aidan */
        public ISprite LeftMarioIdleSprite()
        {
            marioSprites.TryGetValue("LeftMarioIdle", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, marioSize);
        }

        public ISprite RightMarioIdleSprite()
        {
            marioSprites.TryGetValue("RightMarioIdle", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, marioSize);
        }

        public ISprite LeftSuperMarioIdleSprite()
        {
            marioSprites.TryGetValue("LeftSuperMarioIdle", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite RightSuperMarioIdleSprite()
        {
            marioSprites.TryGetValue("RightSuperMarioIdle", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite LeftFireMarioIdleSprite()
        {
            marioSprites.TryGetValue("LeftFireMarioIdle", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite RightFireMarioIdleSprite()
        {
            marioSprites.TryGetValue("RightFireMarioIdle", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite LeftMarioClimbingSprite()
        {
            marioSprites.TryGetValue("LeftMarioClimb", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, marioSize, climbSpeed);
        }
        public ISprite RightMarioClimbingSprite()
        {
            marioSprites.TryGetValue("RightMarioClimb", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, marioSize, climbSpeed);
        }
        public ISprite LeftSuperMarioClimbingSprite()
        {
            marioSprites.TryGetValue("LeftSuperMarioClimb", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, climbSpeed);
        }
        public ISprite RightSuperMarioClimbingSprite()
        {
            marioSprites.TryGetValue("RightSuperMarioClimb", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, climbSpeed);
        }
        public ISprite LeftFireMarioClimbingSprite()
        {
            marioSprites.TryGetValue("LeftFireMarioClimb", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, climbSpeed);
        }
        public ISprite RightFireMarioClimbingSprite()
        {
            marioSprites.TryGetValue("RightFireMarioClimb", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, climbSpeed);
        }
        public ISprite LeftMarioCrouchingSprite()
        {
            marioSprites.TryGetValue("LeftMarioCrouch", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, marioSize);
        }
        public ISprite RightMarioCrouchingSprite()
        {
            marioSprites.TryGetValue("RightMarioCrouch", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, marioSize);
        }
        public ISprite LeftSuperMarioCrouchingSprite()
        {
            marioSprites.TryGetValue("LeftSuperMarioCrouch", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite RightSuperMarioCrouchingSprite()
        {
            marioSprites.TryGetValue("RightSuperMarioCrouch", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite LeftFireMarioCrouchingSprite()
        {
            marioSprites.TryGetValue("LeftFireMarioCrouch", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite RightFireMarioCrouchingSprite()
        {
            marioSprites.TryGetValue("RightFireMarioCrouch", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite LeftMarioJumpingSprite()
        {
            marioSprites.TryGetValue("LeftMarioJump", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, marioSize);
        }
        public ISprite RightMarioJumpingSprite()
        {
            marioSprites.TryGetValue("RightMarioJump", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, marioSize);
        }
        public ISprite LeftSuperMarioJumpingSprite()
        {
            marioSprites.TryGetValue("LeftSuperMarioJump", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite RightSuperMarioJumpingSprite()
        {
            marioSprites.TryGetValue("RightSuperMarioJump", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite LeftFireMarioJumpingSprite()
        {
            marioSprites.TryGetValue("LeftFireMarioJump", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite RightFireMarioJumpingSprite()
        {
            marioSprites.TryGetValue("RightFireMarioJump", out Rectangle[] frames);
            return new StaticMarioSprite(marioSpriteSheet, frames, superMarioSize);
        }
        public ISprite LeftMarioRunningSprite()
        {
            marioSprites.TryGetValue("LeftMarioRun", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, marioSize, runSpeed);
        }
        public ISprite RightMarioRunningSprite()
        {
            marioSprites.TryGetValue("RightMarioRun", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, marioSize, runSpeed);
        }
        public ISprite LeftSuperMarioRunningSprite()
        {
            marioSprites.TryGetValue("LeftSuperMarioRun", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, runSpeed);
        }
        public ISprite RightSuperMarioRunningSprite()
        {
            marioSprites.TryGetValue("RightSuperMarioRun", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, runSpeed);
        }
        public ISprite LeftFireMarioRunningSprite()
        {
            marioSprites.TryGetValue("LeftFireMarioRun", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, runSpeed);
        }
        public ISprite RightFireMarioRunningSprite()
        {
            marioSprites.TryGetValue("RightFireMarioRun", out Rectangle[] frames);
            return new AnimatedMarioSprite(marioSpriteSheet, frames, superMarioSize, runSpeed);
        }
    }

}
