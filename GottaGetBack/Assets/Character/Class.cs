using UnityEngine;

/// <summary>
///     <para>
///         A baseline for all player classes
///     </para>
///
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
[CreateAssetMenu( fileName = "DefaultClass", menuName = "New Class" )]
public class Class : ScriptableObject
{
    /// <summary>
    ///     <para>
    ///         The name of this class
    ///     </para>
    /// </summary>
    public string className = "";

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
    ///         Determines how fast the player will move when playing as this
    ///         class
    ///     </para>
    /// </summary>
    public float moveSpeed = 20.000000f;

    /// <summary>
    ///     <para>
    ///         Determines how fast the player will reach their moveSpeed when
    ///         player as this class
    ///     </para>
    /// </summary>
    public float acceleration = 50.000000f;
}