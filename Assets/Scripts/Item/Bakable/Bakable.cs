using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum BakeProgress{
    Raw,
    Baked
}

[Serializable]
public class BakableInfo{
    public GameObject rawObject;
    public GameObject bakedObject;
}

public interface IBakable{
    void Bake();
}

public class Bakable : Item, IBakable
{
    [SerializeField]
    private BakableInfo bakableInfo;
    public BakeProgress BakeProgress = BakeProgress.Raw;

    public virtual void Bake(){
        BakeProgress = BakeProgress.Baked;
        SwitchAppearance(bakableInfo.rawObject, bakableInfo.bakedObject);
    }

    public override ItemInfo ToItemInfo()
    {
        return base.ToItemInfo().AddInfo(state: BakeProgress.ToString());
    }
}
