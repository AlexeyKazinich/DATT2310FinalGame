using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Ability", menuName = "Boss/AOE 1")]
public class BossAOEAbility : ScriptableObject
{
    public GameObject aoePrefab;
    public float radius = 5f;
    public float duration = 3f;

    public void Activate()
    {
        //player pos
        Vector2 playerPos = GameObject.Find("Player").GetComponent<Transform>().position;

        GameObject aoeInstance = Instantiate(aoePrefab, playerPos, Quaternion.identity);
        aoeInstance.GetComponent<BossAOEEffect>().Initialize(duration, radius);
    }
}
