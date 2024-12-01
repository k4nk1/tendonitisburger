
using UnityEngine;

public class Storage : Block{
    [SerializeField]
    private GameObject type;
    public override Item Put(Item item)
    {
        return item;
    }
    public override Item Pick()
    {
        inventory = Instantiate(type).GetComponent<Item>();
        return base.Pick();
    }
}