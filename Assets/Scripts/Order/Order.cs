
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public List<ItemInfo> items;

    public Order(){
        items = new List<ItemInfo>();
    }

    public bool matches(Order another){
        return matches(another.items);
    }

    public bool matches(List<ItemInfo> anotherItems){
        if(items.Count != anotherItems.Count) return false;
        foreach(ItemInfo item in items){
            if(anotherItems.FindIndex(anotheritem => anotheritem.matches(item)) == -1) return false;
        }
        return true;
    }
}