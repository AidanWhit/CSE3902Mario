using Sprint_0.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint_0.Commands.EnemyCommands
{
    public class  ItemCycler
    {
        private List<IItem> items;
        private int currIndex;

        public ItemCycler(List<IItem> items)
        {
            this.items = items;
            currIndex = 0;
        }

        // Methods to cycle enemies
        public IItem CycleItemLeft()
        {
            currIndex = (currIndex - 1 + items.Count) % items.Count;
            return items[currIndex];
        }

        public IItem CycleItemRight()
        {
            currIndex = (currIndex + 1) % items.Count;
            return items[currIndex];
        }
    }
}
