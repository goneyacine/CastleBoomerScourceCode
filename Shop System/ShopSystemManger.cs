using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShopSystemManger : MonoBehaviour
{
    private ShopUIManager shopUIManager;
    public List<ShopItem> bulletsShopItems;
    public List<ShopItem> cannonShopItems;
    private List<List<ShopItem>> shopItemsListsList = new List<List<ShopItem>>();
    public int shopItemsListIndex = 0;

    private void Start()
    {
        shopUIManager = gameObject.GetComponent<ShopUIManager>();
        shopItemsListsList.Add(bulletsShopItems);
        shopItemsListsList.Add(cannonShopItems);
    }

    private void Update()
    {
        shopUIManager.shopItems = shopItemsListsList[shopItemsListIndex];
    }
    public void setShopItemsListIndex(int value)
    {
        shopItemsListIndex = value;
        if (shopItemsListIndex < 0)
            shopItemsListIndex = 0;
        else if (shopItemsListIndex >= shopItemsListsList.Count)
            shopItemsListIndex = shopItemsListsList.Count - 1;
    }
    public void ChangeCurrentShopItemsList(int index) { shopItemsListIndex = index; }
}
