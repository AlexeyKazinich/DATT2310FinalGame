using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Shus Shoes Ability", menuName = "Abilities/ShusShoes")]
public class ShusShoesAbility : Ability
{
    private float speedBoost = 3f;
    private float boostDuration = 4f;
    protected override void Activate()
    {
        Debug.Log("ShusShoes USED!!!");

        float originalSpeed = PlayerInfo.PlayerSpeed;
        PlayerInfo.PlayerSpeed += speedBoost;
        CoroutineRunner.Instance.RunCoroutine(ResetSpeedAfterDuration(originalSpeed, boostDuration));

    }


    private IEnumerator ResetSpeedAfterDuration(float originalSpeed, float duration)
    {
        yield return new WaitForSeconds(duration);
        PlayerInfo.PlayerSpeed = originalSpeed;
    }
}
