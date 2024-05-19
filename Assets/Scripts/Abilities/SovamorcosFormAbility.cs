using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Sovamorcos Form Ability", menuName = "Abilities/Sovamorcos Form")]
public class SovamorcosFormAbility : Ability
{
    private float boostDuration = 5f;

    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
        PlayerInfo.LifeSteal = true;
        CoroutineRunner.Instance.RunCoroutine(ResetLeechAfterDuration(boostDuration));
    }

    private IEnumerator ResetLeechAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        PlayerInfo.LifeSteal = false;
    }
}
