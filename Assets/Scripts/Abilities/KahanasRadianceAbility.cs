using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Kahanas Radiance Ability", menuName = "Abilities/Kahanas Radiance")]
public class KahanasRadianceAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }
}
