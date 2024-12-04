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
    public void SetParent(MonoBehaviour parentObject){
        transform.parent = parentObject.transform;
        parent = parentObject as Block;
    }

    public override string ToString()
    {
        return itemName;
    }
}
