
public class Set : Item{
    public int noItems;
    public void AddItem(Item item){

    }

    public override string ToString()
    {
        if(noItems == 0) return "Empty";
        return string.Join(", ", items);
    }
}