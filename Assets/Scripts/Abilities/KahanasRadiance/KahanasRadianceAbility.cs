using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Kahanas Radiance Ability", menuName = "Abilities/Kahanas Radiance")]
public class KahanasRadianceAbility : Ability
{
    public float damageAmount = 10f;
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");

        //hit enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if(enemyScript != null)
            {
                enemyScript.TakeDamage(damageAmount);
            }
        }


        //hit boss
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if(boss != null)
        {
            boss.GetComponent<Boss>().TakeDamage(damageAmount);
        }
    }
}
