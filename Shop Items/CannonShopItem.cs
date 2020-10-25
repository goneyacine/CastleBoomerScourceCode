using UnityEngine;
using System.Collections;
[CreateAssetMenu (fileName = "New Cannon Shop Item",menuName = "Shop Item / Cannon Item")]
public class CannonShopItem : ShopItem
{
    public CannonShopItem()
    {
        tag = "Cannon";
    }
}
