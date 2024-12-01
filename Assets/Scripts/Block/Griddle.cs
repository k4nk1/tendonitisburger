using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griddle : Block
{
    public override Item Put(Item item)
    {
        return item is Grillable ? base.Put(item) : item;
    }
    void Update(){
        if(inventory != null){
            (inventory as Grillable).Grill();
        }
    }
}
