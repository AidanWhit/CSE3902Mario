using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;


namespace Sprint_0.Sprites
{
    public class Player : IPlayer, ISprite
    {

        public IMarioState State { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Player(Vector2 StartingLocation) 
        {
            XPos = (int)StartingLocation.X;
            YPos = (int)StartingLocation.Y;
            State = new RightFireMarioRunningState(this);
        }
        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, location);
        }

        public void MoveLeft()
        {
            XPos -= 1;
        }
        public void MoveRight()
        {
            XPos += 1;
        }
        public void Jump()
        {

        }
        public void Crouch()
        {

        }
    }
}
