using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Dictionary<string, Room> Rooms = new Dictionary<string, Room>();
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        bool Playing = true;

        public void Play()
        {
            while (Playing)
            {
                Console.Clear();
                System.Console.WriteLine($"Greetings {CurrentPlayer.Name}. You are on level {CurrentRoom.Name}");
                System.Console.WriteLine(CurrentRoom.Description);
                string Choice = Console.ReadLine();
                string[] Action = Choice.Split(' ');
                if (Action[0].ToLower() == "take")
                {
                    foreach (Item item in CurrentRoom.Items)
                    {
                        if (item.Name == Action[1].ToLower())
                        {
                            CurrentPlayer.Inventory.Add(item);
                            // CurrentRoom.Items.Remove(item);
                            System.Console.WriteLine($"You have add a {item.Name} to your man-purse.");
                            string Pause1 = Console.ReadLine();
                        }
                    }
                    // System.Console.WriteLine("No such item on this level");
                    // string Pause = Console.ReadLine();
                }
                else if (Action[0].ToLower() == "go")
                {
                    int RoomNum;
                    Int32.TryParse(CurrentRoom.Name, out RoomNum);
                    if (Action[1].ToLower() == "up")
                    {
                        if (Rooms[(RoomNum + 1).ToString()] != null)
                        {
                            CurrentRoom = Rooms[(RoomNum + 1).ToString()];
                        }
                        else
                        {
                            System.Console.WriteLine("Can't move up yet.");
                        }
                    }
                    else if (Action[1].ToLower() == "down")
                    {
                        if (Rooms[(RoomNum - 1).ToString()] != null)
                        {
                            CurrentRoom = Rooms[(RoomNum - 1).ToString()];
                        }
                        else
                        {
                            System.Console.WriteLine("Can't move down yet.");
                        }
                    }
                }
                else if (Action[0].ToLower() == "use")
                {
                    foreach (Item item in CurrentPlayer.Inventory)
                    {
                        if (Action[1].ToLower() == item.Name)
                        {
                            System.Console.WriteLine(item.Description);
                            string Pause = Console.ReadLine();
                        }
                    }

                }
                else if (Action[0].ToLower() == "help")
                {
                    System.Console.WriteLine("To move levels: type 'go' + 'up/down'");
                    System.Console.WriteLine("To take item: type 'take' + 'item name'");
                    System.Console.WriteLine("To use item: type 'use' + 'item name'");
                    System.Console.WriteLine("To quit game: type 'quit'");
                    string Pause = Console.ReadLine();
                }
                else if (Action[0].ToLower() == "quit")
                {
                    Playing = false;
                }
            }
        }

        public void Reset()
        {

        }

        public void Setup()
        {
            Room Level1 = new Room("1", "You have begun your acsent up the tower. On this level you find two items: a shovel, and a pair of sheers.");
            Room Level2 = new Room("2", "You made it to the second level. You find an angry looking sheep that is poised to attack. What do you do?");
            Room Level3 = new Room("3", "You've made it past the sheep. On this level you cant see anything, but you remember the sheep muttering something about this level that illuminated everything. Did the sheep say 'Pickles are green and orangles are black, my left rear hoof is the shape of a seagul.' or 'Clap on'?");
            Room Level4 = new Room("3", "Congratulations, you made it to the final level of the tower. To get your prize you must sing the favorite some of the Gnome King. Who is the Gnome King you might be asking... It doesn't matter who he is, you just have to sing his favorite song.");

            Item Shovel = new Item("shovel", "An ordinary shovel, but it has a dent the shape of a sheep's skill in it.");
            Item Sheers = new Item("sheers", "A pair of sheers used to cut the wool of a sheep.");

            Level1.AddItem(Shovel);
            Level1.AddItem(Sheers);

            Rooms.Add("1", Level1);
            Rooms.Add("2", Level2);
            Rooms.Add("3", Level3);
            Rooms.Add("4", Level4);

            CurrentRoom = Level1;
        }

        public void UseItem(string itemName)
        {

        }

        public Game(string name)
        {
            Player Player = new Player(name);
            CurrentPlayer = Player;
        }
    }
}