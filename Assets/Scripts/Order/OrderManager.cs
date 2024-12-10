using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> orders;
    [SerializeField]
    private OrderDisplay orderDisplay;
    [SerializeField]
    private float orderInterval;
    private float orderTime = 2;

    void Start(){
        orders = new List<Order>();
    }

    void Update(){
        orderTime -= Time.deltaTime;
        if(orderTime < 0){
            AddOrder(RandomOrder());
            orderTime = orderInterval;
        }
    }

    private Order RandomOrder(){
        Order order = new Order();
        order.items.Add(Menus.burgers[Random.Range(0, Menus.burgers.Count)]);
        order.items.Add(Menus.Fries(size: (Size)Random.Range(0, 3)));
        order.items.Add(Menus.Beverage(beverageType: (BeverageType)Random.Range(1, Beverage.noBeverageType), size: (Size)Random.Range(0, 3)));
        return order;
    }

    void AddOrder(Order order){
        orders.Add(order);
        orderDisplay.Add(order);
    }

    public void OnOrderMatched(int index){
        orders.RemoveAt(index);
        orderDisplay.RemoveAt(index);
    }
}