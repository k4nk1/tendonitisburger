using System.Collections.Generic;
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
            if(Input.GetKey(KeyCode.B)) order.items.Add(Menus.bun);
            if(Input.GetKey(KeyCode.H)) order.items.Add(Menus.hamburger);
            if(Input.GetKey(KeyCode.C)) order.items.Add(Menus.cheeseBurger);
            if(Input.GetKey(KeyCode.D)) order.items.Add(Menus.doubleCheeseBurger);
            if(Input.GetKey(KeyCode.F)) order.items.Add(Menus.fries);
            if(Input.GetKey(KeyCode.L)) order.items.Add(Menus.cola);
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