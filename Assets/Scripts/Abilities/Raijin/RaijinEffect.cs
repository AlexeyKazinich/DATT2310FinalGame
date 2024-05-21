using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaijinEffect : MonoBehaviour
{
    private float radius;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stun and hit the enemy
        if(collision.gameObject.tag == "Enemy")
        {
            if(collision != null)
            {
                collision.GetComponent<Enemy>().WasStuned(2f);
                collision.GetComponent<Enemy>().TakeDamage(1f);
            }
        }
    }

    public void Initialize(float duration, float radius)
    {
        this.radius = radius;
        gameObject.transform.localScale.Set(radius,radius,1);
        Destroy(gameObject,duration);
    }

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(radius,radius,1);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = GameObject.Find("Player").GetComponent<Transform>().position;
    }
}
