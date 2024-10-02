using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sprint_2.MarioStates
{
    public class PoseState
    {
        private enum Pose { Idle, Run, Jump, Crouch, Fall, Slide, Shoot }
        private Pose pose;
        private IPlayer mario;

        public PoseState(IPlayer mario)
        {
            this.mario = mario;
            /* Assume Player starts at idle */
            pose = Pose.Idle;
        }
        public void Shoot()
        {
            if (pose != Pose.Crouch)
            {
                pose = Pose.Shoot;
            }
        }
        public void Slide()
        {
            if (pose == Pose.Run)
            {
                pose = Pose.Slide;
            }
        }
        public void Jump()
        {
            if (pose != Pose.Fall)
            {
                pose = Pose.Jump;
            }
            else if (pose == Pose.Crouch)
            {
                pose = Pose.Idle;
            }
        }

        public void Run()
        {
            if (pose == Pose.Idle)
            {
                pose = Pose.Run;
            }
        }

        public void Crouch()
        {
            if (pose != Pose.Jump && pose != Pose.Fall && !mario.isCrouching)
            {
                mario.isCrouching = true;
                int bottomPositionOfSprite = mario.GetHitBox().Bottom;
                pose = Pose.Crouch;
                mario.YPos = bottomPositionOfSprite - mario.GetHitBox().Height;
            }
        }
        public void Idle()
        {
            if (pose != Pose.Jump)
            {
                pose = Pose.Idle;
            }
        }

        public void Fall()
        {
            pose = Pose.Fall;
        }

        public string GetPose()
        {
            return pose.ToString();
        }
    }
}
