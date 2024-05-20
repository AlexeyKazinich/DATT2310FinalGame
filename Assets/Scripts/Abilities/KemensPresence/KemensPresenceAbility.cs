using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Kemens Presence Ability", menuName = "Abilities/Kemens Presence")]
public class KemensPresenceAbility : Ability
{
    private float stunDuration = 4f;
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if(enemyScript != null)
            {
                enemyScript.WasStuned(stunDuration);
            }
        }
    }
}
