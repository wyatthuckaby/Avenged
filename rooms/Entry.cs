using System.Collections.Generic;

namespace zork{
    class Entry : IRoom{
        public string Name { get; set; }
        public string Text { get; set; }

        public List<IItem> items {get; set;}

        public Direction wayIn { get; set; }
        public Direction wayOut { get; set; }
        public Entry(){
            Name = "Entry";
            Text = "You find yourself surrounded by thick cobblestone. And slighty further foward is a door.";
            items = new List<IItem>();
            items.Add(new DungeonKey());
            wayIn = Direction.NULL;
            wayOut = Direction.WEST;
        }
    }
}