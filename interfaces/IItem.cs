namespace zork {
    interface IItem{
        int damage {get;set;}
        int health {get;set;}
        
        string prop {get; set;}
        string name {get; set;}
        void hit(string enemy);
        void eat();

        void Use();
    }
}