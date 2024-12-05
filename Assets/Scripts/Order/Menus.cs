
using System.Collections.Generic;

public class Menus
{
    public static ItemInfo patty = new ItemInfo("Patty", state: "Grilled");
    public static ItemInfo bun = new ItemInfo("Burger", state: "Baked");
    public static ItemInfo hamburger = bun.AddInfo(innerItems: new List<ItemInfo>(){patty});
}