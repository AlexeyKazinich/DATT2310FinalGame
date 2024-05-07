using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 10;

    [SerializeField] float moveSpeed = 0.2f;
    
    [SerializeField] float damage = 10;

    //moving enemy to the player
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;

    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damageAmount)
    {
        this.health -= damageAmount;
        healthBar.UpdateHealthBar(health,maxHealth);
        if(this.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject.Find("Player").GetComponent<Player>().updateXP(35);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            moveDirection = direction;
        }

        
    }


    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //start after 1sec, and hit every 2sec
            InvokeRepeating(nameof(HitPlayer), 1f, 2f);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke();
    }

    private void HitPlayer()
    {
        GameObject.Find("Player").GetComponent<Player>().TakeDamage(damage);
    }
}
