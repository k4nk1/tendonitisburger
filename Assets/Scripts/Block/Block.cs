using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    protected Item inventory;
    public virtual Item Put(Item item){
        if(inventory == null){
            inventory = item;
            item.SetParent(this);
            item.transform.localPosition = Vector3.up * 2;
            return null;
        }else if(inventory is Burger){
            ((Burger)inventory).AddIngredient(item);
            return null;
        }else{
            return item;
        }
    }
    public virtual Item Pick(){
        Item t = inventory;
        inventory = null;
        return t;
    }
}
