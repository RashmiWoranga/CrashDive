using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    public class Brick : Cell
    {
        int damage;
        public Brick(int id, int x, int y,int dmg)
            : base(id, x, y)
        {
            damage = dmg;
        }
        public int getDamage()
        {
            return damage;
        }

        public void setDamage(int damage)
        {
            this.damage = damage;
        }
    }
}
