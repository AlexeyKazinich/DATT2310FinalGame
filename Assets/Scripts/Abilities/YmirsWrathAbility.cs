using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ymirs Wrath Ability", menuName = "Abilities/Ymirs Wrath")]
public class YmirsWrathAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }
}
