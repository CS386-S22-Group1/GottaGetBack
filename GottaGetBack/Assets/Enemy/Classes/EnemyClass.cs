using UnityEngine;
using CharacterStatistics;

/// <summary>
///     <para>
///         Extends the CharacterClass to define any attributes of an enemy that
///         a general character would not have otherwise
///     </para>
///
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
[CreateAssetMenu( fileName = "DefaultEnemy", menuName = "Character/New Enemy" )]
public class EnemyClass : CharacterClass
{
    [Header( "INTELLIGENCE SETTINGS" )]

    /// <summary>
    ///     <para>
    ///         Range the enemy has to be within to attack the player
    ///     </para>
    ///
    ///     <para>
    ///         Note(s):
    ///
    ///         <list type="bullet">
    ///             <item>
    ///                 This will depend upon the weapon and its type the enemy
    ///                 is using
    ///             </item>
    ///         </list>
    ///     </para>
    /// </summary>
    public float attackRange = 2.000000f;

    /// <summary>
    ///     <para>
    ///         Time between attacks
    ///     </para>
    ///
    ///     <para>
    ///         Note: primitive solution; this will probably be affected, or
    ///         traded out for weapon attack speeds later
    ///     </para>
    /// </summary>
    public float attackSpeed = 1.000000f;

    /// <summary>
    ///     <para>
    ///         Defines how long the enemy will focus a player
    ///     </para>
    ///
    ///     <para>
    ///         Note(s):
    ///         
    ///         <list type="bullet">
    ///             <item>
    ///                 Defined in seconds
    ///             </item>
    ///         </list>
    ///     </para>
    /// </summary>
    public float focusInterval = 0.000000f;

    /// <summary>
    ///     <para>
    ///         Distance from target position to stop
    ///     </para>
    /// </summary>
    public float stoppingDistance = 5.000000f;

    /// <summary>
    ///     <para>
    ///         Range of view the enemy can see around them
    ///     </para>
    /// </summary>
    public float viewRange = 10.000000f;
}
