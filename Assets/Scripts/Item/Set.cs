using System.Collections.Generic;
using UnityEngine;

public class Set : Item{
    public List<Item> items;
    public int noItems { get{ return items.Count; } }
    public void AddItem(Item item){
        item.SetParent(this);
        items.Add(item);
        item.transform.localScale = Vector3.one * 0.4f;
        SortItems();
    }

    public Item PopItem(){
        Item item = items[items.Count-1];
        item.transform.localScale = Vector3.one * 0.8f;
        items.Remove(item);
        SortItems();
        return item;
    }

    private void SortItems(){
        switch(noItems){
            case 1:
                items[0].transform.localPosition = Vector3.zero;
                break;
            case 2:
                items[0].transform.localPosition = Vector3.left * 0.5f;
                items[1].transform.localPosition = Vector3.right * 0.5f;
                break;
            case 3:
                items[0].transform.localPosition = new Vector3(-0.5f, 0, 0.5f);
                items[1].transform.localPosition = new Vector3(0.5f, 0, 0.5f);
                items[2].transform.localPosition = Vector3.back * 0.5f;
                break;
            case 4:
                items[0].transform.localPosition = new Vector3(-0.5f, 0, 0.5f);
                items[1].transform.localPosition = new Vector3(0.5f, 0, 0.5f);
                items[2].transform.localPosition = new Vector3(-0.5f, 0, -0.5f);
                items[3].transform.localPosition = new Vector3(0.5f, 0, -0.5f);
                break;
        }
    }

    public override string ToString()
    {
        if(noItems == 0) return "Empty";
        return string.Join(", ", items);
    }
}