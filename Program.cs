using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace TextAdventure
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
     
        static void Main(string[] args)
        {
            if(!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");

            }
            Start();
            Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }


        }

        static void Start()
        {
            Console.WriteLine("Welcome to paridise!");
            Console.WriteLine("Name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You have awoken in a cold, dark, stone room.");
            Console.WriteLine("You can hear a faint chant coming from the distance.");
            Console.WriteLine("You feel dazed and are having trouble remembering anything.");
            Console.WriteLine("The chanting seems to be getting closer...");
            if (currentPlayer.name == " ")
            {
                Console.WriteLine("You can't even remember your own name... ");
            }
            else
            {
                Console.WriteLine("You know your name is " + currentPlayer.name);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You grope around in the darkness until you find a door handle.");
            Console.WriteLine("You feel some resistance as you turn the handle, but the rusty lock breaks with little effort.");
            Console.WriteLine("As your eyes slowly adjust to the light, you can see a man with his back to you.");
            Console.WriteLine("He is standing with his back to you outside the door.");

        }
        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            bindForm.Serialize(file, currentPlayer);
            file.Close();
        }
        public static Player Load()
        {
            Console.Clear();
            Console.WriteLine("Chose your saved file: ");
            string[] paths = Directory.GetDirectories("saves");
            List<Player> players = new List<Player>();

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }

          

            bool b = true;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your player: ");

                foreach (Player p in players)
                {
                Console.WriteLine(p.id+ " : " + p.name);
                }
                Console.WriteLine("Please input player name or id (id:# or playername)");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("there is no player with that id!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                            Console.ReadLine();
                        }
                    }
                    else 
                    {
                        foreach (Player player in players)
                        {
                            if(player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name!");
                        Console.ReadLine();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                    Console.ReadLine();
                }
            }
        }
    }
}
