using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom, IMoveable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AlternateDescription { get; set; }
        public List<Item> Items { get; set; }
        public bool CanMove { get; set; }
        public string MustDo { get; set; }
        public string HaveDone { get; set; }


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

        public Room(string name, bool moveable, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            CanMove = moveable;
        }
    }
}