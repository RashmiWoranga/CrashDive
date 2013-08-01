using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    public class Map
    {
       private Cell[,] map;
       private Player[] players;
       List<CoinPile> CoinPiles;
       List<LifePack> Lifepacks;
       List<int> shotPlayers;
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
        
        public Map(int length,int count)
        {
            map = new Cell[length,length];
            players = new Player[count];
            CoinPiles = new List<CoinPile>();
            Lifepacks = new List<LifePack>();
         }
        public void addCoins(CoinPile cp)
        {
            CoinPiles.Add(cp);
        }

        public void removeCoinPile(CoinPile cp)
        {
           CoinPiles.Remove(cp);
        }
        public List<CoinPile> getCoinList()
        {
            return CoinPiles;
        }
        public void setCoinList(List<CoinPile> k)
        {
            CoinPiles = k;
        }
        public List<int> getShotPlayerList()
        {
            return shotPlayers;
        }
        public void setshotplayerList(List<int> k)
        {
            shotPlayers = k;
        }
        public void addPlayer(int i)
        {
            shotPlayers.Add(i);
        }

        public void removePlayer(int i)
        {
            shotPlayers.Remove(i);
        }
        public void addLife(LifePack lp)
        {
            Lifepacks.Add(lp);
        }
        
        public void removeLife(LifePack lp)
        {
            Lifepacks.Remove(lp);
        }
        public List<LifePack> getLifeList()
        {
            return Lifepacks;
        }
        public void setLifeList(List<LifePack> y)
        {
            Lifepacks = y;
        }
        public Cell[,] getCells()
        {
            return map;
        }

        public Player[] getPalayers()
        {
            return players;
        }
        public void addObjects(Cell O,int x,int y)
        {
            map[x,y] = O;
        }
        public int getObjectid(int x, int y)
        {
            return map[x, y].getID();
        }
        public Cell getObject(int x, int y)
        {
            return map[x, y];
        }
        public void addPlayer(Player P, int num)
        {
            players[num] = P;
        }
        public void pdatePlayer(Player P, int num)
        {
            players[num] = P;
        }
        public void draw()
        {
            for (int i = 0; i < players.Length; i++)
            {
                System.Console.WriteLine("Player : " + players[i].getID() +" x: "+ players[i].getX() + " Y : " + players[i].getY());
            }
        }
    }
}
