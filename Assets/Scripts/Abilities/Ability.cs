using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string AbilityName = "NYI"; //name
    public int Cooldown; //how long it should be on cooldown for
    public Sprite AbilityIcon; //icon

    public string AbilityDescription = "NYI";

    private float cooldownTimer = 0; // Timer to track cooldown


    protected abstract void Activate();


    public bool IsReady()
    {
        return cooldownTimer <= 0;
    }

    //Method to activate the ability
    public void TryActivate()
    {
        if (IsReady())
        {
            Activate();
            cooldownTimer = Cooldown;
        }
        else
        {
            Debug.Log($"{AbilityName} is on cooldown");
        }
    }

    public void CooldownUpdate(float deltaTime)
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= deltaTime;
        }
    }
}
