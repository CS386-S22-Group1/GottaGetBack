using UnityEngine;

/// <summary>
///     <para>
///         Provides a modifiable baseline for player control
///     </para>
///
///     <para>
///         Note: This is intended to be the backend (inhereted from)
///     </para>
///
///     <para>
///         Author: Num0Programmer
///     </para>
/// </summary>
[RequireComponent( typeof( Rigidbody2D ) )]
public class m_CharacterController : MonoBehaviour
{
    [Header( "CLASS" )]

    /// <summary>
    ///     <para>
    ///         The class the player will be playing as
    ///     </para>
    /// </summary>
    [SerializeField]
    protected Class playerClass;

    [Header( "MOVEMENT" )]

    /// <summary>
    ///     <para>
    ///         The maximum amount to move the current velocity this update
    ///         toward the desired velocity
    ///     </para>
    /// </summary>
    [Range( 0.010000f, 0.100000f )]
    [SerializeField]
    private float velocitySmoother = 0.050000f;

    /// <summary>
    ///     <para>
    ///         Store for the player's current velocity this update
    ///     </para>
    /// </summary>
    private Vector2 refVelocity = Vector2.zero;


    [Header( "COMPONENTS" )]

    /// <summary>
    ///     Reference to an arbitrary point in space, maintainded by a Camera
    ///     object, which represents the position and rotation attributes of the
    ///     camera accompanying the player object
    /// </summary>
    /*
    [SerializeField]
    protected Transform cam;
    */

    /// <summary>
    ///     Reference to the Rigidbody component which is appears on the player
    ///     object
    /// </summary>
    protected Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    ///     <para>
    ///         Accelerates a player in their desired direction
    ///     </para>
    /// </summary>
    ///
    /// <param name="inDesiredDirection">
    ///     A normalized Vector2 in which the player desires to accelerate
    /// </param>
    protected virtual void Move( Vector2 inDesiredDirection )
    {
        Vector2 desiredVelocity = inDesiredDirection * playerClass.moveSpeed;

        body.velocity = Vector2.SmoothDamp( body.velocity, desiredVelocity,
                                            ref refVelocity, velocitySmoother );
    }
}