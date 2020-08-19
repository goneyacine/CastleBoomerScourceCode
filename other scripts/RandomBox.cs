using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RandomBox : MonoBehaviour
{
    private Castle_Manager castle_Manager;
    public GameObject youGotGoldPrefab;
    public GameObject youGotMoneyPrefab;
    private void Start()
    {
        castle_Manager = FindObjectOfType<Castle_Manager>();
    }
    private void OnDestroy()
    {
        if (gameObject.GetComponent<Castle_Object_Manager>().castle_Object.isRandomBox)
        {
            int randomType = Random.Range(0, 20);
            if (randomType < 0)
            {
                int randomGoldValue = Random.Range(1, 25);
                castle_Manager.gold += randomGoldValue;
                int oldTotalPlayerGold = (int)DataSerialization.GetObject("gold");
                DataSerialization.SaveData(oldTotalPlayerGold + randomGoldValue, "gold");
                GameObject youGotGold = Instantiate(youGotGoldPrefab,youGotGoldPrefab.transform.position, Quaternion.identity, FindObjectOfType<Canvas>().transform);
                youGotGold.GetComponent<TMP_Text>().text = randomGoldValue.ToString();
                youGotGold.transform.localPosition = Vector2.zero;
                 Destroy(youGotGold, 3f);
            }
            else
            {
                int randomMoneyValue = Random.Range(10, 300);
                castle_Manager.money += randomMoneyValue;
                int oldTotalMoneyValue = (int)DataSerialization.GetObject("money");
                DataSerialization.SaveData(oldTotalMoneyValue + randomMoneyValue, "money");
                GameObject youGotMoney = Instantiate(youGotMoneyPrefab,youGotMoneyPrefab.transform.position, Quaternion.identity, FindObjectOfType<Canvas>().transform);
                youGotMoney.GetComponent<TMP_Text>().text = randomMoneyValue.ToString();
                youGotMoney.transform.localPosition = Vector2.zero;
                Destroy(youGotMoney, 3f);
            }
        }
    }
}
