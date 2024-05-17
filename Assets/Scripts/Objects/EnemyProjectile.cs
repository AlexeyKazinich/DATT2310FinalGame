using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
     public float Speed = 0.1f;

    // for projectile
    public float lifeSpan = 3f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private Camera mainCamera;
    //private Vector3 enemy;
    private Transform target;
    private Transform enemy;
    private float damage = 5;
    private void Awake()
    {
        

        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        /*
        if(target != null){
            Vector3 direction = target.transform.position - enemy.transform.position;

            rb.velocity = new Vector2(direction.x, direction.y).normalized * Speed;
        }
        */
        enemy = GameObject.Find("RangeEnemy").transform;
        target = GameObject.Find("Player").transform;
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.Find("RangeEnemy").GetComponent<Collider2D>());

        Vector3 direction = target.transform.position - enemy.transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * Speed;
        // added
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ignore if the bullet hits the player, hurt enemy, die if hits anything else
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
    {
    }
}
