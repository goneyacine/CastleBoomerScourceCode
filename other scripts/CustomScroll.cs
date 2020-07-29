using UnityEngine;

public class CustomScroll : MonoBehaviour
{
    public Vector2 minMaxYPosition;
    private float hieght;
    [Range(0, 1)]
    public float value;
    //the gameObject rectangle transform that contians all tragets UI Elements
    public RectTransform content;
    public float scrollingSensitivy;
    private void Update()
    {
        
        hieght = minMaxYPosition.y - minMaxYPosition.x;

        float MouseY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(0))
        value += MouseY * scrollingSensitivy;

        //checking if "value" is in the range (0.0 , 1.0)
        if (value < 0)
            value = 0;
        else if (value > 1)
            value = 1;

        content.anchoredPosition = new Vector2(content.anchoredPosition.x,minMaxYPosition.x + (value * hieght));
    }

}
