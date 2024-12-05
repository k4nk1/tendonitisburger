using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> orders;

    void Start(){
        orders = new List<Order>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Order order = new Order();
            if(Input.GetKey(KeyCode.B)) order.items.Add(new ItemInfo(name: "Burger", state: "Baked"));
            orders.Add(order);
            LogOrders();
        }
    }

    public void OnOrderMatched(int index){
        orders.RemoveAt(index);
        LogOrders();
    }

    private void LogOrders(){
        string r = "";
        foreach(Order order in orders){
            r += string.Join(", ", order.items) + "  |||  ";
        }
        Debug.Log(r);
    }
}