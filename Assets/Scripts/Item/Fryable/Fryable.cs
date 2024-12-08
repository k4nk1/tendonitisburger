using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FryProgress{
    Raw,
    Fried,
    Burned
}

[Serializable]
public class FryableInfo{
    public float min;
    public float max;
    public GameObject rawObject;
    public GameObject friedObject;
    public GameObject burnedObject;
}

public interface IFryable{
    void Fry();
}

public class Fryable : Item, IFryable
{
    [SerializeField]
    protected FryableInfo fryableInfo;
    public FryProgress FryProgress{
        get{
            if(fryProgress < fryableInfo.min) return FryProgress.Raw;
            if(fryProgress < fryableInfo.max) return FryProgress.Fried;
            return FryProgress.Burned;
        }
    }
    private float fryProgress;

    public void Fry(){
        if(FryProgress == FryProgress.Raw && fryProgress + Time.deltaTime > fryableInfo.min){
            ChangeBody(fryableInfo.friedObject);
        }else if(FryProgress == FryProgress.Fried && fryProgress + Time.deltaTime > fryableInfo.max){
            ChangeBody(fryableInfo.burnedObject);
        }
        fryProgress += Time.deltaTime;
        //set progress of progressBar of parent fryProgress
    }

    public override ItemInfo ToItemInfo()
    {
        return base.ToItemInfo().AddInfo(state: FryProgress.ToString());
    }
}
