using Unity.Netcode;
using UnityEngine;

/// <summary>
///     <para>
///         Baseline for all items the player can use (i.e. wear, hold, collect)
///     </para>
///
///     <para>
///         Author(s): Num0Programmer
///     </para>
/// </summary>
public class Item : NetworkBehaviour
{
    [Header( "EQUPPED STATUS")]

    /// <summary>
    ///     <para>
    ///         Identifies if the player is currently wearing/holding this item
    ///     </para>
    /// </summary>
    [SerializeField]
    protected bool equipped = false;
}
