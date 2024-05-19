using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Raijin Ability", menuName = "Abilities/Raijin")]
public class RaijinAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }

    
}
