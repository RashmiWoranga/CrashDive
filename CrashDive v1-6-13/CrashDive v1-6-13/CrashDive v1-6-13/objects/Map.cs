using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    class Map
    {
        Object[,] map;
        Player[] players;
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
            map = new Object[length,length];
            players = new Player[count];
        }
        public void addObjects(Object O,int x,int y)
        {
            map[x,y] = O;
        }
        public void addPlayer(Player P, int num)
        {
            players[num] = P;
        }
    }
}
