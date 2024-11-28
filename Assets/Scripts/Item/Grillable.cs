using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(grillProgress + Time.deltaTime > grillableInfo.min){
            grillableInfo.rawObject.SetActive(false);
            grillableInfo.grilledObject.SetActive(true);
        }else if(grillProgress + Time.deltaTime > grillableInfo.max){
            grillableInfo.rawObject.SetActive(false);
            grillableInfo.grilledObject.SetActive(true);
        }
        grillProgress += Time.deltaTime;
        //set progress of progressBar of parent grillProgress
    }
}
