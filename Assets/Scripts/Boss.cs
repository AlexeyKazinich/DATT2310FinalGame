using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private float health = 300f, maxHealth = 300f;
    private float moveSpeed = 1f;
    private float damage = 20f;

    private FloatingHealthBar healthBar;


    //animation
    public SpriteRenderer spriteRenderer;
    private int animSpeed = 3;
    private int animCounter = 0;
    public Sprite[] sprites;
    private int spriteIndex = 0;

    private Rigidbody2D rb;


    private Transform target;

    private void Awake()
    {
        healthBar = GameObject.Find("BossHealthBar").GetComponent<FloatingHealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    public void TakeDamage(float damageAmount)
    {
        this.health -= damageAmount;
        healthBar.UpdateHealthBar(health,maxHealth);
        PlayerInfo.DamageDoneToEnemy((int)damageAmount);
        if(this.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //kill boss change scene
        Destroy(gameObject);
        SceneManager.LoadScene(5);
    }

    private void AnimateSprite()
    {
        if(rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if(animCounter == animSpeed)
        {
            spriteIndex++;
            animCounter = 0;
        }
        else
        {
            animCounter++;
        }
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void FixedUpdate()
    {
        AnimateSprite(); 
    }

    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
