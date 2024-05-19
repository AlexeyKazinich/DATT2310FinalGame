using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Kemens Presence Ability", menuName = "Abilities/Kemens Presence")]
public class KemensPresenceAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }
}
