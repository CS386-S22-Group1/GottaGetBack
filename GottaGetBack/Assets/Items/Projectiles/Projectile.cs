using Unity.Netcode;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
public class Projectile : NetworkBehaviour
{
    [Header( "PROJECTILE DATA" )]

    /// <summary>
    ///     <para>
    ///     </para>
    /// </summary>
    [SerializeField]
    private ProjectileData projectileData;


    [Header( "COMPONENTS" )]

    private Rigidbody2D body;


    [Header( "TIMES" )]

    private float aliveTimer = 0.000000f;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        aliveTimer = projectileData.timeAlive;
    }
    
    private void Update()
    {
        aliveTimer -= Time.deltaTime;

        if ( aliveTimer <= 0.000000f )
        {
            if ( projectileData.explosive )
            {
                Explode();
            }

            Die();
        }
    }

    private void Damage( Collider2D collider )
    {
        Character collidedCharacter = collider.GetComponent<Character>();

        if ( collidedCharacter != null )
        {
            collidedCharacter.UpdateHealth( -projectileData.damage );
        }
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll( body.position, projectileData.areaOfAffect );

        foreach( Collider2D collider in colliders )
        {
            Rigidbody2D collidedBody = collider.GetComponent<Rigidbody2D>();

            if ( collidedBody != null )
            {
                collidedBody.AddForce( body.position *
                    projectileData.explosionForce * collidedBody.mass,
                    ForceMode2D.Impulse );
            }

            Damage( collider );
        }
    }

    private void Die()
    {
        Destroy( gameObject );
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if ( projectileData.explosive )
        {
            Explode();
        }
        else
        {
            Damage( collision.collider );
        }

        Die();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere( transform.position,
                               projectileData.areaOfAffect );
    }
}
