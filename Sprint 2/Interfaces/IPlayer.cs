﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.MarioStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.GameObjects;

namespace Sprint_2.Interfaces
{
    public interface IPlayer
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public bool isJumping { get; set; }
        public bool isCrouching { get; set; }
        public bool isFalling { get; set; }

        public List<IProjectile> fireballs { get; set; }
        public bool IsDamaged { get; set; }
        public IMarioPhysicsStates PhysicsState { get; set; }
        public Vector2 PlayerVelocity { get;set; }
        public void MoveLeft();
        public void MoveRight();
        public void Jump();
        public void Crouch();

        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Color color);
        public void UpdateFireballs(GameTime gameTime);
        public void ShootFireball();
        public void Fall();
        public void Idle();

        public void Damage();
        public void PowerUp();

        public void OnCrouch();
        public void ReleaseCrouch();

        public Rectangle GetHitBox();

        public string GetHealth();
    }
}
