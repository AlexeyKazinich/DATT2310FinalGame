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


    private bool phase1Activated = false; //triggers at 90%
    private bool phase2Activated = false; //triggers at 60%
    private bool phase3Activated = false; //triggers at 30%

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

        //phase check
        if((health / maxHealth) <= 0.3 && !phase3Activated)
        {
            //30%
            phase3Activated = true;
            GameObject.Find("SpawnArea").GetComponent<EnemySpawner>().SpawnEnemies(15);
        }
        else if((health / maxHealth) <= 0.6 && !phase2Activated)
        {
            //60%
            phase2Activated= true;
            GameObject.Find("SpawnArea").GetComponent<EnemySpawner>().SpawnEnemies(10);
        }
        else if((health / maxHealth) <= 0.9 && !phase1Activated)
        {
            //30%
            phase1Activated= true;
            GameObject.Find("SpawnArea").GetComponent<EnemySpawner>().SpawnEnemies(5);
        }
        
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
