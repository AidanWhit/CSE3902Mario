using Microsoft.Xna.Framework;
using Sprint_0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Interfaces
{
    public interface IPlayer
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Vector2 PlayerVelocity { get;set; }
        void MoveLeft();
        void MoveRight();
        void Jump();
        public enum Health { Mario=1, SuperMario, FireMario}
        public enum Facing { Left, Right }
        public enum Pose { Crouch, Jump, Fall, Idle, Run, Dead}
    }
}
