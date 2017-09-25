using System;
using System.Collections.Generic;

namespace zork {
    public class Player{
        List <IRoom> map  = new List<IRoom>();
        List <IItem> inventory = new List<IItem>();
        int currentMap = -1; //heh how neat is that

        int health = 100;
        public void RenderMap(){
            Console.WriteLine(currentMap.ToString());
            Console.Clear();
            Console.WriteLine($"You entered {map[currentMap].Name}");
            Console.WriteLine(map[currentMap].Text);

            if (map[currentMap].items.Count <= 0){
                goto nolist;
            }
            else if (map[currentMap].items.Count == 1){
                Console.WriteLine($"You see {map[currentMap].items[0].prop} {map[currentMap].items[0].name}");

            }
            else{
                Console.WriteLine("You look arond and see some things:");
                for (int i = map[currentMap].items.Count; i >= 0; i--){
                    Console.WriteLine($"  {map[currentMap].items[i].prop} {map[currentMap].items[i].name}");
                }
            }
            nolist:
                return;
        }
        public void LoadNextMap(){
            currentMap++;
            RenderMap();
        }
        public void UnlockDungeon(){
            if (map[currentMap].Name == "Dungeon" && inventory.FindIndex(x => x.name == "Key for a dungeon") != -1){
                map[currentMap].wayOut = Direction.NORTH;
                Console.WriteLine("A wall falls into rubble to your north.");
            }
        }
        public void LoadPreviousMap(){
            currentMap--;
            RenderMap();     
        }
        public void AddMaps(){
            map.Add(new Entry());
            map.Add(new Dungeon());

        }

        public void PlayerMove(Direction direction){
            if ((int)direction == (int)map[currentMap].wayOut ){ 
                LoadNextMap();
            } else if ((int)direction == (int)map[currentMap].wayIn){
                LoadPreviousMap();
            } else {
                Console.WriteLine("You slam your head into a wall.");
            }
        }
        /**
        ProcCommand:
        Returns hasquit when the correct command it put.
         */
        public bool procCommand(string command){
            command = command.ToLower();

            switch(command[0]){
                case 'q':
                    return true; //no break here to avoid the stupid unreachable code warning(though it is correct)
                case 'h':
                {
                    Console.WriteLine("Help Page:");
                    Console.WriteLine("h, ? or help ------- Displays help page");
                    Console.WriteLine("g or go ------------ Moves player in specified direction");
                    Console.WriteLine("u or use ----------- Uses a specified item from your inventory");
                    Console.WriteLine("e or eat ----------- Eat a specified item");
                    Console.WriteLine("t or take -------- Picks up the items in the room");
                }
                break;
                case 'g':
                {
                    // Console.WriteLine(command.LastIndexOf(' '));
                    // //lock scope
                    // Console.WriteLine((command.Length-1).ToString());
                    // Console.WriteLine(command);
                    // command += " ";
                    string userDirection = command.Substring(command.LastIndexOf(' ') +1);
                    Console.WriteLine(userDirection);
                    //filter out single letters and convert all to its full size counterparts.
                    switch(userDirection[0]){
                        case 'w':
                            PlayerMove(Direction.WEST);
                        break;
                        case 's':
                            PlayerMove(Direction.SOUTH);
                        break;
                        case 'n':
                            PlayerMove(Direction.NORTH);
                        break;
                        case 'e':
                            PlayerMove(Direction.EAST);
                        break;
                        default:
                            PlayerMove((Direction)0xABAC);
                        break;
                    }
                }
                break;
                case 'u':
                {
                    string item = command.Substring(command.IndexOf(' ') +1);
                    //Console.WriteLine(item);
                    if (item == "dungeon key"){
                        UnlockDungeon();
                        break;
                    }
                    IItem i = inventory.Find(x => x.name == item);
                    
                    System.Console.WriteLine(i);
                }
                break;
                case 'e': {
                    string item = command.Substring(command.LastIndexOf(' ') +1);
                    inventory.Find(x => x.name == item).eat();
                    health -= inventory.Find(x => x.name == item).health;
                    if (health <= 0){
                        Console.WriteLine("You died!");
                        return true;
                    }
                }
                
                break;
                case 't': {
                    string item = command.Substring(command.IndexOf(' ') +1);
                    inventory.Add(map[currentMap].items.Find(x => x.name == item));
                    Console.WriteLine($"You took an item! ");
                }  
                break;
            }
            return false;
        }
        public Player(){
            AddMaps();
            //becasue we set the currentMap to -1 we can just call the next Map to the entry map.
            LoadNextMap();
        }

    }
}