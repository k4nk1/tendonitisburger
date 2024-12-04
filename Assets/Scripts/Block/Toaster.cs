
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
            if(i==0 && burgers[0].transform.position.z < 1 || (burgers[i-1].transform.position - burgers[i].transform.position).z < 0.5f){
                burgers[i].transform.position += Vector3.forward * Time.deltaTime;
            }
        }
    }

    private bool CanPut(){ return burgers.Count == 0 || burgers[burgers.Count-1].transform.localPosition.z > 0.75f; }
    private bool CanPick() { return burgers.Count > 0 && burgers[0].transform.position.z > 1; }

    public override Item Put(Item item)
    {
        if(item is Burger && CanPut()){
            item.SetParent(this);
            burgers.Add((Burger)item);
            item.transform.localPosition = Vector3.up * 2;
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
            return item;
        }
        return null;
    }
}