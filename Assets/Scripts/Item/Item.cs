using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Size{
    S, M, L
}

public class Item : MonoBehaviour
{
    public string itemName;
    public int maxStack;
    public float height;
    protected GameObject body;
    protected Block parent;

    void Start(){
        body = transform.Find("Body").gameObject;
    }

    public virtual void SetParent(MonoBehaviour parentObject){
        transform.parent = parentObject.transform;
        parent = parentObject as Block;
    }

    public virtual ItemInfo ToItemInfo()
    {
        return new ItemInfo(name: itemName);
    }

    public void ChangeBody(GameObject newBody){
        Destroy(body);
        body = Instantiate(newBody, this.transform);
        body.name = "Body";
    }
}
