using UnityEngine;

/// <summary>
///     <para>
///         Provides input capture and routing so the player can move their
///         object
///     </para>
///
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
public class PlayerController : m_CharacterController
{
    [Header( "INPUT" )]

    /// <summary>
    ///     <para>
    ///         Saves latest input from movement interface device for moving the
    ///         character
    ///     </para>
    /// </summary>
    private float xInput, yInput;

    /// <summary>
    ///     <para>
    ///         Vector2 describing the player's desired direction of travel
    ///     </para>
    /// </summary>
    private Vector2 desiredDirection = Vector2.zero;

    [Header( "ROTATION" )]

    /// <summary>
    ///     <para>
    ///         Reference to the player's camera
    ///     </para>
    /// </summary>
    [SerializeField]
    private Camera playerCam;

    /// <summary>
    ///     <para>
    ///         Vector2 holding the mouse's position in world space
    ///     </para>
    /// </summary>
    //private Vector2 mousePosition = Vector2.zero;


    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MoveServerRpc( desiredDirection );

        //Rotate( mousePosition );
    }

    /// <summary>
    ///     <para>
    ///         Captures input from player and player object
    ///     </para>
    /// </summary>
    private void GetInput()
    {
        xInput = Input.GetAxisRaw( "Horizontal" );
        yInput = Input.GetAxisRaw( "Vertical" );

        //mousePosition = playerCam.ScreenToWorldPoint( Input.mousePosition );

        desiredDirection = Vector2.right * xInput + Vector2.up * yInput;
        desiredDirection.Normalize();
    }
}
