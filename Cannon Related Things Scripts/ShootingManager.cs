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
    public CannonShooterManager cannonShooterManager;
    public float mouseSensetvity = .2f;
     private string controlMode = "Mouse";
    private void Start()
    {
        bullets = cannonHeadManager.gameObject.GetComponent<CannonHeadBulletsManager>().bullets;
        controlMode = DataSerialization.GetObject("ControlMode") as string;

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
        if (((Input.GetMouseButtonUp(0) || Input.GetMouseButton(0)) && controlMode == "Mouse") || (Input.GetKeyDown(KeyCode.Space) && controlMode == "Keyboard"))
        Shoot();


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
