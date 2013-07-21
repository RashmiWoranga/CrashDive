using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    class CoinPile :Treasure
    {
        int value;
        public CoinPile(int id, int x, int y, int lt, int valv)
            :base(id,x,y,lt){
        }

        public int getValue()
        {
            return value;
        }
        public void setValue(int valv)
        {
            this.value = valv;
        }
    }
}
