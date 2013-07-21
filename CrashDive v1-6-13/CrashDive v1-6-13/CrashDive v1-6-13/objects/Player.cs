using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrashDive_v1_6_13.objects
{
    class Player
    {

        private int x,y,id,points, coins, health, direction;

        private Boolean Shot;
        public Player(int x, int y, int id, int direction, Boolean shot, int health, int coins, int points)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.direction = direction;
            this.Shot = shot;
            this.health = health;
            this.coins = coins;
            this.points = points;
            
        }
       
       

        public int getDirection()
        {
            return direction;
        }

        public void setDirection(int direction)
        {
            this.direction = direction;
        }
        public Boolean getShot()
        {
            return Shot;
        }

        public void setShot(Boolean Shot)
        {
            this.Shot = Shot;
        }
        public int getHealth()
        {
            return health;
        }

        public void setHealth(int health)
        {
            this.health = health;
        }

        public int getCoins()
        {
            return coins;
        }

        public void setCoins(int coins)
        {
            this.coins = coins;
        }
        public int getPoints()
        {
            return points;
        }

        public void setPoints(int points)
        {
            this.points = points;
        }
        
    }
}
