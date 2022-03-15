using UnityEngine;

public class Player : Character
{
    protected override void Die()
    {
        base.Die();

        GameManager.managerInstance.RespawnMenuOn();
    }
}
