using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    class Object
    {
        int ID, X, Y;
        public Object(int id, int x, int y)
        {
            this.ID = id;
            this.X = x;
            this.Y = y;
        }
        public int getID()
        {
            return ID;
        }

        public void setName(int id)
        {
            this.ID = id;
        }
        public int getX()
        {
            return X;
        }

        public void setX(int x)
        {
            this.X = x;
        }

        public int getY()
        {
            return Y;
        }

        public void setY(int y)
        {
            this.Y = y;
        }
    }
}
