using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }


        // public void In()
        // {
        //     System.Console.WriteLine(Description);
        //     string decision = Console.ReadLine();
        // }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void UseItem(Item item)
        {

        }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
        }
    }
}