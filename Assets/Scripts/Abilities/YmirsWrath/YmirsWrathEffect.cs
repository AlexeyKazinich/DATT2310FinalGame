using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YmirsWrathEffect : MonoBehaviour
{
    private float damage;

    public void StartEffect(float damage)
    {
        this.damage = damage;
        HitEnemies();
        Destroy(gameObject);

    }


    private void HitEnemies()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position,2f);
        foreach(var hitCollier in collisions)
        {
            if (hitCollier.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollier.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }
}
