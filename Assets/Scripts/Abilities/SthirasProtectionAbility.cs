using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Sthiras Protection Ability", menuName = "Abilities/Sthiras Protection")]
public class SthirasProtectionAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }
}
