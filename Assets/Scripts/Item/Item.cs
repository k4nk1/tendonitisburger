using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int maxStack;
    public float height;
    protected Block parent;
    public void SetParent(MonoBehaviour parentObject){
        transform.parent = parentObject.transform;
        parent = parentObject as Block;
    }
}
