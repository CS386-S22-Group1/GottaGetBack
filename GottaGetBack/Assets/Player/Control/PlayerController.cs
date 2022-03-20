using UnityEngine;
using CharacterControl;

namespace CharacterControl
{
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
        public float xInput = 0.000000f;
        public float yInput = 0.000000f;

        /// <summary>
        ///     <para>
        ///         Vector2 describing the player's desired direction of travel
        ///     </para>
        /// </summary>
        public Vector2 desiredDirection = Vector2.zero;

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
        public Vector2 mousePosition = Vector2.zero;


        private void Start()
        {
            playerCam = Camera.main;
        }

        private void Update()
        {
            if ( !IsOwner ) return;

            GetInput();
        }

        private void FixedUpdate()
        {
            if ( !IsOwner ) return;

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

            // convert's the mouse's position on the screen to world coordinates
            //mousePosition = playerCam.ScreenToWorldPoint( Input.mousePosition );

            desiredDirection = Vector2.right * xInput + Vector2.up * yInput;
            desiredDirection.Normalize();
        }
    }
}