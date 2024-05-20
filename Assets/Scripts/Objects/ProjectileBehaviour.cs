using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;

    // for projectile
    public float lifeSpan = 3f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private Camera mainCamera;
    private Vector3 mousePos;

    private void Awake()
    {
        

        
    }
    private void Start()
    {
        //shoot where the mouse is
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());

        Vector3 direction = mousePos - transform.position;
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
            return;
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(PlayerInfo.BaseDamage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().TakeDamage(PlayerInfo.BaseDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }

    private void FixedUpdate()
    {
    }
}
