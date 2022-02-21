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
    [Header( "MOVEMENT" )]

    /// <summary>
    ///     <para>
    ///         Saves latest input from movement interface device for moving the
    ///         character
    ///     </para>
    /// </summary>
    private float xInput, yInput;

    /// <summary>
    ///     <para>
    ///         Vector3 describing the player's desired direction of travel
    ///     </para>
    /// </summary>
    [SerializeField]
    private Vector3 desiredDirection = Vector3.zero;


    private void Update()
    {
        GetInput();

        Move( desiredDirection );
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

        desiredDirection = transform.right * xInput + transform.up * yInput;
        desiredDirection.Normalize();
    }
}
