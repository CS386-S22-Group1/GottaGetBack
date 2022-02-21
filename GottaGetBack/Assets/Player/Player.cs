using UnityEngine;

/// <summary>
///     <para>
///         Handles/is the route for all actions related to updating player
///         attributes, such as updating the player's current health
///     </para>
/// 
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
public class Player : Character
{
    [Header( "CLASS" )]

    /// <summary>
    ///     <para>
    ///         The class this character will be acting in accordance
    ///     </para>
    /// </summary>
    [SerializeField]
    protected Class characterClass;

    private void Start()
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
}
