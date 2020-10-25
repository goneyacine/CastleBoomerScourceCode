using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CannonHeadBulletsManager : MonoBehaviour
{
    public List<Bullet> bullets;
    public List<Bullet> all_bullets;
    public Bullet DefaultBullet;
    public List<int> bulletsNumbers;
    public float emptySpace;

    private void Start()
    {
        bullets = new List<Bullet>();
        bulletsNumbers = new List<int>();
        List<BulletData> selectedBulletsData = DataSerialization.GetObject("selectedBullets") as List<BulletData>;
        if (selectedBulletsData.Count == 1)
        {
            bullets.Add(DefaultBullet);
            bulletsNumbers.Add(3);
        }
        else
        {
            foreach (BulletData bd in selectedBulletsData)
            {
                foreach (Bullet bullet in all_bullets)
                {
                    if (bullet.name == bd.name)
                    {
                        bullets.Add(bullet);
                        bulletsNumbers.Add(bd.number);
                        continue;
                    }
                }
            }
        }
    }
    private void Update()
    {
        //calculate the taken space by the bullet
        float bulletsSpace = 0;
        for(int i = 0; i < bullets.Count; i++)
        {
            bulletsSpace += bullets[i].space * bulletsNumbers[i];
        }
        //calculate the empty space
        emptySpace = GetComponent<CannonHeadManager>().cannonHead.MaxSpace - bulletsSpace;
    }
}
