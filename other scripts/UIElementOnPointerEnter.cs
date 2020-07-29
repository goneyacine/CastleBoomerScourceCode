using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIElementOnPointerEnter : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public bool mouseEntered = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseEntered = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseEntered = false;
    }
}
