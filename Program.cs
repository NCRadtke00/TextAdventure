using System;

namespace TextAdventure
{
    class Program
    {
        public static Player currentPlayer = new Player();
     
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter
        }

        static void Start()
        {
            Console.WriteLine("Ender's Dungeon!");
            Console.WriteLine("Name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You have awoken in a cold, dark, stone room. You feel dazed and are having trouble remembering");
            Console.WriteLine("anything about your past.");
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
            Console.WriteLine("You grope around in the darkness until you find a door handl. You feel some resistance as");
            Console.WriteLine("you turn the handle, but the rusty lock breaks with little efoort. You see your captor");
            Console.WriteLine("standing with his back to you outside the door.");
            

        }

    }
}
