
using UnityEngine;

public class BeverageDispenser : Block{
    [SerializeField]
    private BeverageType beverageType;

    void Update(){
        if(inventory != null) ((Beverage)inventory).Pour(beverageType);
    }

    public override Item Put(Item item)
    {
        return item is Beverage ? base.Put(item) : item;
    }
}