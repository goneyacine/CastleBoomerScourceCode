using UnityEngine;
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
    public GameObject cannonShootingEffect;
    public CannonShooterManager cannonShooterManager;
    public float mouseSensetvity = .2f;
     private string controlMode = "Mouse";
    private void Start()
    {
        bullets = cannonHeadManager.gameObject.GetComponent<CannonHeadBulletsManager>().bullets;
        controlMode = DataSerialization.GetObject("ControlMode") as string;
          if (bullets != null)
        {
            if (selectedBulletRole < 0)
                selectedBulletRole = bullets.Count - 1;
            else if (selectedBulletRole > bullets.Count - 1)
                selectedBulletRole = 0;
            selectedBullet = bullets[selectedBulletRole];
        }
        shoot.cannonHeadManager = cannonHeadManager;
        shoot.bullet = selectedBullet;
        shoot.cannonShooter = cannonShooterManager.cannonShooter;
        shoot.bulletPrefab = bulletPrefab;
        shoot.cannonShootingEffect = cannonShootingEffect;
        shoot.mouseSensetvity = mouseSensetvity;

    }
    private void Update()
    {
        if (bullets != null)
        {
            if (selectedBulletRole < 0)
                selectedBulletRole = bullets.Count - 1;
            else if (selectedBulletRole > bullets.Count - 1)
                selectedBulletRole = 0;
            selectedBullet = bullets[selectedBulletRole];
        }
        if (((Input.GetMouseButtonUp(0) || Input.GetMouseButton(0)) && controlMode == "Mouse"))
         Shoot();
         else if(controlMode == "Keyboard" && Input.GetKeyUp(KeyCode.Space))
         Shoot();        
         if(controlMode == "Keyboard"){
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        shoot.MoreShootingDistance(.08f);
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        shoot.LessShootingDistance(.08f);
    }

        }
        public void Shoot(){
        
            shoot.cannonHeadManager = cannonHeadManager;
            shoot.bullet = selectedBullet;
            shoot.cannonShooter = cannonShooterManager.cannonShooter;
            shoot.bulletPrefab = bulletPrefab;
            shoot.mouseSensetvity = mouseSensetvity;
            shoot.ShootMethod();
        }
        public void MoreShootingDistance(float value){
            shoot.MoreShootingDistance(value);
        }
        public void LessShootingDistance(float value){
            shoot.LessShootingDistance(value);
        }
}
