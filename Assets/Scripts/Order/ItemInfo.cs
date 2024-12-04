
using System.Collections.Generic;

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
        if(name != "") this.name = name;
        if(size != null) this.size = size;
        if(type != null) this.type = type;
        if(state != null) this.state = state;
        if(innerItems != null) this.innerItems = innerItems;
        return this;
    }

    public bool matches(ItemInfo another){
        return name == another.name && size == another.size && type == another.type && state == another.state && CompareLists(innerItems, another.innerItems);
    }

    private static bool CompareLists(List<ItemInfo> a, List<ItemInfo> b){
        if(a == null && b == null) return true;
        if(a != null && b != null && a.Count != b.Count) return false;
        for(int i=0; i<a.Count; i++){
            if(!a[i].matches(b[i])) return false;
        }
        return true;
    }
}