
using System.Collections.Generic;

public class Menus
{
    public static readonly ItemInfo patty = new ItemInfo("Patty", state: "Grilled");
    public static readonly ItemInfo cheese = new ItemInfo("Cheese");
    public static readonly ItemInfo bun = new ItemInfo("Burger", state: "Baked");
    public static readonly ItemInfo hamburger = new ItemInfo("Burger", productName: "Hamburger", state: "Baked", innerItems: new List<ItemInfo>(){patty});
    public static readonly ItemInfo cheeseBurger = new ItemInfo("Burger", productName: "CheeseBurger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese});
    public static readonly ItemInfo doubleCheeseBurger = new ItemInfo("Burger", productName: "Double CheeseBurger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese, patty, cheese});

    public static ItemInfo Fries(Size size){
        return new ItemInfo("Fries", productName: $"Fries {size.ToString()}", size: size, state: "Fried");
    }

    public static ItemInfo Beverage(BeverageType beverageType, Size size){
        return new ItemInfo("Beverage", productName: $"{beverageType.ToString()} {size.ToString()}", size: size, type: beverageType.ToString(), state: "Full");
    }
}