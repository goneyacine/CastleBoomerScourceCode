using UnityEngine;
public class ShopItem : ScriptableObject
{
    //the total price of the item
    public int price;
    //the name of the item
    public new string name;
    //the item icon on the shop-
    public Sprite icon;
    //the tag of the shop item (like : bullet , cannonn base ...)
    public string tag;
}
