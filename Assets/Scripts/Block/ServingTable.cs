
using UnityEngine;

public class ServingTable : Block{
    [SerializeField]
    private GameObject emptySet;
    public override Item Put(Item item)
    {
        if(inventory == null){
            inventory = Instantiate(emptySet, transform.position + Vector3.up * 2, Quaternion.identity).GetComponent<Item>();
            ((Set)inventory).AddItem(item);
        }else if(((Set)inventory).noItems <= 4){
            ((Set)inventory).AddItem(item);
        }else{
            return item;
        }
        return null;
    }
}