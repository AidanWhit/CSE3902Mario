﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml;

namespace Sprint_2.Factories
{
    public class UniversalSpriteFactory
    {
        private static UniversalSpriteFactory instance = new UniversalSpriteFactory();
        public static UniversalSpriteFactory Instance { get { return instance; } }

        Dictionary<string, Rectangle[]> spriteData = new Dictionary<string, Rectangle[]>();

        private Texture2D marioSpriteSheet;
        private Texture2D fireBallSpriteSheet;
        private Texture2D explosionSpriteSheet;

        private Texture2D blockSpriteSheet;
        private Texture2D undergroundPipe;

        private Texture2D enemies;

        private Texture2D texture;
        private Texture2D staticCoin;

        private Texture2D levelImageTexture;  // The whole level image (blocks and background only)
        private Texture2D backgroundSprites;
        private Texture2D flagSprite;

        private Rectangle[] frames;

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

                    AddEntry(spriteName, frames);
                }
            }
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

                dataReader.ReadToNextSibling("YPos");
                yPos = dataReader.ReadElementContentAsString();

                dataReader.ReadToNextSibling("Width");
                width = dataReader.ReadElementContentAsString();

                dataReader.ReadToNextSibling("Height");
                height = dataReader.ReadElementContentAsString();

                dataReader.Read(); //Discard </Rectangle> element

                frames[i] = new Rectangle(Convert.ToInt32(xPos), Convert.ToInt32(yPos), Convert.ToInt32(width), Convert.ToInt32(height));
            }

            return frames;
        }

        public void LoadAllContent(ContentManager content)
        {
            marioSpriteSheet = content.Load<Texture2D>("marioSpriteSheet");
            fireBallSpriteSheet = content.Load<Texture2D>("MarioFireBallSpriteSheet");
            explosionSpriteSheet = content.Load<Texture2D>("MarioFireBallExplosionSpriteSheet");

            blockSpriteSheet = content.Load<Texture2D>("blocks");
            undergroundPipe = content.Load<Texture2D>("UndergroundPipe");

            enemies = content.Load<Texture2D>("enemies");

            texture = content.Load<Texture2D>("items");
            staticCoin = content.Load<Texture2D>("staticCoin");

            levelImageTexture = content.Load<Texture2D>("levelimage"); //sprite for the whole level image  
            backgroundSprites = content.Load<Texture2D>("backgroundSprites");
            flagSprite = content.Load<Texture2D>("flag");
        }

        public void AddEntry(string key, Rectangle[] frames)
        {
            spriteData.Add(key, frames);
        }

        public ISprite GetMarioSprite(string key)
        {
            if (key.Contains("Fall"))
            {
                key = key.Replace("Fall", "Jump");
            }
            spriteData.TryGetValue(key, out frames);
            return new FrameArrayFormattedSprite(marioSpriteSheet, frames, 1);
        }

        public ISprite MarioFireball()
        {
            spriteData.TryGetValue("fireball", out frames);
            return new FrameArrayFormattedSprite(fireBallSpriteSheet, frames, FireBallConstants.scale);
        }

        public ISprite MarioFireballExplosion()
        {
            spriteData.TryGetValue("fireballExplosion", out frames);
            return new FrameArrayFormattedSprite(explosionSpriteSheet, frames, FireBallConstants.scale);
        }

        public ISprite GetBlock(string id)
        {
            spriteData.TryGetValue(id, out Rectangle[] frames);
            /* Placeholder, will be changed to be something better */
            if (id.Equals("UndergroundPipe"))
            {
                return new FrameArrayFormattedSprite(undergroundPipe, frames, 1);
            }
            return new FrameArrayFormattedSprite(blockSpriteSheet, frames, 1);
        }
    }
}
