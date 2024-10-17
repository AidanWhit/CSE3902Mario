﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint_2.Interfaces
{
    public interface IProjectile : IUpdateable, IDrawable
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Speed { get; set; }
        public bool EnteredExplosionState { get; set; }

        public bool isExploded();
        public Rectangle GetHitBox();

        public void ChangeSprite(ISprite sprite);

    }
}
