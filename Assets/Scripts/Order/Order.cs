
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public List<ItemInfo> items;
    public float time;
    public delegate void dlgt();
    public dlgt GameOver;
    [SerializeField]
    private Slider timer;
    [SerializeField]
    private Image timerImage;

    void Awake(){
        items = new List<ItemInfo>();
    }

    void Update(){
        if(time > 20 && time - Time.deltaTime < 20) timerImage.color = Color.yellow;
        if(time > 10 && time - Time.deltaTime < 10) timerImage.color = Color.red;
        if(time < 0) GameOver();
        time -= Time.deltaTime;
        timer.value = time;
    }

    public void Add(ItemInfo item){
        items.Add(item);
        transform.Find("ItemText").GetComponent<TMP_Text>().text += item.productName + "\n";
    }

    public void SetTimeLimit(float timeLimit){
        time = timeLimit;
        timer.maxValue  = timeLimit;
    }

    public bool matches(List<ItemInfo> anotherItems){
        if(items.Count != anotherItems.Count) return false;
        foreach(ItemInfo item in items){
            if(anotherItems.FindIndex(anotheritem => anotheritem.matches(item)) == -1) return false;
        }
        return true;
    }
}