
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toaster : Block
{
    private List<Bakable> items;

    void Start(){
        items = new List<Bakable>();
    }

    void Update(){
        for(int i=0; i<items.Count; i++){
            if(i==0){
                if(items[0].transform.localPosition.z < 2.5f) items[0].transform.localPosition += Vector3.forward * Time.deltaTime;
            }else{
                if((items[i-1].transform.localPosition - items[i].transform.localPosition).z < 0.5f) items[i].transform.localPosition += Vector3.forward * Time.deltaTime;
            }
            if(items[i].BakeProgress == BakeProgress.Raw && items[i].transform.localPosition.z > 1f) items[i].Bake();
        }
    }

    private bool CanPut(){ return items.Count == 0 || items[items.Count-1].transform.localPosition.z > 0.75f; }
    private bool CanPick() { return items.Count > 0 && items[0].transform.localPosition.z > 2.5f; }

    public override Item Put(Item item)
    {
        if(item is Bakable && CanPut()){
            if(((Bakable)item).BakeProgress == BakeProgress.Baked) return item;
            item.SetParent(this);
            items.Add((Bakable)item);
            item.transform.localPosition = new Vector3(0, 2f, -0.5f);
            item.transform.localScale = Vector3.one * 0.5f;
            return null;
        }
        return item;
    }

    public override Item Pick()
    {
        if(CanPick()){
            Item item = (Item)items[0];
            items.RemoveAt(0);
            item.transform.localScale = Vector3.one * 0.8f;
            return item;
        }
        return null;
    }
}