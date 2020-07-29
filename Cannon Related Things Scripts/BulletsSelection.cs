using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSelection : MonoBehaviour
{
    public int x, y, z;
    public List<Bullet> bullets;
    public Bullet XBullet;
    public Bullet YBullet;
    public Bullet ZBullet;
    public BulletUIObject BulletUIObjectX;
    public BulletUIObject BulletUIObjectY;
    public BulletUIObject BulletUIObjectZ;
    public ShootingManager shootingManager;
    private void Start()
    {
        bullets = GetComponent<CannonHeadBulletsManager>().bullets;
        x = 0;
        y = x + 1;
        z = y + 1;

    }
    private void Update()
    {
        bullets = GetComponent<CannonHeadBulletsManager>().bullets;
        y = x + 1;
        z = y + 1;
        CheckXYZ();
        //set the Xbullet ,YBullet , ZBullet objects with some conditions
        if (bullets.Count != 0 && bullets != null)
        {
            //set the XBullet object 
            XBullet = bullets[x];
            if (bullets.Count >= 2)
            {
                //set the YBullet object
                YBullet = bullets[y];
                if (bullets.Count >= 3)
                    //set the ZBuller obejct
                    ZBullet = bullets[z];
            }
        }
        BulletUIObjectX.bullet = XBullet;
        BulletUIObjectX.bulletIndex = x;

        BulletUIObjectY.bullet = YBullet;
        BulletUIObjectY.bulletIndex = y;

        BulletUIObjectZ.bullet = ZBullet;
        BulletUIObjectZ.bulletIndex = z;
    }
    private void CheckXYZ()
    {
        //check if x is in range 
        if (x > bullets.Count - 1)
            x = x - bullets.Count - 1;
        else if (x < 0)
            x = bullets.Count - x;
        //check if y is in the range
        if (bullets.Count >= 2)
        {
            if (y > bullets.Count - 1)
                y = y - bullets.Count - 1;
        }
        if (y < 0)
            y = bullets.Count - y;
        
        //check if z is in the range
        if (bullets.Count >= 3)
        {
            if (z > bullets.Count - 1)
                z = z - bullets.Count - 1;
        }
         if (z < 0)
            z = bullets.Count - z;
        
    }
    public void XMinusOne() => x --;
    public void XPlusOne() => x ++;
    public void SelectXBullet()
    {
        if(XBullet != null)
        {
            shootingManager.selectedBulletRole = bullets.IndexOf(XBullet);
        }
    }
    public void SelectYBullet()
    {
        if (YBullet != null)
        {
            shootingManager.selectedBulletRole = bullets.IndexOf(YBullet);
        }
    }
    public void SelectZBullet()
    {
        if (ZBullet != null)
        {
            shootingManager.selectedBulletRole = bullets.IndexOf(ZBullet);
        }
    }
}
