using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject orderPF;

    public void Add(Order order){
        GameObject orderObject = Instantiate(orderPF, transform);
        orderObject.transform.SetAsFirstSibling();
        orderObject.transform.GetChild(0).GetComponent<TMP_Text>().text = GetDisplayString(order);
    }

    public void RemoveAt(int i){
        Destroy(transform.GetChild(i).gameObject);
    }

    public static string GetDisplayString(Order order){
        string r = "";
        foreach(ItemInfo info in order.items){
            r += info.productName + "\n";
        }
        return r;
    }
}