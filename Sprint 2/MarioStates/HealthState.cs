using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Constants;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sound;

namespace Sprint_2.MarioStates
{
    public class HealthState
    {
        public enum HealthEnum { Dead, Mario, SuperMario, FireMario };
        private Vector2 size;
        public HealthEnum health { get; private set; }

        private Vector2 marioSize;
        private Vector2 bigMarioSize;

        private IPlayer mario;

        public HealthState(IPlayer mario)
        {
            health = HealthEnum.Mario;
            this.mario = mario;
            marioSize = new Vector2(16 * 4, 16 * 4);
            bigMarioSize = new Vector2(16 * 4, 32 * 4);

            size = marioSize;
        }


        public void PowerUp()
        {
            if (health != HealthEnum.Dead && health != HealthEnum.FireMario)
            {
                if (size != bigMarioSize)
                {
                    mario.YPos -= mario.GetHitBox().Height;
                }
                size = bigMarioSize;
                health++;

                
            }
        }
        public void Damage()
        {
            if (health == HealthEnum.Mario)
            {
                health = HealthEnum.Dead;

                SoundManager.Instance.StopBackgroundMusic();
                SoundManager.Instance.PlayBackgroundMusic("youAreDead");
                //SoundManager.Instance.PlaySoundEffect("marioDie");

                mario.PhysicsState = new DeadMario(mario);
                mario.PlayerVelocity = new Vector2(0, MarioPhysicsConstants.bounceVelocity);
                GameObjectManager.Instance.Movers.Remove(mario);

                mario.RemainingLives--;
            }
            else
            {
                /* All damage sets Fire/Super mario to little mario */

                if (mario.isCrouching)
                {
                    mario.Idle();
                }
                health = HealthEnum.Mario;

                SoundManager.Instance.PlaySoundEffect("pipe");

                mario.YPos += mario.GetHitBox().Height;

            }
            size = marioSize;
        }

        public string GetHealth()
        {
            return health.ToString();
        }

        public Vector2 GetSize()
        {
            return size;
        }


    }
}
