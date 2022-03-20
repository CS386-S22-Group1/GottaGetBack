using UnityEngine;
using EnemyManagement;

namespace Enemy
{
    public class Enemy : Character
    {
        protected override void Die()
        {
            Debug.Log( "Enemies left in wave: " + NetworkSpawner.enemiesLeftInWave );

            NetworkSpawner.enemiesLeftInWave--;

            Debug.Log( "Enemies left in wave now: " + NetworkSpawner.enemiesLeftInWave );

            base.Die();
        }
    }
}