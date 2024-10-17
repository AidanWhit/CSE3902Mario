using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Collision
{
    public class CollisionResponse
    {
        private GameObjectManager gameObjectManager;
        private Dictionary<string, (Type, Type)> collisionDict;

        public CollisionResponse(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;
            collisionDict = gameObjectManager.GetCollisionDictionary();

        }

        public void ResolveCollision(ICollideable source, ICollideable receiver, string side, Rectangle collisionIntersection)
        {
            //Item1 is sourceCommand, Item2 is receiverCommand
            (Type, Type) commands;
            collisionDict.TryGetValue(source.GetCollisionType() + receiver.GetCollisionType() + side, out commands);
            if (commands.Item2 != null)
            {
                Type[] constructorTypes = new Type[] { Type.GetType(receiver.ToString()), Type.GetType(source.ToString()), typeof(Rectangle) };
                ConstructorInfo constructorInfo = commands.Item2.GetConstructor(constructorTypes);

                object[] constructorParameters = new object[] { receiver, source, collisionIntersection };

                ICommands command = (ICommands)constructorInfo.Invoke(constructorParameters);
                command.Execute();
            }
            if (commands.Item1 != null)  
            {
                Type[] constructorTypes = new Type[] { Type.GetType(source.ToString()), Type.GetType(receiver.ToString()), typeof(Rectangle) };
                ConstructorInfo constructorInfo = commands.Item1.GetConstructor(constructorTypes);
                object[] constructorParameters = new object[] {source, receiver, collisionIntersection};
                ICommands command = (ICommands) constructorInfo.Invoke(constructorParameters);
                command.Execute();
            }
            
                
        }
    }
}
