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
            grillableInfo.rawObject.SetActive(false);
            grillableInfo.grilledObject.SetActive(true);
        }else if(GrillProgress == GrillProgress.Grilled && grillProgress + Time.deltaTime > grillableInfo.max){
            grillableInfo.grilledObject.SetActive(false);
            grillableInfo.burnedObject.SetActive(true);
        }
        grillProgress += Time.deltaTime;
        //set progress of progressBar of parent grillProgress
    }
}
