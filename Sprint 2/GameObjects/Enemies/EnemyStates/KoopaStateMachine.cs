﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class KoopaStateMachine
    {
        private Koopa koopa;
        private ISprite sprite;

        private bool facingLeft = true;
        private enum Health { Normal, Shell, Flipped};
        private Health health = Health.Normal;

        public KoopaStateMachine(Koopa koopa)
        {
            this.koopa = koopa;

            /* Assume Koopa starts facing left*/
            sprite = EnemyFactory.Instance.CreateLeftFacingKoopa();
        }

        public void ChangeDirection()
        {

            facingLeft = !facingLeft;
            if (facingLeft)
            {
                sprite = EnemyFactory.Instance.CreateLeftFacingKoopa();
            }
            else
            {
                sprite = EnemyFactory.Instance.CreateRightFacingKoopa();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (koopa.Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                koopa.Velocity += EnemyConstants.fallVelocity;
            }

            if (health == Health.Normal)
            {
                Move();
            }
            
            koopa.YPos += (float)(koopa.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            koopa.Velocity = new Vector2(koopa.Velocity.X, koopa.Velocity.Y * MarioPhysicsConstants.velocityDecay);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public void Move()
        {
            if (facingLeft)
            {
                koopa.Velocity = new Vector2(-EnemyConstants.moveSpeed, koopa.Velocity.Y);
            }
            else
            {
                koopa.Velocity = new Vector2(EnemyConstants.moveSpeed, koopa.Velocity.Y);
            }
            koopa.XPos += koopa.Velocity.X;
        }

        public void BeStomped()
        {
            if (health != Health.Shell)
            {
                health = Health.Shell;
                int bottomPos = koopa.GetHitBox().Bottom;
                sprite = EnemyFactory.Instance.CreateKoopaShell();
                bottomPos -= sprite.GetHitBox(new Vector2(koopa.XPos, koopa.YPos)).Height; 

                EnemyFactory.Instance.RemoveEnemyFromObjectList(koopa);
                EnemyFactory.Instance.AddEnemy(new Shell(new Vector2(koopa.XPos, bottomPos)));
                
            }
        }

        public void BeFlipped()
        {
            if (health != Health.Flipped)
            {
                health = Health.Flipped;
                sprite = EnemyFactory.Instance.CreateFlippedKoopaShell();
                koopa.Velocity = EnemyConstants.flippedVelocity;
            }
        }
        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
