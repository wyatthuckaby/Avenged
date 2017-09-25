using System.Collections.Generic;

namespace zork{
    class Dungeon : IRoom{
        public string Name { get; set; }
        public string Text { get; set; }

        public List<IItem> items {get; set;}
        public Direction wayIn { get; set; }
        public Direction wayOut { get; set; }

        public Dungeon(){
            Name = "Dungeon";
            Text = "You see a locked door to your north. something might be nearby to get through this. ";
            items = new List<IItem>();  
            wayIn = Direction.EAST;
            wayOut = Direction.LOCKED;          
        }
    }
}