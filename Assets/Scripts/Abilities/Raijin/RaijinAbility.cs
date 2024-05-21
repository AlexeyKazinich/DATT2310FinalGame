using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Raijin Ability", menuName = "Abilities/Raijin")]
public class RaijinAbility : Ability
{
    public GameObject raijinPrefab;
    public float radius = 2f;
    private float duration = 5f; //5sec
    protected override void Activate()
    {
        Debug.Log(name + " USED!!!");
        //spawn a circle on the palyer that will stun anyone that walks in
        Vector3 playerPos = GameObject.Find("Player").GetComponent<Transform>().position;

        GameObject aoeInstance = Instantiate(raijinPrefab,playerPos,Quaternion.identity);
        aoeInstance.GetComponent<RaijinEffect>().Initialize(duration,radius);
    }

    
}
