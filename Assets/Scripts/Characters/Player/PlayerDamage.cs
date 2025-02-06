using UnityEngine;

public class PlayerDamage : DamageControl
{
    private int _strenghtEnemy = 1;

    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDamage playerTarget = collision.gameObject.GetComponent<EnemyDamage>();

        if (playerTarget)
        {
            DealDamage(playerTarget, _strenghtEnemy);
        }
    }
}