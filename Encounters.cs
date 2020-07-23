using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Encounters
    {
        public static Random rand = new Random();
        // Encounter generic
        // Encounter
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door and grab a rusty metal sword while charging toward your captor");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Human Rouge", 1, 4);
        }
        // Encounter Tools
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|  (R)un)   (H)eal  |");
                Console.WriteLine("=====================");
                Console.WriteLine(" Potions: " + Program.currentPlayer.potion + " Health " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("With haste you charge " + n + " striking a deadly blow");
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
                    Console.WriteLine("As the " + n + "prepares to strike, you take a defensive stance");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine("You lose " + damage + "health and deal " + attack + "damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from the " + n + ", its strike catches you in the back, sending you");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose" + damage + " health and are unable to escape");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the " + n + " and you successfully escape");
                        Console.ReadKey();
                        //go to store
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
                        Console.WriteLine("The" + n + "strikes you with a might blow and you lose" +damage+ "health");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag nad pull out a glowing, purple flask. You take a refreshing drink.");
                        int potionV = 5;
                        Console.WriteLine("You have gained" +potionV+ "health back");
                        Program.currentPlayer.health += potionV;
                    }
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
        }
    }
}

        
    
