using Sprint_0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Interfaces
{
    internal interface IPlayer
    {
        void MoveLeft();
        void MoveRight();
        void Jump();
        enum health { regular=1, super, fire}
    }
}
