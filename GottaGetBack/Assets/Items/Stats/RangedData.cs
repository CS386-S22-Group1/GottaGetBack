using UnityEngine;

/// <summary>
///     <para>
///         Holds the statistics for a ranged weapon's behavior
///     </para>
///
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
[CreateAssetMenu( fileName = "Default Ranged", menuName = "Items/New Ranged")]
public class RangedData : ScriptableObject
{
    /// <summary>
    ///     <para>
    ///         This weapon's name
    ///     </para>
    /// </summary>
    public string rangedName = "Default Ranged";

    /// <summary>
    ///     <para>
    ///         Amount of shots this weapon can take before reloading
    ///     </para>
    /// </summary>
    public int magazineSize = 1;

    /// <summary>
    ///     <para>
    ///         Identifies if this ranged weapon is automatic
    ///     </para>
    /// </summary>
    public bool isAutomatic = false;

    /// <summary>
    ///     <para>
    ///         Number of birdshot launched by this weapon
    ///     </para>
    ///
    ///     <para>
    ///         Notes:
    ///         <list type="bullet">
    ///             Used in simulating a shotgun
    ///         </list>
    ///     </para>
    /// </summary>
    public int roundsPerShot = 1;

    /// <summary>
    ///     <para>
    ///         Used in determining the accuracy of this weapon
    ///     </para>
    /// </summary>
    public float spread = 0.000000f;

    /// <summary>
    ///     <para>
    ///         Length of time it takes to switch to a full magazine
    ///     </para>
    ///
    ///     <para>
    ///         Notes:
    ///         <list type="bullet">
    ///             Defined in seconds
    ///         </list>
    ///     </para>
    /// </summary>
    public float reloadSpeed = 1.000000f;

    /// <summary>
    ///     <para>
    ///         Length of time between one shot and another being launched
    ///     </para>
    ///
    ///     <para>
    ///         Notes:
    ///         <list type="bullet">
    ///             Defined in seconds
    ///         </list>
    ///     </para>
    /// </summary>
    public float fireRate = 1.00000f;

    /// <summary>
    ///     <para>
    ///         Projectile to be launched
    ///     </para>
    ///
    ///     <para>
    ///         Notes:
    ///         <list type="bullet">
    ///             Is a GameObject Prefab
    ///         </list>
    ///     </para>
    /// </summary>
    public GameObject ammunition;
}
