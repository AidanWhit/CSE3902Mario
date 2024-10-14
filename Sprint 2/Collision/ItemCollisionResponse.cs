using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Collision
{
    public class ItemCollisionResponse
    {
        public static void ItemResponseForPlayer(IItem item, IPlayer player)
        {
            if (item is RedMushroom || item is Flower)
            {
                player.PowerUp();
                
            }
            else if (item is Star)
            {
                Game1.Instance.mario = new StarMario(player);
                
            }
            else if (item is GreenMushroom)
            {
                player.RemainingLives++;
                
            }
            item.DeleteItem(null);
        }
    }
}
