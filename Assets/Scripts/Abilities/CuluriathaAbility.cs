using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Culuriatha Ability", menuName = "Abilities/Culuriatha")]
public class CuluriathaAbility : Ability
{
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
    }
}
