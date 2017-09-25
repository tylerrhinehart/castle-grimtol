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
                System.Console.WriteLine($"Greetings {CurrentPlayer.Name}. You are on level {CurrentRoom.Name}. Your point: {CurrentPlayer.Score}");
                if (CurrentPlayer.Inventory.Count > 0)
                {
                    System.Console.WriteLine("Your man-puse has:");
                    foreach (Item item in CurrentPlayer.Inventory)
                    {
                        System.Console.WriteLine(item.Name);
                    }

                }
                else
                {
                    System.Console.WriteLine("Your man-purse is empty.");
                }
                if (CurrentRoom.CanMove)
                {
                    System.Console.WriteLine(CurrentRoom.AlternateDescription);
                }
                else
                {
                    System.Console.WriteLine(CurrentRoom.Description);
                }

                string Choice = Console.ReadLine();
                string[] Action = Choice.Split(' ');

                if (Action[0].ToLower() == "take" || Action[0].ToLower() == "t")
                {
                    Item TakeItem = FindItem(Action[1]);
                    if (TakeItem != null)
                    {
                        System.Console.WriteLine($"You have add a {TakeItem.Name} to your man-purse.");
                        string Pause1 = Console.ReadLine();
                        CurrentPlayer.Score ++;
                    }
                    else
                    {
                        System.Console.WriteLine("No such item on this level");
                        string Pause = Console.ReadLine();
                    }
                }
                else if (Action[0].ToLower() == "go" || Action[0].ToLower() == "g")
                {
                    int RoomNum;
                    Int32.TryParse(CurrentRoom.Name, out RoomNum);
                    if (Action[1].ToLower() == "up" && CurrentRoom.CanMove)
                    {
                        if (Rooms[(RoomNum + 1).ToString()] != null)
                        {
                            CurrentRoom = Rooms[(RoomNum + 1).ToString()];
                            CurrentPlayer.Score ++;
                        }
                    }
                    else if (Action[1].ToLower() == "up" && !CurrentRoom.CanMove)
                    {
                        System.Console.WriteLine("Can't move up yet.");
                    }
                    else if (Action[1].ToLower() == "down")
                    {
                        if (Rooms[(RoomNum - 1).ToString()] != null)
                        {
                            CurrentRoom = Rooms[(RoomNum - 1).ToString()];
                            CurrentPlayer.Score ++;
                        }
                    }
                }
                else if (Action[0].ToLower() == "use" || Action[0].ToLower() == "u")
                {
                    System.Console.WriteLine($"{CurrentPlayer.Inventory.Contains(SearchInventory("sheers")).ToString()}");
                    if (Action[1] == CurrentRoom.MustDo)
                    {
                        CurrentRoom.CanMove = true;
                    }
                    else
                    {
                        foreach (Item item in CurrentPlayer.Inventory)
                        {
                            if (Action[1].ToLower() == item.Name)
                            {
                                CurrentRoom.HaveDone = item.Name;
                                if (CurrentRoom.HaveDone == CurrentRoom.MustDo)
                                {
                                    CurrentRoom.CanMove = true;
                                }
                                System.Console.WriteLine(item.Description);
                                string Pause = Console.ReadLine();
                            }
                        }
                    }
                    if (CurrentRoom.Name == "2")
                    {
                        if (Action[1] == "shovel" && CurrentPlayer.Inventory.Contains(SearchInventory("shovel")))
                        {
                            System.Console.WriteLine("You hit the sheep on the head with your shovel but that only makes the sheep angier and it headbutts you out the window.");
                            System.Console.WriteLine("Luckily you grab onto a rope as you're falling and you swing back into the 1st Level");
                            Console.ReadLine();
                            CurrentRoom = Rooms["1"];
                        }
                        else if (Action[1] == "sheers" && CurrentPlayer.Inventory.Contains(SearchInventory("sheers")))
                        {
                            CurrentRoom.CanMove = true;
                            System.Console.WriteLine("Being the smart adventurer that you are, you realize that the sheep is angry because its wool is way too fluffy.");
                            System.Console.WriteLine("You decide to use your sheers an shave the sheep. It is now happy and allows you to move to the next level.");
                            System.Console.WriteLine("As you are leaving you hear the sheep mutter something. The only words you caught were 'I find romance when I start to dance' and 'black'.");
                            Console.ReadLine();
                        }

                    }
                    if (CurrentRoom.Name == "3")
                    {
                        if (Action[1] == "1")
                        {
                            System.Console.WriteLine("You say 'Pickles are green and orangles are black, my left rear hoof is the shape of a seagul.' Instantly the all the candles and torches are lit.");
                            System.Console.WriteLine("You can now find the stairs to the next level.");
                        }
                    }
                    if(CurrentRoom.Name == "4" && Action[1].ToLower() != "boogie-wonderland")
                    {
                        System.Console.WriteLine("Thats not his favorite song and the Gnome King boops you on the head and you lose consciousness and are thrown out of the tower.");
                        Console.ReadLine();
                        Playing = false;
                    }
                }
                else if (Action[0].ToLower() == "help" || Action[0].ToLower() == "h")
                {
                    System.Console.WriteLine("To move levels: type 'go' + 'up/down'");
                    System.Console.WriteLine("To take item: type 'take' + 'item name'");
                    System.Console.WriteLine("To use item: type 'use' + 'item name'");
                    System.Console.WriteLine("To quit game: type 'quit'");
                    string Pause = Console.ReadLine();
                }
                else if (Action[0].ToLower() == "quit" || Action[0].ToLower() == "q")
                {
                    Playing = false;
                    System.Environment.Exit(0);
                }
            }
        }

        public void Reset()
        {
        }

        public void Setup()
        {
            Room Level1 = new Room("1", true, "You have begun your acsent up the tower. On this level you find two items: a shovel, and a pair of sheers.");
            Room Level2 = new Room("2", false, "You made it to the second level. You find an angry looking sheep that is poised to attack. What do you do?");
            Room Level3 = new Room("3", false, "You've made it past the sheep. On this level you cant see anything, but you remember the sheep muttering something about this level that illuminated everything. Did the sheep say 'Pickles are green and orangles are black, my left rear hoof is the shape of a seagul.' or 'Clap on'? ('use 1' or 'use 2')");
            Room Level4 = new Room("4", false, "Congratulations, you made it to the final level of the tower. To get your prize you must sing the favorite some of the Gnome King. Who is the Gnome King you might be asking... It doesn't matter who he is, you just have to sing his favorite song.(use: happy-birthday, boogie-wonderland, ave-maria, shake-it-off, or let-it-go')");

            Level1.AlternateDescription = Level1.Description;
            Level2.AlternateDescription = "You find the sheep that you sheered jumping around the room and doing burpees because its so happy.";
            Level3.AlternateDescription = "The room is well lit because you said the magic words that lit everything.";
            Level4.AlternateDescription = "You sang the correct song and now you and the Gnome Kings are bff's. He wants to give you his most valuable treause: a golden spatula.";

            Level2.MustDo = "sheers";
            Level3.MustDo = "1";
            Level4.MustDo = "boogie-wonderland";


            Item Shovel = new Item("shovel", "An ordinary shovel, but it has a dent the shape of a sheep's skill in it.");
            Item Sheers = new Item("sheers", "A pair of sheers used to cut the wool of a sheep.");
            Item Treasure = new Item("Golden Spatula", "The prizes treasure of the Gnome King.");

            Level1.AddItem(Shovel);
            Level1.AddItem(Sheers);
            Level4.AddItem(Treasure);

            Rooms.Add("1", Level1);
            Rooms.Add("2", Level2);
            Rooms.Add("3", Level3);
            Rooms.Add("4", Level4);

            CurrentRoom = Level1;
        }

        public void UseItem(string itemName)
        {
        }

        Item FindItem(string name)
        {
            Item FoundItem = null;
            foreach (Item item in CurrentRoom.Items)
            {
                if (item.Name == name)
                {
                    AddToInventory(item);
                    // CurrentPlayer.Inventory.Add(item);
                    FoundItem = item;
                    return FoundItem;
                    // CurrentRoom.Items.Remove(item);
                }
            }
            return FoundItem;
        }

        void AddToInventory(Item item)
        {
            CurrentPlayer.Inventory.Add(item);
            CurrentRoom.Items.Remove(item);
        }

        Item SearchInventory(string name)
        {
            Item FoundItem = null;
            foreach (Item item in CurrentPlayer.Inventory)
            {
                if (item.Name == name)
                {
                    FoundItem = item;
                    return FoundItem;
                }
            }
            return FoundItem;
        }

        public Game(string name)
        {
            Player Player = new Player(name);
            Player.Score = 0;
            CurrentPlayer = Player;
        }
    }
}