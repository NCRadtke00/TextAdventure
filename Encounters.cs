using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public class Encounters
    {
        public static Random rand = new Random();
        // Encounter generic
        // Encounter
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door and grab a rusty axe while charging toward your captor");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Security Guard", 1, 4);
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and there you see a hulking beast of a man...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void BigBossEncounter()
        {
            Console.Clear();
            Console.WriteLine("The door flys open!");
            Console.WriteLine("An old blad man, carrying a large tome quickly approaches.");
            Console.ReadKey();
            Combat(false, "Lester", 10, 50);
        }
        public static void ThePawnEncounter()
        {
            Console.Clear();
            Console.WriteLine("The door slowly creaks open as you peer into the dark room.");
            Console.WriteLine("You see an old man with white hair looking at photographs.");
            Console.ReadKey();
            Combat(false, "Jeff", 5, 30);
        }
        // Encounter Tools
        public static void RandomEncounter()
        {
            switch (rand.Next(0,3))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    BigBossEncounter();
                    break;
                case 2:
                    ThePawnEncounter();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|  (R)un    (H)eal  |");
                Console.WriteLine("=====================");
                Console.WriteLine(" Potions: " + Program.currentPlayer.potion + " Health " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("With haste you charge, your axe at the ready! " + n + " is quicker than you expected and hits you back.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("As " + n + " prepares to strike, you take a defensive stance");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from " + n + ", you feel his cold hand grasp your ankle and pull you to the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " + damage + " health and are unable to escape");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade " + n + " and you successfully escape");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("As you desperatly grasp for a potion in your bag, all that you feel are empty glass flasks.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine( n+ " sneaks up behind you and strikes you with a might blow! You lose " +damage+ " health");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag nad pull out a glowing, purple flask. You take a refreshing drink.");
                        int potionV = 5;
                        Console.WriteLine("You have gained " +potionV+ " health back");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("As you were occupied, " +n+ " snuck up behind you and attacked you!");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage <0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " +damage+ " health");

                    }
                    Console.ReadKey();
                }
                if(Program.currentPlayer.health<=0)
                {
                    //deathcode
                    Console.WriteLine("As "+n+" stands tall and comes down to strike. You have been taken captive again by "+n);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = Program.currentPlayer.GetCoins();
            Console.WriteLine("As you stand victorious over "+n+" its body dissolves into "+c+" gold coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }

        public static string GetName()
        {
            switch (rand.Next(0, 5))
            {
                case 0:
                    return "Bill";
                case 1:
                    return "Alan";
                case 2:
                    return "Donny";
                case 3:
                    return "Mike";
                case 4:
                    return "Andy";
            }
            return "The lady of the house";
        }
    }
}

        
    
