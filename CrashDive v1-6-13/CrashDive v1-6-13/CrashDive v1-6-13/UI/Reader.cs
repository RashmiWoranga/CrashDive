using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrashDive_v1_6_13.objects;


//This class is used to check messages received by server

namespace CrashDive_v1_6_13.UI
{
    class Reader
    {
        String input;
        Map Battle = new Map(20,5); // give input wrt to the map width or length
        public void getInput(String inputS)
        {
            input = inputS;
        }
        public void check()
        {
            String first = input.Substring(0, 2);
            input = input.Substring(0, first.Length - 1); // remove # mark
            
            switch (first)
            {
                case "S:":
                    start(input);
                    break;
                case "I:":
                    initiate(input);
                    break;
                case "G:":
                    updateMap(input);
                    break;
                case "C:":
                    coins(input);
                    break;
                case "L:":
                    life(input);
                    break;
                default:
                    break;


            }

        }
        public void start(String startS)
        {
            //set players
            String[] temp = startS.Split(':');
            for (int i = 1; i < temp.Length; i++)
            {

            }

        }

        public void initiate(String initiateS)
        {
            //initiate map with the data recuieved starting with I


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
            CoinPile coinPile = new CoinPile(100, cx, cy, clt, cv);
            Battle.addObjects(coinPile, cx, cy);

        }
        public void life(String lifeS)
        {
            String[] temp = lifeS.Split(':');
            String[] cordintes = temp[1].Split(',');
            int cx, cy, clt;
            cx = int.Parse(cordintes[0]);
            cy = int.Parse(cordintes[1]);
            clt = int.Parse(temp[2]);
            LifePack lifepack = new LifePack(200, cx, cy, clt);
            Battle.addObjects(lifepack, cx, cy);
        }
        public void setBricks(String bData)
        {
            int bx, by, bd;
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
            int px, py, direction, shot, health, coin, points;
            String[] playerData = PData.Split(';');
            String[] cordinates = playerData[1].Split(',');
            px = int.Parse(cordinates[0]);
            py = int.Parse(cordinates[1]);
            direction = int.Parse(playerData[2]);
            shot = int.Parse(playerData[3]);
            health = int.Parse(playerData[4]);
            coin = int.Parse(playerData[5]);
            points = int.Parse(playerData[6]);
        }
    }
}
