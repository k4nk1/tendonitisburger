using System.Collections.Generic;
using UnityEngine;

public enum DrinkType{
    Empty
}

public enum PourProgress{
    Empty,
    Middle,
    Full
}

public class Drink : Item{
    [SerializeField]
    private Size size;
    [SerializeField]
    private GameObject surface;
    private DrinkType type = DrinkType.Empty;
    private static Dictionary<Size, float> pouringDurations = new Dictionary<Size, float>{{Size.S, 4}, {Size.M, 6}, {Size.L, 8}};
    private PourProgress PourProgress{ 
        get{
            if(pourProgress == 0) return PourProgress.Empty;
            if(pourProgress < pouringDurations[size]) return PourProgress.Middle;
            return PourProgress.Full;
        }
    }
    private float pourProgress;

    public bool Pour(DrinkType pourType){
        if(type == DrinkType.Empty) type = pourType; 
        if(type != pourType || PourProgress == PourProgress.Full) return false;
        pourProgress += Time.deltaTime;
        surface.transform.localPosition = Vector3.up * height * pourProgress / pouringDurations[size];
        return true;
    }
}