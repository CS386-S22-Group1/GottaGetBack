using UnityEngine;

[CreateAssetMenu( fileName = "DefaultProjectile", menuName = "Items/New Projectile" )]
public class ProjectileData : ScriptableObject
{
    [Header( "PROJECTILE NAME" )]

    public string projectileName = "Default Projectile";


    [Header( "PROJECTILE STATS" )]

    public int damage = 6;

    public float timeAlive = 10.000000f;

    public bool explosive = false;

    public float areaOfAffect = 10.000000f;

    [Range( 1.000000f, 500.000000f )]
    public float explosionForce = 1.000000f;


    [Header( "PROJECTILE" )]

    public GameObject projectile;
}
