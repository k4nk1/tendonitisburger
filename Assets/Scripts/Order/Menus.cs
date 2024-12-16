
using System.Collections.Generic;
using UnityEditor;

public class Menus
{
    public static readonly ItemInfo patty = new ItemInfo("Patty", state: "Grilled");
    public static readonly ItemInfo thickPatty = new ItemInfo("ThickPatty", state: "Grilled");
    public static readonly ItemInfo cheese = new ItemInfo("Cheese");
    public static readonly ItemInfo tomato = new ItemInfo("Tomato");
    public static readonly ItemInfo lettuce = new ItemInfo("Lettuce");
    public static readonly ItemInfo bun = new ItemInfo("Burger", state: "Baked");
    public static readonly ItemInfo hamburger = new ItemInfo("Burger", productName: "Hamburger", state: "Baked", innerItems: new List<ItemInfo>(){patty});
    public static readonly ItemInfo cheeseburger = new ItemInfo("Burger", productName: "Cheeseburger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese});
    public static readonly ItemInfo doubleCheeseburger = new ItemInfo("Burger", productName: "Double Cheeseburger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese, patty, cheese});
    public static readonly ItemInfo tripleCheeseburger = new ItemInfo("Burger", productName: "Triple Cheeseburger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese, patty, cheese, patty, cheese});
    public static readonly ItemInfo richBurger = new ItemInfo("Burger", productName: "Rich Burger", state: "Baked", innerItems: new List<ItemInfo>(){patty, tomato, lettuce});
    public static readonly ItemInfo cheeseRichBurger = new ItemInfo("Burger", productName: "Rich Cheeseburger", state: "Baked", innerItems: new List<ItemInfo>(){patty, cheese, tomato, lettuce});
    public static readonly ItemInfo thickHamburger = new ItemInfo("Burger", productName: "Thick Hamhurger", state: "Baked", innerItems: new List<ItemInfo>(){thickPatty});
    public static readonly ItemInfo thickCheeseBurger = new ItemInfo("Burger", productName: "Thick Cheese Burger", state: "Baked", innerItems: new List<ItemInfo>(){thickPatty, cheese});

    public static ItemInfo Fries(Size size){
        return new ItemInfo("Fries", productName: $"Fries {size.ToString()}", size: size, state: "Fried");
    }

    public static ItemInfo Beverage(BeverageType beverageType, Size size){
        return new ItemInfo("Beverage", productName: $"{beverageType.ToString()} {size.ToString()}", size: size, type: beverageType.ToString(), state: "Full");
    }

    public static List<ItemInfo> burgers = new List<ItemInfo>(){hamburger, cheeseburger, doubleCheeseburger, tripleCheeseburger, richBurger, cheeseRichBurger, thickHamburger, thickCheeseBurger};
}