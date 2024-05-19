using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Sovamorcos Form Ability", menuName = "Abilities/Sovamorcos Form")]
public class SovamorcosFormAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }
}
