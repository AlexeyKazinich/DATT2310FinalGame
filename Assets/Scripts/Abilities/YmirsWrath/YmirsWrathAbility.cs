using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ymirs Wrath Ability", menuName = "Abilities/Ymirs Wrath")]
public class YmirsWrathAbility : Ability
{
    private float damageAmount = 9f;
    public GameObject effect;
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
        //when activated explode hitting everyone around the player within a set distance
        Vector3 playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        GameObject aoeInstance = Instantiate(effect,playerPos,Quaternion.identity);
        aoeInstance.GetComponent<YmirsWrathEffect>().StartEffect(damageAmount);

    }
}
