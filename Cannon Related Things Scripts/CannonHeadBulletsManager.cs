using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CannonHeadBulletsManager : MonoBehaviour
{
    public List<Bullet> bullets;
    public List<int> bulletsNumbers;
    public float emptySpace;

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
