using System.Collections.Generic;

namespace zork{
    interface IRoom
    {
        string Name {get; set;}
        string Text {get; set;}
        List<IItem> items {get; set;} 

        Direction wayIn {get; set;}
        Direction wayOut {get; set;}
    }
}