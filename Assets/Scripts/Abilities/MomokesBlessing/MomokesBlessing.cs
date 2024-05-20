using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Momokes Blessing Ability", menuName = "Abilities/Momokes Blessing")]
public class MomokesBlessing : Ability
{
    public float BuffDuration = 5f;
    public float DmgReduction = 0.75f; //75%

    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");

        PlayerInfo.DmgReduction += DmgReduction;
        ResetDmgReduction(BuffDuration);
    }



    private IEnumerator ResetDmgReduction(float duration)
    {
        yield return new WaitForSeconds(duration);
        PlayerInfo.DmgReduction -= DmgReduction;
    }
}
