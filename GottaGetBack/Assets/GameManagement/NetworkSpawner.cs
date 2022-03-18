using Unity.Netcode;
using UnityEngine;

public class NetworkSpawner : NetworkBehaviour
{
    [SerializeField]
    private NetworkObject networkSquarePrefab;

    [SerializeField]
    private Transform networkSpawnPoint;

    public void SpawnEnemy()
    {
        if ( IsServer )
        {
            NetworkObject networkSquareInstance = Instantiate( networkSquarePrefab, networkSpawnPoint );

            networkSquareInstance.Spawn();
        }
        else
        {
            Debug.Log( "Beam me up Scottie. She's sucking shit again." );
        }
    }
}
