
using System.Collections.Generic;
using UnityEngine;

public class Burger : Bakable{
    List<Item> ingredients;
    [SerializeField]
    private GameObject BunUpper;

    void Start(){
        ingredients = new List<Item>();
    }

    public override void Bake()
    {
        base.Bake();
        BunUpper = body.transform.Find("BunUpper").gameObject;
    }

    public void AddIngredient(Item ingredient){
        ingredients.Add(ingredient);
        ingredient.SetParent(this);
        ingredient.transform.localPosition = Vector3.up * height;
        height += ingredient.height;
        BunUpper.transform.localPosition = Vector3.up * height;
    }

    public override ItemInfo ToItemInfo()
    {
        if(ingredients.Count == 0) return base.ToItemInfo();
        List<ItemInfo> itemInfos = new List<ItemInfo>();
        foreach(Item item in ingredients){
            itemInfos.Add(item.ToItemInfo());
        }
        return base.ToItemInfo().AddInfo(innerItems: itemInfos);
    }
}