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


    [Header( "GROUND DETECTION" )]

    /// <summary>
    ///     A flag which identifies if the player is standing on an object that
    ///     is on the ground layer
    ///
    ///     Note: The name given to the "ground layer" is user defined
    ///
    ///     Note: This flag is intended to be updated with a call to the
    ///     Grounded() method every fixed update; this is simply done in the
    ///     interest of performance
    /// </summary>
    protected bool grounded;

    /// <summary>
    ///     Used for groundCheck position and radius debugging
    /// </summary>
    [SerializeField]
    private bool showGroundChecking;

    /// <summary>
    ///     Used to define the maximum vertical distance the player object can
    ///     be above the ground and still be considered on the ground
    /// </summary>
    [Range(0f, 1f)]
    [SerializeField]
    protected float checkForGroundDist;

    /// <summary>
    ///     Reference to an arbitrary point in space, maintained by an empty
    ///     game object which marks the center of a sphere with a radius equal
    ///     to checkForGroundDist
    /// </summary>
    [SerializeField]
    protected Transform groundCheck;

    /// <summary>
    ///     Determines what layer is "ground"
    /// </summary>
    [SerializeField]
    protected LayerMask groundMask;


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
                                    body.velocity.y,
                                    neededAcceleration.z ) * body.mass
                                  );
    }

    /// <summary>
    ///     Checks for objects on groundMask within a specified radius
    /// </summary>
    /// 
    /// <returns>
    ///     Boolean identifying if the player is standing on top of an object
    ///     that is on the "ground mask"
    /// </returns>
    protected bool Grounded()
    {
        return Physics.CheckSphere( groundCheck.position, checkForGroundDist,
                                    groundMask );
    }

    /// <summary>
    ///     OnDrawGizmos is called regardless; this method renders a wire
    ///     sphere, with a maximum radius of 1, to the game scene
    ///
    ///     Note: User must set showGroundChecking to true in the inspector
    ///           before the wire sphere will appear
    /// </summary>
    private void OnDrawGizmos()
    {
        try
        {
            if ( showGroundChecking )
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere( groundCheck.position,
                                       checkForGroundDist );
            }
        }
        catch( UnassignedReferenceException )
        {
            Debug.LogWarning( "Missing reference to a ground check position" );
        }
    }
}