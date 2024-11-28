using UnityEngine;

public enum GrillProgress{
    Raw,
    Grilled,
    Burned
}

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