using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.UI
{
    class BasicData
    {
        static int width =10, height=10;
        static int  players = 5;
        static int bN = 10;
        int[,] location = new int[players,3];
        int[,] palyerData = new int[players, 4];
        int[,] bricks = new int[bN, 3];
        int[] map = new int[width * height];




    }
}
