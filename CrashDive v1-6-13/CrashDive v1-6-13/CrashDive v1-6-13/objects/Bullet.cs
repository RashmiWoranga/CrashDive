using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    public class Bullet : Cell
    {
        DateTime startTime;
        DateTime now;
        int cx, cy;
        int velocity;
        int cellSize;
        public Bullet(int id, int x, int y,DateTime start,int size)
            : base(id, x, y)
        {
            startTime = start;
            cellSize = size;
            velocity = 3 * cellSize;
        }
        public int distanceToMove(DateTime time)
        {
            int d = time.Subtract(startTime).Milliseconds * velocity / 1000;
            return d;
        }
        public void setStartTime(DateTime t)
        {
            startTime = t;

        }
        public void setCurrentTime(DateTime t)
        {
            now= t;

        }
        public int getX()
        {
            //DateTime x= now-startTime;

            return 0;
        }


        
    }
}
