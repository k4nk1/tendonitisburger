
using UnityEngine;

public class Fries : Fryable{
    [SerializeField]
    public GameObject packedObject;

    public override void SetParent(MonoBehaviour parentObject)
    {
        base.SetParent(parentObject);
        if(transform.parent.tag == "Player" && FryProgress == FryProgress.Fried){
            SwitchAppearance(fryableInfo.friedObject, packedObject);
        }
    }
}