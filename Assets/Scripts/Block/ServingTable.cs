
using UnityEngine;

public class ServingTable : Block{
    [SerializeField]
    private Set set;
    [SerializeField]
    private OrderManager orderManager;
    public override Item Put(Item item)
    {
        if(set.noItems < 4){
            set.AddItem(item);
            OnItemsChange();
            return null;
        }else{
            return item;
        }
    }

    public override Item Pick()
    {
        if(set.noItems == 0){
            return null;
        }else{
            Item r = set.PopItem();
            OnItemsChange();
            return r;
        }
    }

    private void OnItemsChange(){
        int index = orderManager.orders.FindIndex(order => order.matches(set.ToItemInfo().innerItems));
        if(index == -1) return;
        orderManager.OnOrderMatched(index);
        set.ClearItems();
    }
}