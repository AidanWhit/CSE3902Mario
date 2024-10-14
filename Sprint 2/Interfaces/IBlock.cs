using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_2.Interfaces
{
    public interface IBlock
    {
        Vector2 Position { get; set; }
        bool containsItem { get; set; }
        bool breakable { get; set; }

        public Rectangle GetHitBox();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Color color);

        public void BeHit(IPlayer player);

        public void ChangeState(IBlockState blockState);

        public IBlockState GetBlockState();


    }
}
