using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Sthiras Protection Ability", menuName = "Abilities/Sthiras Protection")]
public class SthirasProtectionAbility : Ability
{
    public float invincibilityDuration = 2f;
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
        
        
        GameObject.Find("Player").GetComponent<Player>().invincible = true;
        CoroutineRunner.Instance.RunCoroutine(ResetInvincibilityAfterDuration(invincibilityDuration));

    }

    private IEnumerator ResetInvincibilityAfterDuration(float duration)
    {
        yield return new WaitForSeconds(invincibilityDuration);
        GameObject.Find("Player").GetComponent<Player>().invincible = false;
    }
}
