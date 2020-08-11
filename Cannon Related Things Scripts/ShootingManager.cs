﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShootingManager : MonoBehaviour
{
    public Shoot shoot;
    public CannonHeadManager cannonHeadManager;
    private List<Bullet> bullets;
    public int selectedBulletRole = 0;
    public Bullet selectedBullet;
    public GameObject bulletPrefab;
    public CannonShooterManager cannonShooterManager;
    public float mouseSensetvity = .1f;
    private void Update()
    {
        bullets = cannonHeadManager.gameObject.GetComponent<CannonHeadBulletsManager>().bullets;
        if (bullets != null)
        {
            if (selectedBulletRole < 0)
                selectedBulletRole = bullets.Count - 1;
            else if (selectedBulletRole > bullets.Count - 1)
                selectedBulletRole = 0;
        }
        selectedBullet = bullets[selectedBulletRole];
        shoot.cannonHeadManager = cannonHeadManager;
        shoot.bullet = selectedBullet;
        shoot.cannonShooter = cannonShooterManager.cannonShooter;
        shoot.bulletPrefab = bulletPrefab;
        shoot.mouseSensetvity = mouseSensetvity;
        shoot.ShootMethod();
    }
}