﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    class Treasure :Object
    {
        int LT; //time to live
        public Treasure(int id, int x, int y,int lt) :base(id,x,y)
        {
		LT= lt;
	    }

	    public int getLifeTime()
        {
		    return LT;
	    }

	    public void setLifeTime(int TTL)
        {
		    this.LT = TTL;
	    }

	
    }
}
