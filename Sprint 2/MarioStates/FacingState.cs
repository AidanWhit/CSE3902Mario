using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioStates
{
    public class FacingState
    {
        private enum Facing { Left, Right }
        private Facing facing;

        public FacingState()
        {
            /* Assume player starts facing right */
            facing = Facing.Right;
        }

        public void ChangeDirection()
        {

            if (facing == Facing.Left)
            {
                facing = Facing.Right;
            }
            else
            {
                facing = Facing.Left;
            }
        }

        public string GetFacing()
        {
            return facing.ToString();
        }
    }
}
