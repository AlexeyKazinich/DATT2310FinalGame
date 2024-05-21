using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IgnisBladeEffect : MonoBehaviour
{
    private float DamageAmount;
    private float Duration;
   public void startEffect(float DamageAmount, float Duration)
    {
        this.DamageAmount = DamageAmount;
        this.Duration = Duration;
        InvokeRepeating(nameof(BurnEnemies), 0f, 1f); //start burning every 1sec
        CoroutineRunner.Instance.RunCoroutine(CancelBurnEffect()); //cancel after 5sec
    }

    private void BurnEnemies()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject != null)
            {
                gameObject.GetComponent<Enemy>().TakeDamage(DamageAmount);
            }
        }
    }


    private IEnumerator CancelBurnEffect()
    {
        yield return new WaitForSeconds(Duration);
        CancelInvoke(nameof(BurnEnemies));
    }
}
