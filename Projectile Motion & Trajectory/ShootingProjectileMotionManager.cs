using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingProjectileMotionManager : MonoBehaviour
{
    public Transform cannonHead;
    public ProjectileMotion projectileMotion;
    public ShootingManager shootingManager;
    public UnityEvent onClickingLeftMouseButton;
    public UnityEvent onReleasingLeftMouseButton;
    private string controlMode = "Mouse";
    private void Start(){
        controlMode = DataSerialization.GetObject("ControlMode") as string;
    }
    private void Update()
    {
        //set the start position vector2 for the target projectile motion object to the postion of this transform
        projectileMotion.startPosition = transform.position;
        //set the start angle of projectile motion obj to the angle of the cannon
        projectileMotion.startAngle = cannonHead.transform.eulerAngles.z - 90;
        //check if the player is clicking the left mouse button ,so is doing that then invoke onClickingLeftMouseButton and when the player release the mouse button then invoke  onReleasingLeftMouseButton
        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            if(controlMode == "Mouse")
            onClickingLeftMouseButton.Invoke();
        }
        else
        {  
            if(controlMode == "Mouse")
            onReleasingLeftMouseButton.Invoke();
        }
        //set the life time and the start velocity values
        if(shootingManager.selectedBullet != null)
        {
            projectileMotion.maxTime = shootingManager.selectedBullet.lifeTime;
            projectileMotion.startVelocity = shootingManager.shoot.finalVelocity;
        }else if (shootingManager.selectedBullet == null)
        {
            projectileMotion.startVelocity = 0;
        }
    }
}
