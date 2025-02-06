using UnityEngine;

public class EnemyDamage : DamageControl
{
    private int _strenghtEnemy = 1;

    protected override void Start()
    {
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        PlayerDamage playerTarget = collision.gameObject.GetComponent<PlayerDamage>();

        if (playerTarget) 
        {
            DealDamage(playerTarget, _strenghtEnemy);
        }
    }
}
