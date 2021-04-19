using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelectingManager : MonoBehaviour
{
  //this list contains all the items type (there is a list of items on each item type) the player can use
  public List<ItemsType> itemsTypes;
  //this list contains all the ItemUIDisplayer objects
  public List<ItemUIDisplayer> itemsUIDisplayers;
  public List<ItemsTypeUIDisplayer> itemsTypeUIDisplayers;
  public ItemsType selectedItemsType;

  public Sprite defaultItemSprite;

  public int itemsStartingIndex = 0;

  public void SetSelectedItemsType(int itemIndex) 
  {
    //setting the items UI displayers info to there default values
    for(int i = 0;i < 9;i++)
    {
     itemsUIDisplayers[i].iconImage.sprite = defaultItemSprite;
     itemsUIDisplayers[i].nameText.text = ""; 
     itemsUIDisplayers[i].clickButton.gameObject.GetComponent<ItemCreateButton>().myObject = null;
    }

    itemsStartingIndex = 0;
    selectedItemsType = itemsTypes[itemIndex];
  }
  //this method is used to scroll down on the items displaying panel
  public void GoDown()
  {
    if(itemsStartingIndex - 3 >= 0)
       itemsStartingIndex -= 3;
  }
  //this method is used to scroll up on the items displaying panel
  public void GoUp(){
    if(itemsStartingIndex + 3  <= selectedItemsType.items.Count - 1)
       itemsStartingIndex += 3;
  }

  private void Update()
  {
   //displaying the items types names
   for(int i = 0;i < itemsTypes.Count;i++)
       itemsTypeUIDisplayers[i].typeNameText.text = itemsTypes[i].typeName;
   
   //displayingg the items info like : name, icon, ...
   if(itemsTypes.Count > 0)
   {
       //first we should check that the selected items type is not null
        if(selectedItemsType == null)
           selectedItemsType = itemsTypes[0];
      //then we display the info of each item
       for(int i = itemsStartingIndex; i - selectedItemsType.items.Count <= 9;i++)
        { 
          int displayItemsIndex =  i - itemsStartingIndex;
          itemsUIDisplayers[displayItemsIndex].nameText.text = selectedItemsType.items[i].displayName;
          itemsUIDisplayers[displayItemsIndex].iconImage.sprite = selectedItemsType.items[i].icon;
          itemsUIDisplayers[displayItemsIndex].clickButton.gameObject.GetComponent<ItemCreateButton>().myObject = selectedItemsType.items[i].prefab;      
   }

   
  }


 }
}

/*
 an item contains info (informations like : icon, prefab, name...) about an object that can be spawned in the
 map like a castle object , black hole , tnt... 
 */
[System.Serializable]
public class Item 
{

 //the name of the item
 public string displayName = "object";

 public Sprite icon;
 public GameObject prefab;
} 

// an items type is a type of items that have the same type like : black holes, booms, castle objects ... 
[System.Serializable]
public class ItemsType 
{
  //the list of the items this items type contains
 public List<Item> items;

 public string typeName = "....";
}
//this class contains all the UI elements needed to display an item like : text for displaying the name, an image for displaying icon ....
[System.Serializable]
public class ItemUIDisplayer 
{
  public Text nameText;
  public Image iconImage;
  public Button clickButton;
}

[System.Serializable]
public class ItemsTypeUIDisplayer 
{
  public Text typeNameText;
}

