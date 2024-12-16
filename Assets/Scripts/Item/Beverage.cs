using System.Collections.Generic;
using UnityEngine;

public enum BeverageType{
    Empty, Cola, Orange, Coffee
}

public enum PourProgress{
    Empty,
    Middle,
    Full
}

public class Beverage : Item{
    [SerializeField]
    private Size size;
    [SerializeField]
    private GameObject surface;
    private BeverageType type = BeverageType.Empty;
    private static Dictionary<Size, float> pouringDurations = new Dictionary<Size, float>{{Size.S, 2}, {Size.M, 3}, {Size.L, 4}};
    [SerializeField]
    private SerializedDictionary<BeverageType, Material> beverageMaterials;
    public static int noBeverageType = System.Enum.GetNames(typeof(BeverageType)).Length;
    private PourProgress PourProgress{ 
        get{
            if(pourProgress == 0) return PourProgress.Empty;
            if(pourProgress < pouringDurations[size]) return PourProgress.Middle;
            return PourProgress.Full;
        }
    }
    private float pourProgress;

    public bool Pour(BeverageType pourType){
        if(type == BeverageType.Empty){
            type = pourType;
            surface.GetComponent<MeshRenderer>().material = beverageMaterials[pourType];
        }
        if(type != pourType || PourProgress == PourProgress.Full) return false;
        pourProgress += Time.deltaTime;
        surface.transform.localPosition = Vector3.up * height * pourProgress / pouringDurations[size]; //0.54->0.66
        surface.transform.localScale = Vector3.one * 1.2f * pourProgress / pouringDurations[size];
        return true;
    }

    public override ItemInfo ToItemInfo()
    {
        return base.ToItemInfo().AddInfo(size: size, type: type.ToString(), state: PourProgress.ToString());
    }
}