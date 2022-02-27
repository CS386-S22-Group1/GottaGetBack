using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Provides a basic spawning system; provides a wave spawning rate by
///     default
/// 
///     Author: Num0Programmer
/// </summary>
public class Spawner : MonoBehaviour
{
    [Header( "WAVE CONTROL" )]

    /// <summary>
    ///     The minimum amount of zombies that can spawn at the start of a wave
    /// </summary>
    [SerializeField]
    private int MIN_ENEMIES = 1;

    /// <summary>
    ///     The maximum amount of zombies that can spawn at the start of a wave
    /// </summary>
    [SerializeField]
    private int MAX_ENEMIES = 10;

    /// <summary>
    ///     Amount of time from when the last zombie is destroyed to when a new
    ///     wave of zombies is spawned
    /// </summary>
    [SerializeField]
    private float TIME_TO_NEXT_WAVE = 15f;

    /// <summary>
    ///     Tracks the number of waves the player has completed
    /// </summary>
    [SerializeField]
    private int waveCount = 0;

    /// <summary>
    ///     Identifies when the player has killed the last zombie of the wave
    /// </summary>
    private bool waveJustEnded;

    /// <summary>
    ///     List of GameObject references to each zombie that is active in the scene
    /// </summary>
    [SerializeField]
    private List<GameObject> enemiesActive;


    [Header( "ENEMY SPAWNING" )]

    /// <summary>
    ///     Transform components of each zombie spawn point
    /// </summary>
    [SerializeField]
    private Transform[] enemySpawners;

    /// <summary>
    ///     Enemy prefab
    /// </summary>
    [SerializeField]
    private GameObject enemyPrefab;
    

    [Header( "TIMERS" )]

    /// <summary>
    ///     Maintains the time between waves
    /// </summary>
    [SerializeField]
    private float _nextWaverTimer;

    private void Start()
    {
        _nextWaverTimer = TIME_TO_NEXT_WAVE;

        waveJustEnded = true;
    }

    private void Update()
    {
        _nextWaverTimer -= Time.deltaTime;

        if ( _nextWaverTimer <= 0.000000f )
        {
            InitializeWave();
        }
        else if ( enemiesActive.Count > 0 )
        {
            _nextWaverTimer = TIME_TO_NEXT_WAVE;
        }
        else if ( !waveJustEnded )
        {
            waveJustEnded = true;
        }

        UpdateActiveEnemies();
    }

    /// <summary>
    ///     Spawns zombies and updates variables related to waves in progress;
    ///     also reset weaponWasSpawned
    /// </summary>
    private void InitializeWave()
    {
        waveCount++;

        SpawnEnemies( MIN_ENEMIES, MAX_ENEMIES);

        _nextWaverTimer = TIME_TO_NEXT_WAVE;

        waveJustEnded = false;
    }

    /// <summary>
    ///     Spawns a new wave of enemies
    /// </summary>
    /// 
    /// <param name="low_count">
    ///     integer minimum number of enemies to spawn
    /// </param>
    /// 
    /// <param name="high_count">
    ///     integer maximum number of enemies to spawn
    /// </param>
    private void SpawnEnemies( int low_count, int high_count )
    {
        int numZomebies = Random.Range( low_count, high_count );

        Transform spawner;

        for ( int enemiesSpawned = 0; enemiesSpawned < numZomebies;
              enemiesSpawned++ )
        {
            spawner = enemySpawners[ Random.Range( 0, enemySpawners.Length ) ];

            enemiesActive.Add( Instantiate( enemyPrefab, spawner.position,
                                            spawner.rotation, spawner.parent ) );
        }
    }

    /// <summary>
    ///     Updates enemiesActive list when a zombie is destroyed
    ///     
    ///     Note: called by the zombies themselves
    /// </summary>
    /// 
    /// <param name="enemy">
    ///     GameObject reference to the zombie that will be destroyed
    /// </param>
    public void UpdateActiveEnemies()
    {
        foreach( GameObject enemy in enemiesActive )
        {
            if ( enemy == null )
            {
                enemiesActive.Remove( enemy );
            }
        }
    }
}
