using UnityEngine;
[CreateAssetMenu (fileName = "New Cannon",menuName = "Cannon/Cannon"),System.Serializable]
public class Cannon : ScriptableObject
{
    public new string name;
    public CannonBody cannonBase;
    public CannonHead ammunitionStore;
    public CannonShooter cannonMuzzle;
}
