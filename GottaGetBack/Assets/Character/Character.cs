using UnityEngine;

/// <summary>
///     <para>
///         A baseline for all characters (actors) within the game
///     </para>
///
///     <para>
///         Note(s):
///         
///         <para>
///             1. Armor update will be added when I am sure that is
///                something we absolutely want and will use
///         </para>
///     </para>
///     
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
public class Character : MonoBehaviour
{
    [Header( "CURRENT STATS" )]

    /// <summary>
    ///     <para>
    ///         Current hit points player retains
    ///     </para>
    /// </summary>
    protected int currentHealth;

    /// <summary>
    ///     <para>
    ///         Current armor points player retains
    ///     </para>
    /// </summary>
    protected int currentArmor;

    /// <summary>
    ///     <para>
    ///         Updates player's current health according incoming value
    ///     </para>
    ///
    ///     <para>
    ///         Note:
    ///         
    ///         <para>
    ///             send a negative number for health decrease;
    ///         </para>
    ///         <para>
    ///             send a positive number for health increase
    ///         </para>
    ///     </para>
    /// </summary>
    /// 
    /// <param name="healthCtrl">
    ///     Amount that will be added to currentHealth
    /// </param>
    public void UpdateHealth( int healthCtrl )
    {
        currentHealth += healthCtrl;
    }

    /// <summary>
    ///     <para>
    ///         If this character's current health reaches 0 or below, this
    ///         object will be removed from the game scene
    ///     </para>
    /// </summary>
    protected void Die()
    {
        Destroy( gameObject );
    }
}
