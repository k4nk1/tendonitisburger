using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Item inventory;
    void Update(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f)){
            transform.position = hit.point;
            if(Input.GetMouseButtonDown(0)){
                Block block = hit.collider.GetComponent<Block>();
                if(block == null) return;
                if(inventory == null){
                    inventory = block.Pick();
                    if(inventory == null) return;
                    inventory.SetParent(this);
                    inventory.transform.localPosition = Vector3.zero;
                }else{
                    inventory = block.Put(inventory);
                }
            }
        }
    }
}
