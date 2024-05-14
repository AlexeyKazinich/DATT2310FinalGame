using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Mistral Breath Ability", menuName = "Abilities/MistralBreath")]
public class MistralBreath : Ability
{
    protected override void Activate()
    {
        Debug.Log("Mistral Breath USED!!!");
    }
}
