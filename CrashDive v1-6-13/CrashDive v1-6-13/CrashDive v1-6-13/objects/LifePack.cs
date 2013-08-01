using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using CrashDive_v1_6_13.UI;

namespace CrashDive_v1_6_13.objects
{
    public  class LifePack : Treasure
    {
        int seconds;
        int LT;
        private DateTime appearedON;
        private DateTime vanishingON;
        protected Timer timer;
        private Reader reader;

        public LifePack(int id, int x, int y, int lt,Reader rr)
            : base(id, x, y, lt)
        {
            seconds = lt / 1000;
            LT = lt;
            appearedON = DateTime.Now;
            reader = rr;
            timer = new System.Timers.Timer(LT);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
            GC.KeepAlive(timer);
        }
        public DateTime AppearedON
        {
            get { return appearedON; }
            set { appearedON = value; }
        }
        public DateTime VanishingON
        {
            get { return vanishingON; }
            set { vanishingON = value; }
        }

        public int getLifeTime()
        {
            return LT;
        }

        public void setLifeTime(int TTL)
        {
            this.LT = TTL;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //   Reader.removeCoinPile
            //  GameManager.getGameManager.removeLifepacksFromMap(this);
            //UI.TankBattle.
            //Console.WriteLine("lifetime " + LifeTime);
            reader.removeLifePacks(this, this.getX(), this.getY());
            VanishingON = DateTime.Now;
            //Console.WriteLine((VanishingTime-AppearedTime).ToString());

        }
        public void reduceSeconds()
        {
            seconds -= 1;
        }
        public int getSeconds()
        {
            return seconds;
        }
    }
}
