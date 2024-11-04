using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace Sprint_2.Factories
{
    public class UniversalSpriteFactory
    {
        private static UniversalSpriteFactory instance = new UniversalSpriteFactory();
        public static UniversalSpriteFactory Instance { get { return instance; } }

        Dictionary<string, Rectangle[]> spriteData = new Dictionary<string, Rectangle[]>();
        private UniversalSpriteFactory() 
        {
            LoadSpriteMachine();
        }

        private void LoadSpriteMachine()
        {
            string spriteDataFile = @"LevelManager\XMLFiles\SpriteData.xml";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            int index = directory.IndexOf(@"\bin");
            directory = directory.Substring(0, index + 1);
            directory = directory + spriteDataFile;

            XmlReader dataReader = XmlReader.Create(directory);
            dataReader.MoveToContent();

            string spriteName;
            string numberOfFrames;

            while (dataReader.Read())
            {
                if (dataReader.NodeType == XmlNodeType.Element && (dataReader.Name == "Sprite"))
                {

                    dataReader.ReadToDescendant("Name");
                    spriteName = dataReader.ReadElementContentAsString();

                    dataReader.Read();
                    numberOfFrames = dataReader.ReadElementContentAsString();

                    Rectangle[] frames = CreateFrameArray(dataReader, Convert.ToInt32(numberOfFrames));

                    Debug.WriteLine("NumberofFrames: " + numberOfFrames);
                    AddEntry(spriteName, frames);
                }
            }

            Debug.WriteLine("Dict: " + spriteData.Keys);
            Game1.Instance.Exit();
        }
        
        private Rectangle[] CreateFrameArray(XmlReader dataReader, int numberOfFrames)
        {
            Rectangle[] frames = new Rectangle[numberOfFrames];

            string xPos;
            string yPos;
            string width;
            string height;
            for (int i = 0; i < numberOfFrames; i++)
            {
                dataReader.ReadToNextSibling("Rectangle");

                dataReader.ReadToDescendant("XPos");
                xPos = dataReader.ReadElementContentAsString();

                dataReader.Read();
                yPos = dataReader.ReadElementContentAsString();

                dataReader.Read();
                width = dataReader.ReadElementContentAsString();

                dataReader.Read();
                height = dataReader.ReadElementContentAsString();


                frames[i] = new Rectangle(Convert.ToInt32(xPos), Convert.ToInt32(yPos), Convert.ToInt32(width), Convert.ToInt32(height));
            }

            return frames;
        }

        public void AddEntry(string key, Rectangle[] frames)
        {
            spriteData.Add(key, frames);
        }
    }
}
