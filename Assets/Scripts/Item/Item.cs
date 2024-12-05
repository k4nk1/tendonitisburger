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
    protected Block parent;
    public virtual void SetParent(MonoBehaviour parentObject){
        transform.parent = parentObject.transform;
        parent = parentObject as Block;
    }

    public virtual ItemInfo ToItemInfo()
    {
        return new ItemInfo(name: itemName);
    }

    public void SwitchAppearance(GameObject from, GameObject to){
        from.SetActive(false);
        to.SetActive(true);
    }
}
