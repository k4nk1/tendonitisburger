
using UnityEngine;

public class ServingTable : Block{
    [SerializeField]
    private Set set;
    public override Item Put(Item item)
    {
        if(set.noItems < 4){
            set.AddItem(item);
            return null;
        }else{
            return item;
        }
    }

    public override Item Pick()
    {
        if(set.noItems == 0){
            return null;
        }else{
            return set.PopItem();
        }
    }
}