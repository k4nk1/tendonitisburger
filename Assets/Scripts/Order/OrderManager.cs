using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public List<Order> orders;
    [SerializeField]
    private Transform displayParent;
    [SerializeField]
    private TMP_Text servedOrdersText;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject displayPF;
    [SerializeField]
    private float initialOrderInterval;
    [SerializeField]
    private float orderIntervalMultiplier;
    [SerializeField]
    private float initialOrderTimeLimit;
    private int servedOrders = 0;
    private float orderTime = 2;

    void Start(){
        orders = new List<Order>();
    }

    void Update(){
        orderTime -= Time.deltaTime;
        if(orderTime < 0){
            PlaceRandomOrder();
            orderTime = initialOrderInterval * Mathf.Pow(orderIntervalMultiplier, servedOrders);
        }
    }

    private void PlaceRandomOrder(){
        Order order = Instantiate(displayPF, displayParent).GetComponent<Order>();
        order.GameOver = gameManager.GameOver;
        order.Add(Menus.burgers[Random.Range(0, Menus.burgers.Count)]);
        order.Add(Menus.Fries(size: (Size)Random.Range(0, 3)));
        order.Add(Menus.Beverage(beverageType: (BeverageType)Random.Range(1, Beverage.noBeverageType), size: (Size)Random.Range(0, 3)));
        order.SetTimeLimit(initialOrderTimeLimit);
        orders.Add(order);
    }

    public void OnOrderMatched(int index){
        Destroy(orders[index].gameObject);
        orders.RemoveAt(index);
        servedOrders++;
        servedOrdersText.text = servedOrders.ToString();
    }
}