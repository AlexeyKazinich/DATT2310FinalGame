using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 30f;
    private float moveSpeed = 1.0f;
    private float damage = 0;

    private int xpWorth = 35;

    //moving enemy to the player
    private Rigidbody2D rb;
    private Transform target;
    public GameObject enemy;
    //private Transform enemy;
    private Vector2 moveDirection;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;
    [SerializeField] FloatingHealthBar healthBar;
    public EnemyProjectile ProjectilePrefab;

    public float maxAttackDistance = 2.5f;
    public float minAttackDistance = 2f;
    public float range = 2.5f;
    private bool isAttacking = false;
    //slow down the animation
    private int animSpeed = 3;
    private int animCounter = 0;

    private float shotsPerSecond = 2f;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        //give xp
        GameObject.Find("Player").GetComponent<Player>().updateXP(xpWorth);

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        //enemy = GameObject.Find("RangeEnemy").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (target != null && enemy != null)
        {
            //Vector3 direction = (target.position - transform.position).normalized;

            //moveDirection = direction;

            float distance = Vector3.Distance(enemy.transform.position, target.transform.position);
            Debug.Log("Distance: " + distance);
            if(distance <= range){
                if(!isAttacking)
                {
                    Debug.Log("Range enemy starts throwing projectile prefab to the player.");
                    InvokeRepeating(nameof(HitPlayer), 0f, 1f / shotsPerSecond);
                    //HitPlayer();
                    isAttacking = true;
                }
                
                
                //Debug.Log("Range enemy starts throwing projectile prefab to the player.");
                //isAttacking = true;
                //start after 1sec, and hit every 2sec
                //Instantiate(ProjectilePrefab, target.transform.position, transform.rotation);
                
            }
            else {
                if(isAttacking){
                    CancelInvoke(nameof(HitPlayer));
                    isAttacking = false;
                }
                
                
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(2);
        }
        /*
        if(target){
            float distance = Vector3.Distance(enemy.transform.position, target.transform.position);
            if(distance >= minAttackDistance && distance <= maxAttackDistance){
                //HitPlayer();
                if(!isAttacking){
                    Debug.Log("Range enemy starts throwing projectile prefab to the player.");
                    isAttacking = true;
                    //start after 1sec, and hit every 2sec
                    InvokeRepeating(nameof(HitPlayer), 0f, 1f);
                }
            }
            else {
                if(isAttacking){
                    isAttacking = false;
                    CancelInvoke(nameof(HitPlayer));
                }
            }
        }
        */
        if(Input.GetKeyDown(KeyCode.M)){
            Instantiate(ProjectilePrefab, enemy.transform.position, transform.rotation);
        }
    }
    public void AnimateSprite(){
        if (rb.velocity.x < 0)
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

        if(spriteIndex >= sprites.Length){
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }

        AnimateSprite();
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //start after 1sec, and hit every 2sec
            InvokeRepeating(nameof(HitPlayer), 0f, 1f);
        }

    }
    */
    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke();
    }

    private void HitPlayer()
    {
        Instantiate(ProjectilePrefab, enemy.transform.position, transform.rotation);


        GameObject player = GameObject.Find("Player");
    }
}
