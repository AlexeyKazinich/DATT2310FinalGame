using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Culuriatha Ability", menuName = "Abilities/Culuriatha")]
public class CuluriathaAbility : Ability
{
    private float SpeedReduction = 0.7f; //70% slower
    private float duration = 3f; //3sec
    public GameObject effect;
    //CD 10sec
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
        //slow enemies 
        effect.GetComponent<CuluriathaEffect>().StartEffect(SpeedReduction, duration);
    
    }
}
