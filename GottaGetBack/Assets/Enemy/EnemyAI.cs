using Unity.Netcode;
using UnityEngine;

/// <summary>
///     <para>
///         Baseline for enemy intelligence
///     </para>
///
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
public class EnemyAI : m_CharacterController
{
    [Header( "ENEMY CLASS" )]

    /// <summary>
    ///     <para>
    ///         EnemyClass that defines how this enemy interacts with the
    ///         environment and the player
    ///     </para>
    /// </summary>
    //private EnemyClass enemyClass;


    [Header( "TARGETING INFORMATION" )]

    /// <summary>
    ///     <para>
    ///         String tag on all players
    ///     </para>
    /// </summary>
    [SerializeField]
    private string targetTag;

    /// <summary>
    ///     <para>
    ///         Transform component of target
    ///     </para>
    ///
    ///     <para>
    ///         Note: will differ between players and determined points in space
    ///         as the enemy decides which actions are best
    ///     </para>
    /// </summary>
    private Transform target;

    /// <summary>
    ///     <para>
    ///         Rigidbody2D position reference; used to sync enemy positions in
    ///         world space across the network
    ///     </para>
    /// </summary>
    private NetworkVariable<Vector2> networkedBodyPosition = new NetworkVariable<Vector2>();


    [Header( "TIMERS" )]

    /// <summary>
    ///     <para>
    ///         Time remaining until enemy can make another attack
    ///     </para>
    /// </summary>
    private float attackTimer = 0.000000f;

    /// <summary>
    ///     <para>
    ///         Time remaining until enemy will need to refocus
    ///     </para>
    /// </summary>
    private float focusTimer;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        focusTimer = 0.000000f;
    }

    private void Update()
    {
        if ( IsServer )
        {
            GetInput();

            if ( focusTimer <= 0.000000f )
            {
                target = Target();

                // saves from having to make a duplicate instance of a
                // CharacterClass to get data in the EnemyClass subclass
                focusTimer = ToEnemyClass().focusInterval;
            }
        }
    }

    private void FixedUpdate()
    {
        if ( IsServer && target != null )
        {
            MoveTo( target.position );
        }
    }

    /// <summary>
    ///     <para>
    ///         Attacks the focused player
    ///     </para>
    /// </summary>
    private void AttackTarget()
    {
        Character targetCharacter = target.GetComponent<Character>();

        targetCharacter.UpdateHealth( -ToEnemyClass().damageModifier );

        attackTimer = ToEnemyClass().attackSpeed;
    }

    private void GetInput()
    {
        attackTimer -= Time.deltaTime;
        focusTimer -= Time.deltaTime;
    }

    /// <summary>
    ///     <para>
    ///         Moves this character toward a desired position in space
    ///     </para>
    /// </summary>
    private void MoveTo( Vector2 inDesiredPosition )
    {
        float distance = Vector2.Distance( body.position, inDesiredPosition );

        if ( distance >= ToEnemyClass().stoppingDistance )
        {
            body.position = Vector2.Lerp( body.position, inDesiredPosition,
                                ToEnemyClass().moveSpeed * Time.fixedDeltaTime *
                                velocitySmoother );

            networkedBodyPosition.Value = body.position;
        }
    }

    /// <summary>
    ///     <para>
    ///         Identifies a gameobject to move toward
    ///     </para>
    ///
    ///     <para>
    ///         Note: will discriminate between targeting a player or a position
    ///         in world space depending on multiple factors
    ///     </para>
    /// </summary>
    /// 
    /// <returns>
    ///     Transform component of a target
    /// </returns>
    private Transform Target()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll( transform.position,
                                    ToEnemyClass().viewRange );

        foreach ( Collider2D collider in colliders )
        {
            if ( collider.gameObject.CompareTag( targetTag ) )
            {
                return collider.transform;
            }
        }

        return null;
    }

    /// <summary>
    ///     <para>
    ///         Makes getting enemy data easier by getting the character class as
    ///         an EnemyClass
    ///     </para>
    ///
    ///     <para>
    ///         Intended to be a temporary fix until I can figure a better way to
    ///         grab data without having to add an extra CharacterClass subclass
    ///         type - I speak of course of the enemyClass variable I have commented
    ///         out
    ///     </para>
    /// </summary>
    /// 
    /// <returns>
    ///     characterClass as an EnemyClass
    /// </returns>
    private EnemyClass ToEnemyClass()
    {
        return ( EnemyClass ) characterClass;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere( transform.position, ToEnemyClass().viewRange );

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, ToEnemyClass().attackRange );
    }
    
}
