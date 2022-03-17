using Unity.Netcode;
using UnityEngine;

public class Ranged : Item
{
    [Header( "RANGED DATA" )]

    /// <summary>
    ///     <para>
    ///         Data that will affect how this weapon behaves
    ///     </para>
    /// </summary>
    [SerializeField]
    private RangedData rangedData;


    [Header( "CURRENT STATS" )]

    /// <summary>
    ///     <para>
    ///         Shows how many bullets are in the magazine at current
    ///     </para>
    /// </summary>
    private int bulletsLeft = 0;

    /// <summary>
    ///     <para>
    ///         Identifies how many birdshot is left
    ///     </para>
    /// </summary>
    ///
    /// <remarks>
    ///     <para>
    ///         Used in shotgun simulation
    ///     </para>
    /// </remarks>
    private int shotLeft = 1;

    [SerializeField]
    private bool useProjectile = false;


    [Header( "PROJECTILE HEADING" )]

    /// <summary>
    ///     <para>
    ///         Heading the projectile will follow
    ///     </para>
    ///
    ///     <para>
    ///         To change between shots
    ///     </para>
    /// </summary>
    //private Vector2 heading = Vector2.zero;


    [Header( "ACTION FLAGS" )]

    /// <summary>
    ///     <para>
    ///         Identifies if this weapon is being reloaded
    ///     </para>
    /// </summary>
    private bool reloading = false;

    /// <summary>
    ///     <para>
    ///         Identifies if this weapon is to be used
    ///     </para>
    /// </summary>
    private bool shooting = false;


    [Header( "TIMERS" )]

    /// <summary>
    ///     <para>
    ///         Time until reload is finished
    ///     </para>
    /// </summary>
    private float reloadTimer = 0.000000f;

    /// <summary>
    ///     <para>
    ///         Time until next bullect can be fired
    ///     </para>
    /// </summary>
    private float fireRateTimer = 0.000000f;


    [Header( "FIRE POINT" )]

    /// <summary>
    ///     <para>
    ///         Transform point in space representative of the end of this
    ///         ranged weapon's barrel
    ///     </para>
    /// </summary>
    [SerializeField]
    private Transform firePoint;


    private void Awake()
    {
        reloadTimer = rangedData.reloadSpeed;
        bulletsLeft = rangedData.magazineSize;
        shotLeft = rangedData.roundsPerShot;
    }

    private void Update()
    {
        if ( equipped && IsOwner )
        {
            GetInput();

            if ( reloading && reloadTimer <= 0.000000f )
            {
                Reload();
            }

            if ( shooting && !reloading && bulletsLeft > 0 &&
                 fireRateTimer <= 0.000000f )
            {
                Shoot();

                bulletsLeft--;
            }
        }
    }

    /// <summary>
    ///     <para>
    ///         Listens for input and updates this weapon's state
    ///     </para>
    /// </summary>
    private void GetInput()
    {
        // decrease reload and fire rate timer
        fireRateTimer -= Time.deltaTime;

        if ( reloading )
        {
            reloadTimer -= Time.deltaTime;
        }
        else if ( bulletsLeft < rangedData.magazineSize )
        {
            reloading = Input.GetKeyDown( KeyCode.R );
        }

        if ( rangedData.isAutomatic )
        {
            if ( useProjectile )
            {
                shooting = Input.GetKey( KeyCode.Mouse0 );
            }
            else
            {
                shooting = Input.GetKey( KeyCode.Mouse1 );
            }
        }
        else
        {
            if ( useProjectile )
            {
                shooting = Input.GetKeyDown( KeyCode.Mouse0 );
            }
            else
            {
                shooting = Input.GetKeyDown( KeyCode.Mouse1 );
            }
        }
    }

    /// <summary>
    ///     <para>
    ///         Simulates reloading
    ///     </para>
    /// </summary>
    private void Reload()
    {
        reloadTimer = rangedData.reloadSpeed;

        bulletsLeft = rangedData.magazineSize;

        reloading = false;
    }

    /// <summary>
    ///     <para>
    ///         Simulates shooting a bullet
    ///     </para>
    /// </summary>
    private void Shoot()
    {
        RaycastHit2D outHit;

        // figure a "spreaded" path for the bullet

        /* Built in because I will run the pros and cons of hit-scan vs.
         * projectiles by the group and see what people think
         * 
         */

        if ( useProjectile )
        {
            SpawnProjectileServerRpc();
        }
        else
        {
            Rigidbody2D enemyBody;
            Character collidedCharater;

            outHit = Physics2D.Raycast( firePoint.position, firePoint.right, 100f );

            try
            {
                if ( outHit.collider.TryGetComponent<Rigidbody2D>( out enemyBody ) )
                {
                    enemyBody.AddForce( firePoint.right *
                                        rangedData.ammunition.explosionForce,
                                        ForceMode2D.Impulse );
                }

                if ( outHit.collider.TryGetComponent<Character>( out collidedCharater ) )
                {
                    collidedCharater.UpdateHealth( -rangedData.ammunition.damage );
                }
            }
            catch( System.NullReferenceException )
            {
                /* added this because Unity doesn't know how to handle itself */
            }

            Debug.DrawRay( firePoint.position, firePoint.right, Color.cyan,
                           5.000000f );
        }

        // decrease shotLeft
        shotLeft--;

        // check for anymore shot left
        if ( shotLeft > 0 )
        {
            // shoot another
            Shoot();
        }

        // reset shotLeft
        shotLeft = rangedData.roundsPerShot;

        fireRateTimer = rangedData.fireRate;
    }

    [ClientRpc]
    private void SpawnProjectileClientRpc()
    {
        // spawn a bullet, and add some force to it in on the determined forward
        // vector
        GameObject spawnedProjectile = Instantiate(
                                        rangedData.ammunition.projectile,
                                        firePoint.position,
                                        firePoint.rotation );

        Rigidbody2D spawnedBody =
                              spawnedProjectile.GetComponent<Rigidbody2D>();

        spawnedBody.AddForce( firePoint.right * 20f, ForceMode2D.Impulse ); // will have to fix that magic number
    }

    [ServerRpc]
    private void SpawnProjectileServerRpc()
    {
        SpawnProjectileClientRpc();
    }
}
