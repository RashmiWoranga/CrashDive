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

namespace CrashDive_v1_6_13.UI
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class TankBattle : Microsoft.Xna.Framework.GameComponent
    {

        int count = 5, length = 10,id;
        Map Battle;
        Texture2D backgroundTexture;
        Texture2D foregroundTexture;
        Texture2D brickTexture;
        Texture2D stoneTexture;
        Texture2D waterTexture;
        Texture2D coinsTexture;
        Texture2D lifeTexture;
        Texture2D[,] tanks;
        Texture2D brick1Texture;
        Texture2D brick2Texture;
        Texture2D brick3Texture;
        Texture2D tableTexture;
        SpriteFont font;
       // Boolean[,] isPlayerThere;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        int screenWidth;
        int screenHeight;
        Rectangle[,] feild;
        int w;

        public TankBattle(Game game,Map map)
            : base(game)
        {
            Battle  = map;
            feild = new Rectangle[length, length];
            tanks  = new Texture2D[count, 4];
            w = 600 / length;
           // isPlayerThere = new Boolean[length, length];
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            graphics.PreferredBackBufferWidth = 1300;
            graphics.PreferredBackBufferHeight = 700;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            createCells();
            base.Initialize();
        }
        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content)
        {
            this.spriteBatch = spriteBatch;
            //device = graphics.GraphicsDevice;


            backgroundTexture = Content.Load<Texture2D>("background");
            foregroundTexture = Content.Load<Texture2D>("foreground");
            brickTexture = Content.Load<Texture2D>("brick");
            brick1Texture = Content.Load<Texture2D>("brick1");
            brick2Texture = Content.Load<Texture2D>("brick2");
            brick3Texture = Content.Load<Texture2D>("brick3");
            stoneTexture = Content.Load<Texture2D>("stone");
            waterTexture = Content.Load<Texture2D>("water");
            coinsTexture = Content.Load<Texture2D>("coins");
            lifeTexture = Content.Load<Texture2D>("life");
            tableTexture = Content.Load<Texture2D>("table");
            font = Content.Load<SpriteFont>("MyFont");
            String name;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    name = "tank" + (i+1) + "_" + j;
                    tanks[i,j] = Content.Load<Texture2D>(name);
                }

            }
            
           
          //  screenWidth = device.PresentationParameters.BackBufferWidth;
          //  screenHeight = device.PresentationParameters.BackBufferHeight;

        }
        public void drawCoinPile()
        {
            List<CoinPile> coins = Battle.getCoinList();
            CoinPile temp;
            if (coins != null)
            {

                for (int j = 0; j < coins.Count; j++)
                {
                    temp = coins.ElementAt(id);
                    Rectangle x = new Rectangle(temp.getX() * w + 50, temp.getY() * w + 50, w, w);
                    //if (!isPlayerThere[temp.getX(), temp.getY()])
                    //{
                    //    spriteBatch.Draw(coinsTexture, x, Color.White);
                    //}
                    //else
                    //{
                    //    spriteBatch.Draw(coinsTexture, x, Color.White);
                    //    Battle.removeCoinPile(temp);
                    //}

                }
            }

        }
        public void createCells()
        {
            
            for (int j = 0; j < length; j++)
            {
                for (int k = 0; k < length; k++)
                {
                    feild[j, k] = new Rectangle(j * 10, k * w,  w, w);
                    
                 }
            }
            
        }

        public void clearCells()
        {
            List<CoinPile> coins = Battle.getCoinList();
            List<LifePack> life = Battle.getLifeList();
            
            if (coins != null)
            {
                CoinPile temp2;
                for (int j = 0; j < coins.Count; j++)
                {
                    temp2 = (CoinPile)coins.ElementAt(j);
                    if (temp2.getSeconds() == 0)
                    {
                        Battle.addObjects(null, temp2.getX(),temp2.getY());
                    }
                }
            }
            if (coins != null)
            {
                LifePack temp2;
                for (int j = 0; j < life.Count; j++)
                {
                    temp2 = (LifePack)life.ElementAt(j);
                    if (temp2.getSeconds() == 0)
                    {
                        Battle.addObjects(null, temp2.getX(), temp2.getY());
                    }
                }
            }
        }
        public void drawBattle()
        {
            Cell temp;
            Cell[,] map = Battle.getCells();
            clearCells();
            for (int j = 0; j < length; j++)
            {
                for (int k = 0; k < length; k++)
                {
                   // isPlayerThere[j,k] = false;
                    temp = map[j, k];
                    if (temp != null)
                    {
                        Rectangle x = new Rectangle(temp.getX() * w+50, temp.getY() * w+50, w, w);
                        id = temp.getID();
                        if (id == 300)
                        { 
                            Brick b =(Brick) temp;
                            int damage = b.getDamage();
                            if (damage == 0)
                            {
                                spriteBatch.Draw(brickTexture, x, Color.White);
                            }
                            else if (damage == 1)
                            {
                                spriteBatch.Draw(brick1Texture, x, Color.White);
                            }
                            else if (damage == 2)
                            {
                                spriteBatch.Draw(brick2Texture, x, Color.White);
                            }
                            else if (damage == 3)
                            {
                                spriteBatch.Draw(brick3Texture, x, Color.White);
                            }
                            
                            
                        }
                        else if (id == 400)
                        {
                            spriteBatch.Draw(stoneTexture,x, Color.White);
                        }
                        else if (id == 500)
                        {
                            spriteBatch.Draw(waterTexture, x, Color.White);
                        }
                        else if (id == 100)
                        {
                           // Rectangle x = new Rectangle(temp.getX() * 60 + 50, temp.getY() * 60 + 50, 60, 60);
                            spriteBatch.Draw(coinsTexture, x, Color.White);
                            //CoinPile temp2 =(CoinPile) map[j, k];
                            //if (temp2.getSeconds() == 0)
                            //{
                            //    Battle.addObjects(null, j, k);
                            //}
                            
                        }
                        else if (id == 200)
                        {
                            spriteBatch.Draw(lifeTexture, x, Color.White);
                            //LifePack temp2 = (LifePack)map[j, k];
                            //if (temp2.getSeconds() == 0)
                            //{
                            //    Battle.addObjects(null, j, k);
                            //}
                        }
                    }
                }
            }

        }
        public void drawPlayers()
        {
            Player temp1;
           // createCells();
        //    String name;
            Rectangle xx;
            int id, dirction;
            Player[] players = Battle.getPalayers();
            for (int i = 0; i < players.Length; i++)
            {
                temp1 = players[i];
                if (temp1 != null)
                {
                    int y = 200;
                    y = 200 + i * 30;
                    
                    xx = new Rectangle(temp1.getX() * w+50, temp1.getY() * w+50, w, w);
                    spriteBatch.DrawString(font, temp1.getPoints().ToString(), new Vector2(912, y), Color.White);
                    spriteBatch.DrawString(font, temp1.getCoins().ToString()+" $", new Vector2(1020, y), Color.White);
                    spriteBatch.DrawString(font, temp1.getHealth().ToString()+" %", new Vector2(1125, y), Color.White);
                    id = temp1.getID();
                    dirction = temp1.getDirection();
                    //isPlayerThere[temp1.getX(), temp1.getY()] = true;
                    if (temp1.getShot())
                    {
                       // spriteBatch.Draw(coinsTexture, xx, Color.White);
                        //CoinPile cp = new CoinPile(100,temp1.getX(),temp1.getY(),86400000,temp1.getPoints(),
                       
                    }
                    else
                    {
                        spriteBatch.Draw(tanks[i, dirction], xx, Color.White);
                    }
                }
                else
                {
                    //id = i;
//dirction = 0;
                  //  spriteBatch.Draw(tanks[i, dirction], feild[i, i], Color.White);
                }
                
            }

        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
        public void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawScenery();
            drawBattle();
            drawPlayers();
            DrawText();
          //  drawCoinPile();
            spriteBatch.End();

            //base.Draw(gameTime);
        }
        private void DrawScenery()
        {
            //createCells();
            Rectangle screenRectangle = new Rectangle(0, 0, 1300, 700);
            Rectangle battleRectangle = new Rectangle(50, 50, 600, 600);
            Rectangle tableRectangle = new Rectangle(780, 130, 430, 220);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
            spriteBatch.Draw(foregroundTexture, battleRectangle, Color.White);
            spriteBatch.Draw(tableTexture, tableRectangle, Color.White);
           // spriteBatch.Draw(brickTexture, feild[6,8], Color.White);
        }

        public void removeLifePacks(Treasure t)
        {
            Battle.addObjects(null, t.getX(), t.getY());
        }
        private void DrawText()
        {
            spriteBatch.DrawString(font, "Crash-Dive Tank Battle", new Vector2(875, 50), Color.White);
            spriteBatch.DrawString(font, "Player", new Vector2(805, 150), Color.Green);
            spriteBatch.DrawString(font, "Points", new Vector2(915, 150), Color.Green);
            spriteBatch.DrawString(font, "Coins", new Vector2(1025, 150), Color.Green);
            spriteBatch.DrawString(font, "Health", new Vector2(1132, 150), Color.Green);
            spriteBatch.DrawString(font, "P-0", new Vector2(812, 200), Color.Blue);
            spriteBatch.DrawString(font, "P-1", new Vector2(812, 230), Color.Blue);
            spriteBatch.DrawString(font, "P-2", new Vector2(812, 260), Color.Blue);
            spriteBatch.DrawString(font, "P-3", new Vector2(812, 290), Color.Blue);
            spriteBatch.DrawString(font, "P-4", new Vector2(812, 320), Color.Blue);

        }

    }
}
