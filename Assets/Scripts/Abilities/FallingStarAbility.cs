using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New FallingStarAbility", menuName = "Abilities/FallingStar")]
public class FallingStarAbility : Ability
{
    public GameObject aoePrefab;
    public float radius = 5f;
    public float duration = 3f;
     protected override void Activate()
    {
        Debug.Log("FALLING STAR USED!!!");
        if (Camera.main == null) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // Distance from the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);


        //Instantiate the AOE effect at the mouse position
        GameObject aoeInstance = Instantiate(aoePrefab,worldPosition,Quaternion.identity);
        aoeInstance.GetComponent<FallingStarEffect>().Initialize(duration, radius);

    }
}
