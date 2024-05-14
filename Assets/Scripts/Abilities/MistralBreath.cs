using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Mistral Breath Ability", menuName = "Abilities/MistralBreath")]
public class MistralBreath : Ability
{
    public float damageAmount = 6f;
    protected override void Activate()
    {
        //hurt all enemies with tag "enemy"
        Debug.Log("Mistral Breath USED!!!");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if(enemyScript != null)
            {
                enemyScript.TakeDamage(damageAmount);
            }
        }
    }
}
