using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 10;

    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
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
        GameObject.Find("Player").GetComponent<Player>().updateXP(15);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(1);
    }
}
