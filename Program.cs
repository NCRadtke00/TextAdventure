using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
     
        static void Main(string[] args)
        {
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

    }
}
