using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

using CrashDive_v1_6_13.objects;
using CrashDive_v1_6_13.UI;

namespace CrashDive_v1_6_13
{

   public class Network_Communication
    {
      //  ConvertDataFormat cdf = new ConvertDataFormat();
        #region
        private NetworkStream serverStream;//out-going stream
        private TcpClient client;//talk back to server
        private BinaryWriter writer;//write to server console
        private NetworkStream clientStream;//in-coming stream
        private TcpListener listner;//listen to server
        public String reply = "";//messeage to be written
        public String recieved;
        private Game1 Game1;
        private Thread serverlistningThread;
       // private static Network_Communication tgc = new Network_Communication();
        Reader reader;
       // String s;
        #endregion

        public Network_Communication(Game1 Game,Reader r)
        {
            Game1 = Game;
            reader = r;
        }

        public void startlistening()
        {
            serverlistningThread = new Thread(new ThreadStart(this.RecieveData));
            serverlistningThread.Start();
            while (!serverlistningThread.IsAlive) ;

        }

        public void RecieveData()
        {
            bool errorOcurred = false;
            String ssss = "";
            Socket connection = null;//the socket that is listened to
          //  StreamWriter writetext = new StreamWriter("writee.txt");
            try
            {
                this.listner = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);
                //start listning
                this.listner.Start();
               
                while (true)
                {
                    //connection is connected socket
                    connection = listner.AcceptSocket();
                    if (connection.Connected)
                    {
                        //To read from socket create NetworkStream object associated with socket
                        this.serverStream = new NetworkStream(connection);
                        SocketAddress sockAdd = connection.RemoteEndPoint.Serialize();
                        string s = connection.RemoteEndPoint.ToString();


                        List<Byte> inputStr = new List<byte>();

                        int asw = 0;
                        while (asw != -1)
                        {
                            asw = this.serverStream.ReadByte();
                            inputStr.Add((Byte)asw);
                        }
                        reply = Encoding.UTF8.GetString(inputStr.ToArray());
                        this.serverStream.Close();
                        String ip = s.Substring(0, s.IndexOf(":"));
                        int port = 7000;
                        try
                        {
                            string ss = reply.Substring(0, reply.IndexOf(";"));
                            port = Convert.ToInt32(ss);
                        }
                        catch (Exception)
                        {
                            port = 7000;
                        }
                        recieved = reply.Substring(0, reply.Length - 1);
                     
                      //  ssss = ssss + " " + recieved;
                        Console.WriteLine("hhhhhhhhhhhhhhhhhh : " + reply.Substring(0, reply.Length - 1));
                        reader.getInput(reply.Substring(0, reply.Length - 1));

                       // reader.check();
                    
                    }
                }
            }
            catch (Exception e)
            {
              //  Console.WriteLine("Communication(RECIEVING) Failed!\n" + e.Message);
                errorOcurred = true;
            }
            finally
            {
                if (connection != null)
                    if (connection.Connected)
                    {
                       
                        connection.Close();
                       
                    }

                if (errorOcurred)
                {
                 
                    this.RecieveData();
   
                }
            }
        }

        public void SendData()
        {
          //  StreamWriter writetext = new StreamWriter("write.txt");
          
            //opening connection
            this.client = new TcpClient();
            try
            {
                this.client.Connect("127.0.0.1", 6000);
                if (this.client.Connected)
                {
                    //to write to the socket
                    this.clientStream = client.GetStream();
                    //create object for writing across stream
                    this.writer = new BinaryWriter(clientStream);
                    Byte[] tempStr = Encoding.ASCII.GetBytes(reply.Substring(0, reply.Length));

                    //writing to the port
                    this.writer.Write(tempStr);
                   
                       // Console.WriteLine(tempStr+"\t Data: " + reply.Substring(0, reply.Length) + " is written to " + "127.0.0.1" + " on " + "6000");
                    this.writer.Close();
             
                    this.clientStream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Communication (WRITING) to " + "127.0.0.1" + " on " + "6000" + " Failed!\n" + e.Message);
              
            }
            finally
            {
                this.client.Close();
            }
        }

        public void stopListner()
        {

            if (serverlistningThread != null)
            {
                serverlistningThread.Abort();
            }
        }
   }
}
