using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health, maxHealth = 30f;
    private float moveSpeed = 1.0f;
    private float damage = 10;

    private int xpWorth = 35;

    //moving enemy to the player
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;
    [SerializeField] FloatingHealthBar healthBar;


    //slow down the animation
    private int animSpeed = 3;
    private int animCounter = 0;

    private bool stunned = false; //cant hit or move
    private bool immobolized = false; //cant move

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
        PlayerInfo.DamageDoneToEnemy((int)damageAmount); //change player Hp to float
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
        WasStuned(2f); //stun when spawns
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
        if (target && !stunned && !immobolized)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        AnimateSprite();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !stunned)
        {
            //start after 1sec, and hit every 2sec
            InvokeRepeating(nameof(HitPlayer), 0f, 1f);
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



    //cant move or attack
    public void WasStuned(float duration)
    {
        stunned = true;
        CoroutineRunner.Instance.RunCoroutine(RemoveStunAfterDuration(duration));
    }

    //stops enemy from moving but can attack
    public void WasImmobolized(float duration)
    {
        immobolized = true;
        CoroutineRunner.Instance.RunCoroutine(RemoveImmobolizeAfterDuration(duration));
    }

    private IEnumerator RemoveStunAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        stunned = false;
    }

    private IEnumerator RemoveImmobolizeAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        immobolized = false;
    }
}
