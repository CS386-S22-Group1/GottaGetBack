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
    /*
    [Header( "ENEMY CLASS" )]

    /// <summary>
    ///     <para>
    ///         EnemyClass that defines how this enemy interacts with the
    ///         environment and the player
    ///     </para>
    /// </summary>
    private EnemyClass enemyClass;


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
    private float focusTimer = 0.000000f;


    private void Start()
    {
        enemyClass = ( EnemyClass ) characterClass;

        target = Target();
    }

    private void Update()
    {
        GetInput();

        if ( focusTimer <= 0.000000f )
        {
            target = Target();

            focusTimer = enemyClass.focusInterval;
        }
    }

    private void FixedUpdate()
    {
        if ( target != null )
        {
            Rotate( target.position );

            MoveTo( target.position );

            if ( Vector2.Distance( body.position,
                    target.position ) <= enemyClass.attackRange &&
                    attackTimer <= 0.000000f )
            {
                AttackTarget();
            }
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

        targetCharacter.UpdateHealth( -enemyClass.damageModifier );

        attackTimer = enemyClass.attackSpeed;
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

        if ( distance >= enemyClass.stoppingDistance )
        {
            body.position = Vector2.Lerp( body.position, inDesiredPosition,
                                enemyClass.moveSpeed * Time.fixedDeltaTime *
                                velocitySmoother );
        }
    }

    /// <summary>
    ///     <para>
    ///         Identifies a target position to move
    ///     </para>
    ///
    ///     <para>
    ///         Note: will discriminate on targeting a player or a position in
    ///         space depending on multiple factors
    ///     </para>
    /// </summary>
    /// 
    /// <returns>
    ///     Transform component of a target
    /// </returns>
    private Transform Target()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll( transform.position,
                                    enemyClass.viewRange );

        foreach ( Collider2D collider in colliders )
        {
            if ( collider.gameObject.CompareTag( targetTag ) )
            {
                return collider.transform;
            }
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        enemyClass = ( EnemyClass ) characterClass;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere( transform.position, enemyClass.viewRange );

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, enemyClass.attackRange );
    }
    */
}
