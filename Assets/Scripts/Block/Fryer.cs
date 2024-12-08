using UnityEngine;

public class Fryer : Block
{
    public override Item Put(Item item)
    {
        if(item is Fryable){
            Item r = base.Put(item);
            inventory.transform.localPosition = Vector3.up * 1.7f;
            return r;
        }
        else return item;
    }

    void Update(){
        if(inventory != null){
            (inventory as Fryable).Fry();
        }
    }
}
