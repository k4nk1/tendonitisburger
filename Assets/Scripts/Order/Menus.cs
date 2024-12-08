
using System.Collections.Generic;

public class Menus
{
    public static readonly ItemInfo patty = new ItemInfo("Patty", state: "Grilled");
    public static readonly ItemInfo cheese = new ItemInfo("Cheese");
    public static readonly ItemInfo bun = new ItemInfo("Burger", state: "Baked");
    public static readonly ItemInfo hamburger = new ItemInfo("Burger", state: "Baked", innerItems: new List<ItemInfo>(){patty});
    public static readonly ItemInfo cheeseBurger = new ItemInfo("Burger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese});
    public static readonly ItemInfo doubleCheeseBurger = new ItemInfo("Burger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese, patty, cheese});
    public static readonly ItemInfo fries = new ItemInfo("Fries", state: "Fried");
    public static readonly ItemInfo cola = new ItemInfo("Beverage", size: Size.S, type: "Cola");
}