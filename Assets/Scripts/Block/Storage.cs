
using UnityEngine;

public class Storage : Block{
    [SerializeField]
    public Item type;
    public override Item Put(Item item)
    {
        return item;
    }
    public override Item Pick()
    {
        inventory = Instantiate(type.gameObject).GetComponent<Item>();
        return base.Pick();
    }
}