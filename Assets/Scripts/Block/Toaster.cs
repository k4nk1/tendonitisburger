
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toaster : Block
{
    private List<Burger> burgers;

    void Start(){
        burgers = new List<Burger>();
    }

    void Update(){
        for(int i=0; i<burgers.Count; i++){
            if(i==0){
                if(burgers[0].transform.localPosition.z < 2.5f) burgers[0].transform.localPosition += Vector3.forward * Time.deltaTime;
            }else{
                if((burgers[i-1].transform.localPosition - burgers[i].transform.localPosition).z < 0.5f) burgers[i].transform.localPosition += Vector3.forward * Time.deltaTime;
            }
        }
    }

    private bool CanPut(){ return burgers.Count == 0 || burgers[burgers.Count-1].transform.localPosition.z > 0.75f; }
    private bool CanPick() { return burgers.Count > 0 && burgers[0].transform.localPosition.z > 1.75f; }

    public override Item Put(Item item)
    {
        if(item is Burger && CanPut()){
            item.SetParent(this);
            burgers.Add((Burger)item);
            item.transform.localPosition = new Vector3(0, 2f, -0.5f);
            item.transform.localScale = Vector3.one * 0.5f;
            return null;
        }
        return item;
    }

    public override Item Pick()
    {
        if(CanPick()){
            Item item = (Item)burgers[0];
            burgers.RemoveAt(0);
            item.transform.localScale = Vector3.one * 0.8f;
            return item;
        }
        return null;
    }
}