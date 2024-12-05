using UnityEngine;

public class Fryer : Block
{
    public override Item Put(Item item)
    {
        if(item is Fryable){
            base.Put(item);
            inventory.transform.localPosition = Vector3.up * 1.7f;
            return null;
        }
        else return item;
    }

    void Update(){
        if(inventory != null){
            (inventory as Fryable).Fry();
        }
    }
}
