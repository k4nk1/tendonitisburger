
using System.Collections.Generic;
using UnityEngine;

public class Burger : Item{
    List<Item> ingredients;
    [SerializeField]
    private GameObject UpperBun;

    void Start(){
        ingredients = new List<Item>();
    }

    public void AddIngredient(Item ingredient){
        ingredients.Add(ingredient);
        ingredient.SetParent(this);
        ingredient.transform.localPosition = Vector3.up * height;
        UpperBun.transform.localPosition = Vector3.up * height;
        height += ingredient.height;
    }
}