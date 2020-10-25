using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CannonHeadManager : MonoBehaviour
{
    public CannonHead cannonHead;
    public GameObject targetObj;
    private void Update()
    {
        targetObj.transform.localPosition = cannonHead.localPos;
        targetObj.transform.localScale = cannonHead.scale;
        targetObj.GetComponent<SpriteRenderer>().sprite = cannonHead.texture;
        targetObj.GetComponent<SpriteRenderer>().color = cannonHead.color;
    }
}
