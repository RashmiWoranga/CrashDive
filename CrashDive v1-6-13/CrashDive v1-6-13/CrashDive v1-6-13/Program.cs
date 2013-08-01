using System;

using CrashDive_v1_6_13;

namespace CrashDive_v1_6_13
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        
        static void Main(string[] args)
        {
            
            Game1 game = new Game1();
            game.Run();
           // String h;
            //nc.run();
           // game.Run();
            //using (Game1 game = new Game1())
            //{
            //   // Console.Title = "Console";
            ////    System.Console.WriteLine("Server started...");
            //            //        h = System.Console.ReadLine();
            ////    int s  = System.Console.Read();
                
            // //   String x  = Console.ReadLine();
            //    game.Run();
                
            //   //game.Run();
                
            //}
        }
    }
#endif
}

