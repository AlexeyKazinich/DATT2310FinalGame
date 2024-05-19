using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ignis Blade Ability", menuName = "Abilities/IgnisBlade")]
public class IgnisBladeAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log("Ignis Blade USED!!!");
    }

    
}
