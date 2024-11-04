using Microsoft.Xna.Framework.Input;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioStates
{
    public class HealthState
    {
        private enum Health { Dead, Mario, SuperMario, FireMario };
        private Vector2 size;
        private Health health;

        private Vector2 marioSize;
        private Vector2 bigMarioSize;

        private IPlayer mario;

        public HealthState(IPlayer mario)
        {
            health = Health.Mario;
            this.mario = mario;
            marioSize = new Vector2(16 * 4, 16 * 4);
            bigMarioSize = new Vector2(16 * 4, 32 * 4);

            size = marioSize;
        }


        public void PowerUp()
        {
            if (health != Health.Dead && health != Health.FireMario)
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
            if (health == Health.Mario)
            {
                health = Health.Dead;

                SoundManager.Instance.StopBackgroundMusic();
                SoundManager.Instance.PlayBackgroundMusic("youAreDead");
                //SoundManager.Instance.PlaySoundEffect("marioDie");

                mario.RemainingLives--;
            }
            else
            {
                /* All damage sets Fire/Super mario to little mario */

                if (mario.isCrouching)
                {
                    mario.Idle();
                }
                health = Health.Mario;

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
