using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrashDive_v1_6_13.objects;


//This class is used to check messages received by server

namespace CrashDive_v1_6_13.UI
{
    public class Reader
    {
        String input;
        Map Battle; // give input wrt to the map width or length
        List<CoinPile> CoinPiles2;
        List<LifePack> Lifepacks2;
        CoinPile tempCoin;
        LifePack tempLife;
        public Reader(Map battle)
        {
            Battle = battle;
        }
        public void getInput(String inputS)
        {
            input = inputS;
            
            String first = input.Substring(0, 2);
            input = input.Substring(0, input.Length - 1); // remove # mark
            
            switch (first)
            {
                case "S:":
                    start(input);
                   // Battle.Run();
                    break;
                case "I:":
                    initiate(input);
                //    Battle.Run();
                    break;
                case "G:":
                    updateMap(input);
                //    Battle.Run();
                    break;
                case "C:":
                    coins(input);
               //     Battle.Run();
                    break;
                case "L:":
                    life(input);
               //     Battle.Run();
                    break;
                default:
                    break;


            }

        }
        public void start(String startS)
        {
            //set players
            String[] temp = startS.Split(':');
            String[] temp2;
            int px,py,pd;
            int playerNum;
            Player player;
            for (int i = 1; i < temp.Length; i++)
            {
                temp2 = temp[i].Split(';');
                playerNum = int.Parse(temp2[0].ToCharArray()[1]+"");
                px = int.Parse(temp2[1].Split(',')[0]);
                py = int.Parse(temp2[1].Split(',')[1]);
                pd = int.Parse(temp2[2]);
                player = new Player(px, py, playerNum, pd, false, 100, 0, 0);
                Battle.addPlayer(player, playerNum);
               
            }

        }

        public void initiate(String initiateS)
        {
            //initiate map with the data receieved starting with I
            String[] temp = initiateS.Split(':');
            int me = int.Parse(temp[1].ToCharArray()[1]+"");
            setBricks(temp[2]);
            setStones(temp[3]);
            setWater(temp[4]);


        }

        public void updateMap(String updateS)
        {
            //update map with the data recuieved starting with G
            String[] temp = updateS.Split(':');
            for (int i = 1; i < 6; i++)
            {
                updatePlayer(temp[i]);
            }
            updateBrick(temp[6]);
            CoinPiles2 = Battle.getCoinList();
            Lifepacks2 = Battle.getLifeList();
            for (int k = 0; k < CoinPiles2.Count; k++)
            {
                
                CoinPiles2.ElementAt(k).reduceSeconds();
                if (CoinPiles2.ElementAt(k).getSeconds() == 0)
                {
                    tempCoin = CoinPiles2.ElementAt(k);
                    Battle.addObjects(null, tempCoin.getX(), tempCoin.getY());
                }
                
            }
            Battle.setCoinList(CoinPiles2);
            for (int k = 0; k < CoinPiles2.Count; k++)
            {
                Lifepacks2.ElementAt(k).reduceSeconds();
                if (Lifepacks2.ElementAt(k).getSeconds() == 0)
                {
                    tempLife = Lifepacks2.ElementAt(k);
                    Battle.addObjects(null, tempLife.getX(), tempLife.getY());
                }
            }
            Battle.setLifeList(Lifepacks2);
        }

        public void coins(String coinS)
        {
            String[] temp = coinS.Split(':');
            String[] cordintes = temp[1].Split(',');
            int cx, cy,clt, cv;
            cx = int.Parse(cordintes[0]);
            cy = int.Parse(cordintes[1]);
            clt = int.Parse(temp[2]);
            cv = int.Parse(temp[3]);
            CoinPile coinPile = new CoinPile(100, cx, cy, clt, cv,this);
            Battle.addObjects(coinPile, cx, cy);
            ///Battle.addCoins(coinPile);

        }
        public void life(String lifeS)
        {
            String[] temp = lifeS.Split(':');
            String[] cordintes = temp[1].Split(',');
            int cx, cy, clt;
            cx = int.Parse(cordintes[0]);
            cy = int.Parse(cordintes[1]);
            clt = int.Parse(temp[2]);
            LifePack lifepack = new LifePack(200, cx, cy, clt,this);
            Battle.addObjects(lifepack, cx, cy);
        }
        public void setBricks(String bData)
        {
            int bx, by;
            String[] bricks = bData.Split(';');
            for (int i = 0; i < bricks.Length; i++)
            {
                String[] data = bricks[i].Split(',');
                bx = int.Parse(data[0]);
                by = int.Parse(data[1]);
                Brick brick = new Brick(300, bx, by, 0);
                Battle.addObjects(brick, bx, by);
            }
        }
        public void updateBrick(String uData)
        {
            int bx, by, bd;
            String[] bricks = uData.Split(';');
            for (int i = 0; i < bricks.Length; i++)
            {
                String[] bData = bricks[i].Split(',');
                bx = int.Parse(bData[0]);
                by = int.Parse(bData[1]);
                bd = int.Parse(bData[2]);
                Brick brick = new Brick(300, bx, by, bd);
                Battle.addObjects(brick, bx, by);
            }
        }
        public void setStones(String sData)
        {
            int sx, sy;
            String[] stones = sData.Split(';');
            for (int i = 0; i < stones.Length; i++)
            {
                String[] data = stones[i].Split(',');
                sx = int.Parse(data[0]);
                sy = int.Parse(data[1]);
                Stone stone = new Stone(400,sx,sy);
                Battle.addObjects(stone, sx, sy);
            }
        }
        public void setWater(String wData)
        {
            int wx, wy;
            String[] water = wData.Split(';');
            for (int i = 0; i < water.Length; i++)
            {
                String[] data = water[i].Split(',');
                wx = int.Parse(data[0]);
                wy = int.Parse(data[1]);
                
                Water waterO = new Water(500, wx, wy);
                Battle.addObjects(waterO, wx, wy);
            }
        }
       
        public void updatePlayer(String PData)
        {
            int px, py, direction, shot, health, coin, pointss,id;
            String[] playerData = PData.Split(';');
            String[] cordinates = playerData[1].Split(',');
            id = int.Parse(playerData[0].ToCharArray()[1]+"");
            px = int.Parse(cordinates[0]);
            py = int.Parse(cordinates[1]);
            direction = int.Parse(playerData[2]);
            shot = int.Parse(playerData[3]);
            health = int.Parse(playerData[4]);
            coin = int.Parse(playerData[5]);
            pointss = int.Parse(playerData[6]);
            Player player = new Player(px, py, id, direction, shot.Equals(1), health, coin, pointss);
            if (shot.Equals(1))
            {
                if (!Battle.getShotPlayerList().Contains(id))
                {
                    CoinPile cpt = new CoinPile(100, px, py, 86400000, coin, this);
                    Battle.addObjects(cpt, px, py);
                    Battle.addPlayer(id);

                }
               

            }
            if (Battle.getObject(px, py) != null)
            {
                int t = Battle.getObject(px, py).getID();
                if ((t == 100) || (t == 200))
                {
                    Battle.addObjects(null, px, py);
                }

            }
            Battle.pdatePlayer(player, id);
        }
        public void removeCoinPiles(CoinPile cp, int x, int y)
        {
            Battle.addObjects(null, x, y);
            Battle.removeCoinPile(cp);


        }
         public void removeLifePacks(LifePack lp, int x, int y)
        {
            Battle.addObjects(null, x, y);
            Battle.removeLife(lp);


        }
    }
}
