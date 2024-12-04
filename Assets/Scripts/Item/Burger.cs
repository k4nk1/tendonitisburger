
using System.Collections.Generic;
using UnityEngine;

public class Burger : Bakable{
    List<Item> ingredients;
    [SerializeField]
    private GameObject UpperBun;

    void Start(){
        ingredients = new List<Item>();
    }

    public override void Bake()
    {
        base.Bake();
    }

    public void AddIngredient(Item ingredient){
        ingredients.Add(ingredient);
        ingredient.SetParent(this);
        ingredient.transform.localPosition = Vector3.up * height;
        UpperBun.transform.localPosition = Vector3.up * height;
        height += ingredient.height;
    }

    public override ItemInfo ToItemInfo()
    {
        List<ItemInfo> itemInfos = new List<ItemInfo>();
        foreach(Item item in ingredients){
            itemInfos.Add(item.ToItemInfo());
        }
        return base.ToItemInfo().AddInfo(innerItems: itemInfos);
    }
}