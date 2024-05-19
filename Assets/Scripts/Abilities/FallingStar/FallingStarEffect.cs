using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarEffect : MonoBehaviour
{
    public float damage = 2f;
    public float tickRate = 1f;
    private float radius;
    private string enemyTag = "Enemy";

    private float nextTickTime;

    public void Initialize(float duration, float radius)
    {
        this.radius = radius;
        gameObject.transform.localScale.Set(radius, radius, 1);
        nextTickTime = Time.time + tickRate;
        Destroy(gameObject, duration);
    }

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(radius*2, radius*2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTickTime)
        {
            nextTickTime += tickRate;
            TickDamage();
        }
    }

    private void TickDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach(var hitCollider in colliders)
        {
            if (hitCollider.CompareTag(enemyTag))
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if(enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
