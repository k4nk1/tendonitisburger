public class TrashCan : Block{
    public override Item Pick()
    {
        return null;
    }
    public override Item Put(Item item)
    {
        Destroy(item.gameObject);
        return null;
    }
}