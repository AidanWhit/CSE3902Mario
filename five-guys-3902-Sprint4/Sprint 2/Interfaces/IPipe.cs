using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Interfaces
{
    public interface IPipe: ICollideable, IUpdateable, IDrawable
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Rectangle GetHitBox();
    }
}
