using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using TMPro;
public class ShopUIManager : MonoBehaviour
{
    public ShopItemUI shopItemUI_A;
    public ShopItemUI shopItemUI_B;
    public ShopItemUI shopItemUI_C;
    public List<ShopItem> shopItems;
    public int currentShopItemIndex = 0;

    private void Update()
    {
        //check when we should disable or enable "shopItemUI_A" parent object
        if (currentShopItemIndex <= 0)
            shopItemUI_A.parent.SetActive(false);
        else
            shopItemUI_A.parent.SetActive(true);
        //check when we should disable or enable "shopItemUI_B" parent object
        if (currentShopItemIndex >= shopItems.Count - 1)
            shopItemUI_C.parent.SetActive(false);
        else
            shopItemUI_C.parent.SetActive(true);

        //now we'are trying to update the shop item ui things (images ,texts ...)
        //update the first shop item ui elements
        try
        {
            ShopItem shopItem = shopItems[currentShopItemIndex - 1];
            shopItemUI_A.icon.sprite = shopItem.icon;
            shopItemUI_A.name.text = shopItem.name;
            shopItemUI_A.price.text = shopItem.price.ToString() + "$";
            shopItemUI_A.shopItem = shopItem;
            bool isOpened = true;
            try
            {
                DataSerialization.GetObject(shopItem.name);
            }
            catch (Exception e)
            {
                isOpened = false;
            }

            if (DataSerialization.GetObject(shopItem.name) == null)
                isOpened = false;
            if (isOpened)
            {
                shopItemUI_A.selectButton.gameObject.SetActive(true);
                shopItemUI_A.buyButton.gameObject.SetActive(false);
            }
            else
            {
                shopItemUI_A.buyButton.gameObject.SetActive(true);
                shopItemUI_A.selectButton.gameObject.SetActive(false);
            }
        }
        catch (Exception e) { /* do nothing when find an excption */ }

        //update the second shop item ui elements
        try
        {
            ShopItem shopItem = shopItems[currentShopItemIndex];
            shopItemUI_B.icon.sprite = shopItem.icon;
            shopItemUI_B.name.text = shopItem.name;
            shopItemUI_B.price.text = shopItem.price.ToString() + "$";
            shopItemUI_B.shopItem = shopItem;
            bool isOpened = true;
            try
            {
                if (shopItem.tag != "Bullet")
                {
                    DataSerialization.GetObject(shopItem.name);
                }
                else
                {
                    isOpened = false;
                    foreach (BulletData bd in DataSerialization.GetObject("openedBullets") as List<BulletData>)
                    {
                        if (bd.name == shopItem.name)
                        {
                            isOpened = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                isOpened = false;
            }
            if (DataSerialization.GetObject(shopItem.name) == null && shopItem.tag != "Bullet")
                isOpened = false;
            if (isOpened)
            {
                shopItemUI_B.selectButton.gameObject.SetActive(true);
                shopItemUI_B.buyButton.gameObject.SetActive(false);
            }
            else
            {
                shopItemUI_B.buyButton.gameObject.SetActive(true);
                shopItemUI_B.selectButton.gameObject.SetActive(false);
            }

        }
        catch (Exception e) { /* do nothing when find an excption */ }
        //update the third shop item ui elements
        try
        {
            ShopItem shopItem = shopItems[currentShopItemIndex + 1];
            shopItemUI_C.icon.sprite = shopItem.icon;
            shopItemUI_C.name.text = shopItem.name;
            shopItemUI_C.price.text = shopItem.price.ToString() + "$";
            shopItemUI_C.shopItem = shopItem;
            bool isOpened = true;
            try
            {
                DataSerialization.GetObject(shopItem.name);
            }catch (Exception e)
            {
                isOpened = false;
            }
            if (DataSerialization.GetObject(shopItem.name) == null)
                isOpened = false;
            if (isOpened)
            {
                shopItemUI_C.selectButton.gameObject.SetActive(true);
                shopItemUI_C.buyButton.gameObject.SetActive(false);
            }
            else
            {
                shopItemUI_C.buyButton.gameObject.SetActive(true);
                shopItemUI_C.selectButton.gameObject.SetActive(false);
            }
        }
        catch (Exception e) { /* do nothing when find an excption */ }


    }

    public void ChangeCurrentShopItemIndex(int changingValue)
    {
        currentShopItemIndex += changingValue;
        if (currentShopItemIndex <= 0)
            currentShopItemIndex = shopItems.Count - 1;
        else if (currentShopItemIndex >= shopItems.Count - 1)
            currentShopItemIndex = 0;
    }
    public void Buy(int targetItem)
    {
        int currentMoney = (int)DataSerialization.GetObject("money");
        ShopItemUI targetItemUI = null;
        if (targetItem == 1)
            targetItemUI = shopItemUI_A;
        else if (targetItem == 2)
            targetItemUI = shopItemUI_B;
        else
            targetItemUI = shopItemUI_C;
        if(targetItemUI.shopItem.price > currentMoney)
        {
            ColorBlock cb = targetItemUI.buyButton.colors;
            Color color = cb.normalColor;
            cb.normalColor = Color.red;
            targetItemUI.buyButton.colors = cb;
            System.Threading.Thread.Sleep(2000);
            cb.normalColor = color;
            targetItemUI.buyButton.colors = cb;

        }
        else
        {
            //i realy love my game even if it's stupid
            if (targetItemUI.shopItem.tag == "Bullet")
            {
                List<BulletData> bulletsData = new List<BulletData>();
                
                if (DataSerialization.GetObject("openedBullets") != null)
                {
                    bulletsData = DataSerialization.GetObject("openedBullets") as List<BulletData>;
                }
                BulletData targetBulletData = null;
                foreach (BulletData bd in bulletsData)
                {
                    if (bd.name == targetItemUI.shopItem.name)
                    {
                        targetBulletData = bd;
                        bd.number++;
                        break;
                    }
                }
                if(targetBulletData == null)
                {
                    targetBulletData = new BulletData(targetItemUI.shopItem.name,1);
                    bulletsData.Add(targetBulletData);
                    
                }
                DataSerialization.SaveData(bulletsData, "openedBullets");
            }
            else 
            {
                DataSerialization.SaveData("AAA", targetItemUI.shopItem.name);
            }
        }


    }
}
[System.Serializable]
public class ShopItemUI
{
    public ShopItem shopItem;
    public GameObject parent;
    public Image icon;
    public TMP_Text name;
    public Text price;
    public Button buyButton;
    public Button selectButton;
}
