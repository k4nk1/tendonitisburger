
using Unity.VisualScripting;
using UnityEngine;

public class Fries : Fryable{
    [SerializeField]
    public SerializedDictionary<Size, FryableInfo> fryableInfos;
    [SerializeField]
    public SerializedDictionary<Size, GameObject> packedObjects;
    [SerializeField]
    public Size size;

    public override void SetParent(MonoBehaviour parentObject)
    {
        base.SetParent(parentObject);
        if(transform.parent.tag == "Player" && FryProgress == FryProgress.Fried){
            ChangeBody(packedObjects[size]);
        }
    }

    public void ChangeSize(Size new_size){
        size = new_size;
        fryableInfo = fryableInfos[size];
    }

    public override ItemInfo ToItemInfo()
    {
        return base.ToItemInfo().AddInfo(size: size);
    }
}