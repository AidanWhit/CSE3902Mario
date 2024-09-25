using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Sprites;
using Sprint_0.Sprites;
using Microsoft.Xna.Framework;

namespace Sprint_2.Interfaces
{
    public interface IBlock : ISprite
    {
        Vector2 position { get; set; }
        bool containsItem { get; set; }
        bool breakable { get; set; }

    }
}
