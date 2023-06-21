using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private float deadDelay = 1.3f;
    private Enemy enemy;

    protected override void Start()
    {
        base.Start();

        enemy = GetComponent<Enemy>();         
    }


    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
    }

    protected override void Die()
    {
        base.Die();

        enemy.Die();
        enemy.fx.CancelColorChange();

        Invoke("DestroyObject", deadDelay);
    }

    private void DestroyObject()
    {      
        Destroy(gameObject);
    }
}
