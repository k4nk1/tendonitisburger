
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public string name;
    public Size? size;
    public string type;
    public string state;
    public List<ItemInfo> innerItems;

    public ItemInfo(string name=null, Size? size=null, string type=null, string state=null, List<ItemInfo> innerItems=null){
        AddInfo(name: name, size: size, type: type, state: state, innerItems: innerItems);
    }

    public ItemInfo AddInfo(string name=null, Size? size=null, string type=null, string state=null, List<ItemInfo> innerItems=null){
        if(name != null) this.name = name;
        if(size != null) this.size = size;
        if(type != null) this.type = type;
        if(state != null) this.state = state;
        if(innerItems == null) this.innerItems = new List<ItemInfo>();
        else this.innerItems = innerItems;
        return this;
    }

    public bool matches(ItemInfo another){
        Debug.Log($"{name}, {size}, {type}, {state}, {string.Join(", ", innerItems)}");
        Debug.Log($"{another.name}, {another.size}, {another.type}, {another.state}, {string.Join(", ", another.innerItems)}");
        return name == another.name && size == another.size && type == another.type && state == another.state && CompareLists(innerItems, another.innerItems);
    }

    private static bool CompareLists(List<ItemInfo> a, List<ItemInfo> b){
        if(a.Count != b.Count) return false;
        for(int i=0; i<a.Count; i++){
            if(!a[i].matches(b[i])) return false;
        }
        return true;
    }

    public override string ToString()
    {
        string r = name;
        if(size != null) r += $"<{size}>";
        if(type != null) r += $"({type})";
        if(state != null) r += $"{{{state}}}";
        if(innerItems.Count != 0) r += $"[{string.Join(", ", innerItems)}]";
        return r;
    }

    public ItemInfo DeepCopy(){
        return new ItemInfo(name: name, size: size, type: type, state: state, innerItems: innerItems == null ? null : new List<ItemInfo>(innerItems));
    }
}