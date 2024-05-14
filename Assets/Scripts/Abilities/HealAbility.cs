using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Heal Ability", menuName = "Abilities/Heal")]
public class HealAbility : Ability
{
    private readonly int healAmount = 35;
    protected override void Activate()
    {
        PlayerInfo.Heal(healAmount);
    }

    
}
