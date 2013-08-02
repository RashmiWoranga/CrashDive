using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CrashDive_v1_6_13.objects;
using CrashDive_v1_6_13.UI;

namespace CrashDive_v1_6_13
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Texture2D backgroundTexture;
        Texture2D foregroundTexture;
        TankBattle tankBattle;
        Reader reader;
        Cell[,] map;
        Player[] players;
        Map battle;
        int length = 20, count=5; // cell width and number of players
        Network_Communication Connection;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            map = new Cell[length,length];
            players = new Player[count];
            battle = new Map(length, count);
            reader = new Reader(battle);
            Connection = new Network_Communication(this,reader);
            tankBattle = new TankBattle(this, battle);
            
        }
        
        /*
         * ID = 100 Coin pile
         * ID = 200 Life Pack
         * ID = 300 Brick
         * ID = 400 Stone
         * ID = 500 Water
         * 
         * 
         * 
         * */
        
        
            
        
       
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1300;
            graphics.PreferredBackBufferHeight = 700;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Crash-Dive";

            Connection.reply = "JOIN#";
           Connection.SendData();
            Connection.startlistening();

            base.Initialize();
          //  nc.run();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            backgroundTexture = Content.Load<Texture2D>("background");
            foregroundTexture = Content.Load<Texture2D>("foreground");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            tankBattle.LoadContent(spriteBatch, this.Content);       
         }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
         //   if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
           //     this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           // GraphicsDevice.Clear(Color.CornflowerBlue);

            //spriteBatch.Begin();
          //  DrawScenery();
         //   spriteBatch.End();
            tankBattle.Draw(gameTime);
            base.Draw(gameTime);
        }

        private void DrawScenery()
        {
           // int number =10;//should be change according to the number of cells
           // Cell temp = new Cell(0,0,1); 
           // Rectangle screenRectangle = new Rectangle(0, 0, 1300, 700);
           // Rectangle battleRectangle = new Rectangle(50, 50, 650, 650);
           // Rectangle[,] feild = new Rectangle[number,number]; 
            
            //spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            //spriteBatch.Draw(foregroundTexture, battleRectangle, Color.White);
           
        }
    }
}
