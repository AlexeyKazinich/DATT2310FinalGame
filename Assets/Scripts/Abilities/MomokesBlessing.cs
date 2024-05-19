using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Momokes Blessing Ability", menuName = "Abilities/Momokes Blessing")]
public class MomokesBlessing : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }
}
