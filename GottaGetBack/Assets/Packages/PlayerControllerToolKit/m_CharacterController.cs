using Unity.Netcode;
using UnityEngine;
using CharacterStatistics;

namespace CharacterControl
{
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
    public class m_CharacterController : NetworkBehaviour
    {
        [Header( "CLASS" )]

        /// <summary>
        ///     <para>
        ///         The class the player will be playing as
        ///     </para>
        /// </summary>
        [SerializeField]
        protected CharacterClass characterClass;

        [Header( "MOVEMENT" )]

        /// <summary>
        ///     <para>
        ///         The maximum amount to move the current velocity this update
        ///         toward the desired velocity
        ///     </para>
        /// </summary>
        [Range( 0.010000f, 0.100000f )]
        [SerializeField]
        protected float velocitySmoother = 0.050000f;

        /// <summary>
        ///     <para>
        ///         Store for the player's current velocity this update
        ///     </para>
        /// </summary>
        protected Vector2 refVelocity = Vector2.zero;


        [Header( "COMPONENTS" )]

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
        ///         Moves this character toward a desired direction
        ///     </para>
        /// </summary>
        ///
        /// <param name="inDesiredDirection">
        ///     Vector2 direction in which to move this character
        /// </param>
        [ClientRpc]
        private void MoveClientRpc( Vector2 inDesiredDirection )
        {
            Vector2 desiredVelocity = inDesiredDirection * characterClass.moveSpeed;

            body.velocity = Vector2.SmoothDamp( body.velocity, desiredVelocity,
                                ref refVelocity, Time.fixedDeltaTime );
        }

        [ServerRpc]
        protected void MoveServerRpc( Vector2 inDesiredDirection )
        {
            MoveClientRpc( inDesiredDirection );
        }

        /// <summary>
        ///     <para>
        ///         Rotates this character object toward a desired point
        ///     </para>
        /// </summary>
        /// 
        /// <param name="inLookPosition">
        ///     Vector2 position to look at in the game world
        /// </param>
        protected void Rotate( Vector2 inLookPosition )
        {
            Vector2 pointDirection = inLookPosition - body.position;

            float pointAngle = Mathf.Atan2( pointDirection.y,
                                            pointDirection.x ) * Mathf.Rad2Deg;

            body.rotation = pointAngle;
        }
    }
}