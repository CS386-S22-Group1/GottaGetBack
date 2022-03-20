using Unity.Netcode;
using UnityEngine;
using CharacterStatistics;

/// <summary>
///     <para>
///         A baseline for all characters (actors) within the game
///     </para>
///     
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
public class Character : NetworkBehaviour
{
    [Header( "CHARACTER CLASS" )]

    /// <summary>
    ///     <para>
    ///         Class this character is
    ///     </para>
    /// </summary>
    [SerializeField]
    private CharacterClass characterClass;


    [Header( "CURRENT STATS" )]

    /// <summary>
    ///     <para>
    ///         Current hit points player retains
    ///     </para>
    /// </summary>
    [SerializeField]
    protected int currentHealth;

    /// <summary>
    ///     <para>
    ///         Current armor points player retains
    ///     </para>
    /// </summary>
    [SerializeField]
    protected int currentArmor;


    private void Awake()
    {
        currentHealth = characterClass.classHealth;
        currentArmor = characterClass.classArmor;
    }

    private void Update()
    {
        if ( currentHealth <= 0 )
        {
            Die();
        }
    }

    /// <summary>
    ///     <para>
    ///         If this character's current health reaches 0 or below, this
    ///         object will be removed from the game scene
    ///     </para>
    /// </summary>
    protected virtual void Die()
    {
        Destroy( gameObject );
    }

    /// <summary>
    ///     <para>
    ///         Gives the current armor of this character
    ///     </para>
    /// </summary>
    /// 
    /// <returns>
    ///     The remaining hit points of this character
    /// </returns>
    public int GetArmor()
    {
        return currentArmor;
    }

    /// <summary>
    ///     <para>
    ///         Gives the current health of this character
    ///     </para>
    /// </summary>
    /// 
    /// <returns>
    ///     The remaining hit points of this character
    /// </returns>
    public int GetHealth()
    {
        return currentHealth;
    }

    /// <summary>
    ///     <para>
    ///         Updates player's current armor according incoming value
    ///     </para>
    ///
    ///     <para>
    ///         Note:
    ///         
    ///         <para>
    ///             send a negative number for armor decrease;
    ///         </para>
    ///         <para>
    ///             send a positive number for armor increase
    ///         </para>
    ///     </para>
    /// </summary>
    /// 
    /// <param name="armorCtrl">
    ///     Amount that will be added to currentArmor
    /// </param>
    public void UpdateArmor( int armorCtrl )
    {
        currentArmor += armorCtrl;
    }

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
}
