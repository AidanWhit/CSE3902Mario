using Sprint_2.Constants;
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

        public HealthState()
        {
            health = Health.Mario;

            marioSize = new Vector2(16 * 4, 16 * 4);
            bigMarioSize = new Vector2(16 * 4, 32 * 4);

            size = marioSize;
        }


        public void PowerUp()
        {
            if (health != Health.Dead && health != Health.FireMario)
            {
                size = bigMarioSize;
                health++;
            }
        }
        public void Damage()
        {
            if (health == Health.Mario)
            {
                health = Health.Dead;
            }
            else
            {
                /* All damage sets Fire/Super mario to little mario */
                health = Health.Mario;
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
