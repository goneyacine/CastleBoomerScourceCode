using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Castle_Manager : MonoBehaviour
{
    public List<Castle_Object> castle_Objects;
    private GameObject[] castleObjects_Obj;
    public float startSpace = 0;
    public float currentSpace;
    public int damagePercentage;
    private void Start()
    {
        UpdateCastleObjectList();
        foreach(Castle_Object CO in castle_Objects) {
            startSpace += CO.space;
        }
        currentSpace = startSpace;
    }

    private void Update()
    {
        UpdateCastleObjectList();
        currentSpace = 0;
        foreach (Castle_Object CO in castle_Objects)
        {
            currentSpace += CO.space;
        }
        damagePercentage = (int)((startSpace - currentSpace) * 100 / (Mathf.Abs(startSpace) + 1));
        if (damagePercentage == 99)
            damagePercentage++;
    }
    private void UpdateCastleObjectList()
    {
        castleObjects_Obj = GameObject.FindGameObjectsWithTag("CastleObject");
        castle_Objects = new List<Castle_Object>();
        foreach (GameObject obj in castleObjects_Obj)
        {
            castle_Objects.Add(obj.GetComponent<Castle_Object_Manager>().castle_Object);
        }
    }
  
}
