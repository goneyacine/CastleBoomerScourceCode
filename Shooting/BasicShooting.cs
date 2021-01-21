using UnityEngine;
using System.Collections;

public class BasicShooting : Shoot
{
    private bool mouseIsTouchingUI = false;
    private float VelocityMultiplyer = .5f;
    private float finalVelocityMultiplyer = 1f;
     private string controlMode = "Mouse";
    private void Start(){
    controlMode = DataSerialization.GetObject("ControlMode") as string;
    }
    public override void MoreShootingDistance(float value){
    controlMode = DataSerialization.GetObject("ControlMode") as string;
            VelocityMultiplyer += value;
            if(VelocityMultiplyer > 1f)
            VelocityMultiplyer = 1f;
            else if (VelocityMultiplyer < 0f)
            VelocityMultiplyer = 0f;
        //set the final velocity of the bullet
        finalVelocity = (bullet.velocity + cannonShooter.velocityBoost) * VelocityMultiplyer;
    }
    public override void LessShootingDistance(float value){
    controlMode = DataSerialization.GetObject("ControlMode") as string;
            VelocityMultiplyer -= value;
            if(VelocityMultiplyer > 1f)
            VelocityMultiplyer = 1f;
            else if (VelocityMultiplyer < 0f)
            VelocityMultiplyer = 0f;
        finalVelocity = (bullet.velocity + cannonShooter.velocityBoost) * VelocityMultiplyer;
    }
   public override void ShootMethod()
    {
    controlMode = DataSerialization.GetObject("ControlMode") as string;
        if((Input.GetMouseButton(0) && controlMode == "Mouse"))
        VelocityMultiplyer += Input.GetAxis("Mouse X") * mouseSensetvity;

        if (VelocityMultiplyer > 1)
            VelocityMultiplyer = 1;
        else if (VelocityMultiplyer < 0f)
            VelocityMultiplyer = 0f;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < cannonHeadManager.gameObject.transform.position.x && controlMode == "Mouse")
            finalVelocityMultiplyer = 0f;
        else
            finalVelocityMultiplyer = 1f;
        //find all the gameobjects with "UI" tag
        GameObject[] UIElements = GameObject.FindGameObjectsWithTag("UI");
        mouseIsTouchingUI = false;
        //check if the mouse is touching any UI element
        if(controlMode == "Mouse")
        for(int i = 0; i < UIElements.Length;i++)
        {
            if(UIElements[i].GetComponent<UIElementOnPointerEnter>().mouseEntered)
            {
                mouseIsTouchingUI = true;
                break;
            }
            else
            {
                mouseIsTouchingUI = false;
            }
        }
        //Debug.Log(mouseIsTouchingUI);
        //set the final velocity of the bullet
        finalVelocity = (bullet.velocity + cannonShooter.velocityBoost) * VelocityMultiplyer * finalVelocityMultiplyer;
        //shoot a bullet when the player release the mouse button
        CannonHeadBulletsManager cannonHeadBulletsManager = cannonHeadManager.gameObject.GetComponent<CannonHeadBulletsManager>();

        if (((Input.GetMouseButtonUp(0) && controlMode == "Mouse" && (!mouseIsTouchingUI && Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= cannonHeadManager.gameObject.transform.position.x)) || (controlMode == "Keyboard" || controlMode == "Touche" )) && cannonHeadBulletsManager.bulletsNumbers[cannonHeadBulletsManager.bullets.IndexOf(bullet)] > 0 ) 
        {
            //create bullet object
            GameObject newBullet = Instantiate(bulletPrefab, cannonHeadManager.transform.Find("Cannon Shooter").Find("Shooting Point").transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletManager>().bullet = bullet;
            //add speed to the bullet
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos((cannonHeadManager.transform.localEulerAngles.z-90) * Mathf.Deg2Rad),
                Mathf.Sin((cannonHeadManager.transform.localEulerAngles.z -90) * Mathf.Deg2Rad)) * finalVelocity;
            cannonHeadBulletsManager.bulletsNumbers[cannonHeadBulletsManager.bullets.IndexOf(bullet)]--;

        }
    }
   
}