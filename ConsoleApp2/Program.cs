using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.CodeDom.Compiler;
using System.Linq;
using ConsoleApp2;

namespace ServerSocketApp
{
   


    class Program
    {
        //Player Player = new Player();
        public static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for a connection.");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client accepted.");
                NetworkStream stream = client.GetStream();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                try
                {
                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);
                    int recv = 0;
                    foreach (byte b in buffer)
                    {
                        if (b != 0)
                        {
                            recv++;
                        }
                    }
                    string request = Encoding.UTF8.GetString(buffer, 0, recv);
                    Console.WriteLine("request received: " + request);

                    
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

                    string text = request;
                   System.Console.WriteLine($"Original text: '{text}'");

                    string[] words = text.Split(delimiterChars);
                    System.Console.WriteLine($"{words.Length} words in text:");
                   
                    string PlayerData = "Player Data is PlayerData";
                    foreach ( var word in words)
                    {

                        //Takeing out The "varibale String" From recived Data(from Client) Splitting the word from the string
                        string Recivestring = string.Empty;

                        for (int i = 0; i < word.Length; i++)
                        {
                            if (Char.IsLetter(word[i]))
                                Recivestring += word[i];
                        }


                        //Takeing Out Value from Client(Splitting the int from the string)
                        string str2 = string.Empty;
                        int Reciveint = 0;
                        //Console.WriteLine($"String with number: {word}");
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (Char.IsDigit(word[i]))
                                str2 += word[i];
                        }
                        if (str2.Length > 0)
                        {
                            Reciveint = int.Parse(str2);
                            Console.WriteLine($"Extracted Number: {Reciveint}");
                        }
                        //Insert Value To Variable from reviced Data
                        if (Recivestring.Length > 0 ) {
                            System.Console.WriteLine(Recivestring);
                            if (Recivestring == "Playerid")
                            {
                                Player.Playerid = Reciveint;
                            }
                            if (Recivestring == "TargetId")
                            {
                                    Player.TargetId = Reciveint;
                            }
                            if (Recivestring == "Health")
                            {
                                Player.Health = Reciveint;
                            }
                            if (Recivestring == "Mana")
                            {
                                Player.Mana = Reciveint;
                     
                            }
                            if (Recivestring == "Capacity")
                            {
                                Player.Capacity = Reciveint;

                            }
                            if (Recivestring == "Stamina")
                            {
                                Player.Stamina = Reciveint;

                            }
                            if (Recivestring == "MagicLevel")
                            {
                                Player.MagicLevel = Reciveint;

                            }
                            if (Recivestring == "Fist")
                            {
                                Player.Fist = Reciveint;


                            }
                            if (Recivestring == "Club")
                            {
                                Player.Club = Reciveint;

                            }
                            if (Recivestring == "Sword")
                            {
                                Player.Sword = Reciveint;

                            }
                            if (Recivestring == "Axe")
                            {
                                Player.Axe = Reciveint;

                            }
                            if (Recivestring == "Distance")
                            {
                                Player.Distance = Reciveint;

                            }
                            if (Recivestring == "Shielding")
                            {
                                Player.Shielding = Reciveint;

                            }
                            if (Recivestring == "X")
                            {
                                Player.X = Reciveint;

                            }
                            if (Recivestring == "Y")
                            {
                                Player.Y = Reciveint;

                            }
                            if (Recivestring == "Z")
                            {
                                Player.Z = Reciveint;

                            }
                        }






                        

                        //System.Console.WriteLine($"{word}");






                    }
                    /* need to add                     
                     * sw.WriteLine(PlayerData);
                     * sw.Flush();
                     * to a new Thread
                     */
                    
                    sw.WriteLine(PlayerData);
                    sw.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong.");
                    sw.WriteLine(e.ToString());
                }
            }
        }
    }
}