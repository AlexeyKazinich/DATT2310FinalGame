using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Susanoo Ability", menuName = "Abilities/Susanoo")]
public class SusanooAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log("Susanoo USED!!!");
    }
}
