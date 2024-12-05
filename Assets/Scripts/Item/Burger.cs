
using System.Collections.Generic;
using UnityEngine;

public class Burger : Bakable{
    List<Item> ingredients;
    [SerializeField]
    private GameObject RawUpperBun;
    [SerializeField]
    private GameObject BakedUpperBun;

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
        (BakeProgress == BakeProgress.Raw ? RawUpperBun : BakedUpperBun).transform.localPosition = Vector3.up * height;
        height += ingredient.height;
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