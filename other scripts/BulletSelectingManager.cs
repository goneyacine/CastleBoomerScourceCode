using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class BulletSelectingManager : MonoBehaviour
{
    public int centerItemIndex;
    private List<BulletData> openedBulletsData;
    public List<BulletSelectingUI_Item> bulletSelectingUI_Items;
    public List<Bullet> all_bullets;
    private List<Bullet> openedBullets;
    private List<BulletData> selectedBulletsData = new List<BulletData>();
    private Cannon cannon;
    public TMP_Text freeSpaceText;
    private int freeSpace;
    private int maxSpace;
    private void Start()
    {
        try
        {
            selectedBulletsData = DataSerialization.GetObject("SelectedBullets") as List<BulletData>;
        }
        catch (Exception e) { }
        UpdateOpenedBulletsList();
        UpdateUI();
        if (selectedBulletsData == null)
            selectedBulletsData = new List<BulletData>();
        UpdateFreeSpaceValue();
    }
    private void OnEnable()
    {
        UpdateFreeSpaceValue();
    }
    public void UpdateUI()
    {
        freeSpaceText.text = "Free Space : " + freeSpace.ToString();
        if (centerItemIndex == 0)
            bulletSelectingUI_Items[0].parent.SetActive(false);
        else
        {
            bulletSelectingUI_Items[0].bullet = openedBullets[centerItemIndex - 1];
            bulletSelectingUI_Items[0].parent.SetActive(true);
            bulletSelectingUI_Items[0].name.text = openedBullets[centerItemIndex - 1].name;
            bulletSelectingUI_Items[0].icon.sprite = openedBullets[centerItemIndex - 1].icon;
            if (selectedBulletsData.Count == 0)
                bulletSelectingUI_Items[0].number.text = "0";
            else
            {
                BulletData target = null;
                foreach (BulletData bd in selectedBulletsData)
                {
                    if (bd.name == openedBullets[centerItemIndex - 1].name)
                    {
                        target = bd;
                        break;
                    }
                }
                if (target == null)
                    bulletSelectingUI_Items[0].number.text = "0";
                else
                    bulletSelectingUI_Items[0].number.text = target.number.ToString();
            }
        }
        if (centerItemIndex == openedBullets.Count - 1 || centerItemIndex == 0)
            bulletSelectingUI_Items[2].parent.SetActive(false);
        else
        {
            bulletSelectingUI_Items[2].parent.SetActive(true);
            bulletSelectingUI_Items[2].bullet = openedBullets[centerItemIndex + 1];
            bulletSelectingUI_Items[2].name.text = openedBullets[centerItemIndex + 1].name;
            bulletSelectingUI_Items[2].icon.sprite = openedBullets[centerItemIndex + 1].icon;
            if (selectedBulletsData.Count == 0)
                bulletSelectingUI_Items[2].number.text = "0";
            else
            {
                BulletData target = null;
                foreach (BulletData bd in selectedBulletsData)
                {
                    if (bd.name == openedBullets[centerItemIndex + 1].name)
                    {
                        target = bd;
                        break;
                    }
                }
                if (target == null)
                    bulletSelectingUI_Items[2].number.text = "0";
                else
                    bulletSelectingUI_Items[2].number.text = target.number.ToString();
            }
        }
        bulletSelectingUI_Items[1].name.text = openedBullets[centerItemIndex].name;
        bulletSelectingUI_Items[1].bullet = openedBullets[centerItemIndex];
        bulletSelectingUI_Items[1].icon.sprite = openedBullets[centerItemIndex].icon;
        if (selectedBulletsData.Count == 0)
            bulletSelectingUI_Items[1].number.text = "0";
        else
        {
            BulletData target = null;
            foreach (BulletData bd in selectedBulletsData)
            {
                if (bd.name == openedBullets[centerItemIndex].name)
                {
                    target = bd;
                    break;
                }
            }
            if (target == null)
                bulletSelectingUI_Items[1].number.text = "0";
            else
                bulletSelectingUI_Items[1].number.text = target.number.ToString();
        }
    }
    public void UpdateOpenedBulletsList()
    {
        openedBulletsData = DataSerialization.GetObject("openedBullets") as List<BulletData>;
        if (openedBullets == null)
            openedBullets = new List<Bullet>();

        foreach (BulletData bd in openedBulletsData)
        {
            foreach (Bullet bullet in all_bullets)
            {
                if (bullet.name == bd.name)
                {
                    openedBullets.Add(bullet);
                    break;
                }
                else
                {
                    continue;
                }
            }
            continue;
        }
    }
    public void SetCeneterItemIndex(int index)
    {
        if (index < 0)
            index = 0;
        else if (index >= openedBullets.Count)
            index = openedBullets.Count - 1;
        centerItemIndex = index;
    }
    public void SelectMore(int targetIndex)
    {
        BulletData targetBulletData = null;
        for (int i = 0; i < selectedBulletsData.Count; i++)
        {
            if (selectedBulletsData[i].name == bulletSelectingUI_Items[targetIndex].bullet.name)
            {
                BulletData targetOpenedBullet = null;
                List<BulletData> openedBulletsData = (DataSerialization.GetObject("openedBullets") as List<BulletData>);
                for (int w = 0;w < openedBulletsData.Count; w++)
                {
                    if (selectedBulletsData[i].name == openedBulletsData[w].name)
                    {
                        targetOpenedBullet  = openedBulletsData[w];
                        break;
                    }
                }
                targetBulletData = selectedBulletsData[i];
                if (freeSpace - bulletSelectingUI_Items[targetIndex].bullet.mass >= 0 && selectedBulletsData[i].number < targetOpenedBullet.number)
                {
                    selectedBulletsData[i].number++;
                    freeSpace -= (int)bulletSelectingUI_Items[targetIndex].bullet.mass;
                }
                break;
            }
        }
        if (targetBulletData == null && freeSpace - bulletSelectingUI_Items[targetIndex].bullet.mass >= 0)
            selectedBulletsData.Add(new BulletData(bulletSelectingUI_Items[targetIndex].bullet.name, 1));
        DataSerialization.SaveData(selectedBulletsData, "SelectedBullets");
        UpdateUI();
    }
    public void SelectLess(int targetIndex)
    {
        for (int i = 0; i < selectedBulletsData.Count; i++)
        {
            if (selectedBulletsData[i].name == bulletSelectingUI_Items[targetIndex].bullet.name)
            {
                selectedBulletsData[i].number--;
                if (selectedBulletsData[i].number == 0)
                    selectedBulletsData.Remove(selectedBulletsData[i]);
                freeSpace += (int)bulletSelectingUI_Items[targetIndex].bullet.mass;
                break;
            }
        }
        DataSerialization.SaveData(selectedBulletsData, "SelectedBullets");
        UpdateUI();
    }
    private void UpdateFreeSpaceValue()
    {
        try
        {
            cannon = DataSerialization.GetObject("Cannon") as Cannon;
        }
        catch (Exception e) { }
        if (cannon == null)
            maxSpace = 200;
        else
            maxSpace = (int)cannon.ammunitionStore.MaxSpace;
        freeSpace = maxSpace;
        foreach (BulletData bd in selectedBulletsData)
        {

            foreach (Bullet bullet in openedBullets)
            {
                if (bullet.name == bd.name)
                {
                    Debug.Log("bullet mass = " + bullet.mass + "/// bullets number = " + bd.number);
                    freeSpace -= (int)bullet.mass * bd.number;
                    break;
                }
            }
        }
        UpdateOpenedBulletsList();
        UpdateUI();
    }
}
[System.Serializable]
public class BulletSelectingUI_Item
{
    public GameObject parent;
    public TMP_Text name;
    public List<Text> info;
    public TMP_Text number;
    public Image icon;
    public Bullet bullet;
}
 