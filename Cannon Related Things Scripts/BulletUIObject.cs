using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletUIObject : MonoBehaviour
{
    public Bullet bullet;
    public CannonHeadBulletsManager cannonHeadBulletsManager;
    public int bulletIndex;
    public Text bulletsNumber;
    public Image bulletIcon;
    public Text bulletName;

    private void Update()
    {
        if (bullet != null)
        {
            bulletIcon.sprite = bullet.icon;
            bulletName.text = bullet.name;
            bulletsNumber.text = cannonHeadBulletsManager.bulletsNumbers[bulletIndex].ToString();
        }
        
    }
}
