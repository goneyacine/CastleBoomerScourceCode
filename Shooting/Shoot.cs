using UnityEngine;
public abstract class Shoot : MonoBehaviour
{
    public Bullet bullet;
    public CannonHeadManager cannonHeadManager;
    public CannonShooter cannonShooter;
    public GameObject bulletPrefab;
    public float mouseSensetvity;
    public float finalVelocity;
    public abstract void ShootMethod();
}
