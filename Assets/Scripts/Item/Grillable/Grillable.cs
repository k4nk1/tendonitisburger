using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrillProgress{
    Raw,
    Grilled,
    Burned
}

[Serializable]
public class GrillableInfo{
    public float min;
    public float max;
    public GameObject rawObject;
    public GameObject grilledObject;
    public GameObject burnedObject;
}

public interface IGrillable{
    void Grill();
}

public class Grillable : Item, IGrillable
{
    [SerializeField]
    private GrillableInfo grillableInfo;
    public GrillProgress GrillProgress{
        get{
            if(grillProgress < grillableInfo.min) return GrillProgress.Raw;
            if(grillProgress < grillableInfo.max) return GrillProgress.Grilled;
            return GrillProgress.Burned;
        }
    }
    private float grillProgress;

    public void Grill(){
        if(GrillProgress == GrillProgress.Raw && grillProgress + Time.deltaTime > grillableInfo.min){
            SwitchAppearance(grillableInfo.rawObject, grillableInfo.grilledObject);
        }else if(GrillProgress == GrillProgress.Grilled && grillProgress + Time.deltaTime > grillableInfo.max){
            SwitchAppearance(grillableInfo.grilledObject, grillableInfo.burnedObject);
        }
        grillProgress += Time.deltaTime;
        //set progress of progressBar of parent grillProgress
    }

    public override ItemInfo ToItemInfo()
    {
        return base.ToItemInfo().AddInfo(state: GrillProgress.ToString());
    }
}
