using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ignis Blade Ability", menuName = "Abilities/IgnisBlade")]
public class IgnisBladeAbility : Ability
{
    private float DamageAmount = 2f;
    private float Duration = 5f;
    public GameObject effect;
    protected override void Activate()
    {
        Debug.Log("Ignis Blade USED!!!");

        //tick all enemies for 5sec 2dmg per sec CD 10sec
        effect.GetComponent<IgnisBladeEffect>().StartEffect(DamageAmount, Duration);
    }


    

    
}
