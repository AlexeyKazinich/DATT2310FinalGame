using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAOEEffect : MonoBehaviour
{
    private float damage = 20f;
    private float radius;
    private string playerTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(radius * 2, radius * 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Initialize(float duration, float radius)
    {
        this.radius = radius;
        gameObject.transform.localScale.Set(radius, radius, 1);
        CoroutineRunner.Instance.RunCoroutine(HitPlayerAfterDuration(duration));
    }

    private IEnumerator HitPlayerAfterDuration(float duration)
    {
        //wait
        yield return new WaitForSeconds(duration);


        //hit
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(var hitCollider in colliders)
        {
            if (hitCollider.CompareTag(playerTag))
            {
                Player player = hitCollider.gameObject.GetComponent<Player>();
                if(player != null)
                {
                    player.TakeDamage(this.damage);
                }
            }
        }

        Destroy(gameObject);
    }
}
