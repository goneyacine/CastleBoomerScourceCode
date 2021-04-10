using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectingManager : MonoBehaviour
{
  //this list contains all the items type (there is a list of items on each item type) the player can use
   public List<ItemsType> itemsTypes;
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
}
