using System;

namespace zork{
    class DungeonKey : IItem
    {
        public int damage { get; set; }
        public int health { get; set; }
        public string prop { get; set; }
        public string name { get; set; }

        public void eat()
        {
            Console.WriteLine("That was dumb.");
        }

        public void hit(string enemy)
        {
            Console.WriteLine($"You throw your key as hard as you can at {enemy}");
            Console.WriteLine("It bounces off the wall and hits you square in the forhead. Ow.");
        }

        public void Use()

        {
            
        }

        public DungeonKey(){
            damage = 0;
            health = -100;
            prop = "a";
            name = "Dungeon Key";
        }
    }
}