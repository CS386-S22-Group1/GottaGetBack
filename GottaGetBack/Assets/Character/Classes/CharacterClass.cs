using UnityEngine;

namespace CharacterStatistics
{
    /// <summary>
    ///     <para>
    ///         A baseline for all player classes
    ///     </para>
    ///
    ///     <para>
    ///         Author(s): Num0Programmer
    ///     </para>
    /// </summary>
    [CreateAssetMenu( fileName = "DefaultClass", menuName = "Character/New Class" )]
    public class CharacterClass : ScriptableObject
    {
        [Header( "NAME" )]

        /// <summary>
        ///     <para>
        ///         The name of this class
        ///     </para>
        /// </summary>
        public string className = "Default";

        [Header( "STATISTICS" )]

        /// <summary>
        ///     <para>
        ///         The amount of health (hit points) the player will start out with
        ///         when playing as this class
        ///     </para>
        /// </summary>
        public int classHealth = 100;

        /// <summary>
        ///     <para>
        ///         The amount of armor (armor points) the player will start out
        ///         with when player as this class
        ///     </para>
        /// </summary>
        public int classArmor = 0;

        /// <summary>
        ///     <para>
        ///         Used in modifying how much damage dealt by a weapon
        ///     </para>
        /// </summary>
        public int damageModifier = 0;

        /// <summary>
        ///     <para>
        ///         Determines how fast the player will move when playing as this
        ///         class
        ///     </para>
        /// </summary>
        public float moveSpeed = 10.000000f;
    }
}