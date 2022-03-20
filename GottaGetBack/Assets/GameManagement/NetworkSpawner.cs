using Unity.Netcode;
using UnityEngine;

namespace EnemyManagement
{
    public class NetworkSpawner : NetworkBehaviour
    {
        [Header( "WAVE SPAWNING INFORMATION" )]

        /// <summary>
        ///     <para>
        ///         Minimum number of enemies to be spawned in a wave
        ///     </para>
        /// </summary>
        [SerializeField]
        private int minEnemies = 1;

        /// <summary>
        ///     <para>
        ///         Maximum number of enemies to be spawned in a wave
        ///     </para>
        /// </summary>
        [SerializeField]
        private int maxEnemies = 3;

        /// <summary>
        ///     <para>
        ///         Time, in seconds, between the end of one wave, and the
        ///         beginning of the next
        ///     </para>
        /// </summary>
        [SerializeField]
        private float timeBetweenWaves = 5.000000f;

        /// <summary>
        ///     <para>
        ///         Number of enemies left until this wave is considered to be
        ///         finished
        ///     </para>
        /// </summary>
        public int enemiesLeftInWave = 0;


        [Header( "ENEMY SPAWNING INFORMATION" )]

        /// <summary>
        ///     <para>
        ///         NetworkObject component connected to the asset designated as
        ///         the enemy
        ///     </para>
        /// </summary>
        [SerializeField]
        private NetworkObject networkEnemyPrefab;

        /// <summary>
        ///     <para>
        ///         Transforms of specified spawn points where enemies will be
        ///         placed into the world space
        ///     </para>
        /// </summary>
        [SerializeField]
        private Transform[] networkSpawnPoints;


        [Header( "TIMERS" )]

        /// <summary>
        ///     <para>
        ///         Time left until the next wave begins
        ///     </para>
        /// </summary>
        [SerializeField]
        private float timeUntilNextWave = 0.000000f;


        private void Start()
        {
            timeUntilNextWave = timeBetweenWaves;
        }

        private void Update()
        {
            // extra control to ensure that this object is only working on the
            // server; this object should not be spawned in on any client instances
            if ( !IsServer ) return;

            if ( enemiesLeftInWave == 0 )
            {
                timeUntilNextWave -= Time.deltaTime;
            }

            if ( timeUntilNextWave <= 0.000000f )
            {
                InitializeWave();
            }
        }

        /// <summary>
        ///     <para>
        ///         Spawns a random amount of enemies on the map, and sets
        ///         enemiesLeftInWave
        ///     </para>
        /// </summary>
        private void InitializeWave()
        {
            int numEnemiesToSpawn = Random.Range( minEnemies, maxEnemies );

            int enemiesSpawned = 0;

            while ( enemiesSpawned < numEnemiesToSpawn )
            {
                SpawnEnemy();

                enemiesSpawned++;
            }

            enemiesLeftInWave = enemiesSpawned + 1;

            timeUntilNextWave = timeBetweenWaves;
        }

        /// <summary>
        ///     <para>
        ///         Chooses a spawn point, at random, to spawn an enemy at, and 
        ///     </para>
        /// </summary>
        private void SpawnEnemy()
        {
            // choose an index in the networkSpawnPoints array
            int chosenSpawnerIndex = Random.Range( 0, networkSpawnPoints.Length );

            // save that spawner's transform
            Transform chosenSpawnPoint = networkSpawnPoints[ chosenSpawnerIndex ];

            NetworkObject networkEnemyInstance = Instantiate( networkEnemyPrefab, chosenSpawnPoint );

            // Spawn this enemy object on all clients
            networkEnemyInstance.Spawn();
        }
    }
}
