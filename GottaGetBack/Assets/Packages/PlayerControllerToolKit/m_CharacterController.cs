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
[RequireComponent( typeof( Rigidbody ) )]
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
    protected Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    /// <summary>
    ///     <para>
    ///         Accelerates a player in their desired direction
    ///     </para>
    /// </summary>
    ///
    /// <param name="inDesiredDirection">
    ///     A normalized Vector3 in which the player desires to accelerate
    /// </param>
    protected virtual void Move( Vector3 inDesiredDirection )
    {
        // define a Vector3 to hold the calculated velocity left to gain
        // before reaching maximum velocity
        Vector3 velocityToGain;

        // define a Vector3 to hold the found acceleration
        Vector3 neededAcceleration;

        // find velocity left to gain before reaching maximum velocity
        velocityToGain = ( inDesiredDirection * playerClass.moveSpeed ) -
                                                                  body.velocity;

        // find the acceleration, for this time update, to reach maximum
        // velocity
        neededAcceleration = velocityToGain / Time.fixedDeltaTime;

        // move the player's current velocity closer to the found
        // acceleration vector
        neededAcceleration =
            Vector3.MoveTowards( body.velocity,
                                 neededAcceleration,
                                 playerClass.acceleration / Time.fixedDeltaTime
                               );

        // apply a force with needed acceleration in relation to this
        // object's mass
        body.AddForce( new Vector3( neededAcceleration.x,
                                    neededAcceleration.y,
                                    0.000000f ) * body.mass
                                  );
    }
}