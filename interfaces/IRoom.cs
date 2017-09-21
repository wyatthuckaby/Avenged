using System.Collections.Generic;

namespace zork{
    interface IRoom
    {
        string Name {get; set;}
        
        List<IItem> items {get; set;}
        IRoom East {get; set;}
        IRoom West {get; set;}
        IRoom South {get;set;}
        IRoom North {get;set;}

        void Start();
    }
}