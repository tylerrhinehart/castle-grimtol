using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Lambshire Towel. At the top of this tower is a wool-tastic trasure, but you must overcome each challenge in order to earn it. Do you wish to continue? (y/n)");
            string decision = Console.ReadLine();
            if (decision.ToLower() == "y")
            {
                System.Console.WriteLine("What is your name, adventurer?");
                string Name = Console.ReadLine();
                Game Game = new Game(Name);
                Game.Setup();
                Game.Play();
            }

        }
    }
}
