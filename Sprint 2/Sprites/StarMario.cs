using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace Sprint_2.Sprites
{
    public class StarMario : IPlayer
    {
        public int XPos { get { return decoratedPlayer.XPos; } set { decoratedPlayer.XPos = value; } }
        public int YPos { get { return decoratedPlayer.YPos; } set { decoratedPlayer.YPos = value; } }

        public List<IProjectile> fireballs { get { return decoratedPlayer.fireballs; } set { decoratedPlayer.fireballs = value; } }
        public bool IsDamaged { get { return decoratedPlayer.IsDamaged; }  set { decoratedPlayer.IsDamaged = value; } }
        public bool isJumping { get { return decoratedPlayer.isJumping; } set { decoratedPlayer.isJumping = value; } }
        public bool isCrouching { get { return decoratedPlayer.isCrouching; } set { decoratedPlayer.isCrouching = value; } }
        public bool isFalling { get { return decoratedPlayer.isFalling; } set { decoratedPlayer.isFalling = value; } }
        public IMarioPhysicsStates PhysicsState { get { return decoratedPlayer.PhysicsState; } set { decoratedPlayer.PhysicsState = value; } }
        public Vector2 PlayerVelocity { get { return decoratedPlayer.PlayerVelocity; } set { decoratedPlayer.PlayerVelocity = value; } }

        public int RemainingLives { get { return decoratedPlayer.RemainingLives; } set { decoratedPlayer.RemainingLives = value; } }


        private IPlayer decoratedPlayer;
        private int remainingStarTime = 1000;
        private Color[] colors = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.LightGreen, Color.LightBlue, Color.Salmon};
        private int colorIndex = 0;

        public StarMario (IPlayer decoratedPlayer)
        {
            this.decoratedPlayer = decoratedPlayer;
        }
        public void Update(GameTime gameTime)
        { 
            remainingStarTime--;
            if (remainingStarTime < 0)
            {
                /* Remove star somehow */
                RemoveStar();
            }
            
            decoratedPlayer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            decoratedPlayer.Draw(spriteBatch, colors[(remainingStarTime / 4) % colors.Length]);
        }

        public void RemoveStar()
        {
            Game1.Instance.mario = decoratedPlayer;
        }

        public void MoveLeft()
        {
            decoratedPlayer.MoveLeft();
        }
        public void MoveRight()
        {
            decoratedPlayer.MoveRight();
        }
        public void Jump()
        {
            decoratedPlayer.Jump();
        }
        public void Crouch()
        {
            decoratedPlayer.Crouch();
        }

        public void UpdateFireballs(GameTime gameTime)
        {
            decoratedPlayer.UpdateFireballs(gameTime);
        }

        public void ShootFireball()
        {
            decoratedPlayer.ShootFireball();
        }
        public void Fall()
        {
            decoratedPlayer.Fall();
        }
        public void Idle()
        {
            decoratedPlayer.Idle();
        }
        public void Damage()
        {
            //Do Nothing
        }
        public void PowerUp()
        {
            decoratedPlayer.PowerUp();
        }
        public void OnCrouch()
        {
            decoratedPlayer.OnCrouch();
        }
        public void ReleaseCrouch()
        {
            decoratedPlayer.ReleaseCrouch();
        }
        public Rectangle GetHitBox()
        {
            return decoratedPlayer.GetHitBox();
        }
        public string GetHealth()
        {
            return decoratedPlayer.GetHealth();
        }
    }
}
