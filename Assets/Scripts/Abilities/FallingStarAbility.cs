using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New FallingStarAbility", menuName = "Abilities/FallingStar")]
public class FallingStarAbility : Ability
{
     protected override void Activate()
    {
        Debug.Log("FALLING STAR USED!!!");
    }
}
