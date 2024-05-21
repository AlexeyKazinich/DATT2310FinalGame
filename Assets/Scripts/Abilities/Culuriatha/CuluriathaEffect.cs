using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuluriathaEffect : MonoBehaviour
{
    private float speedReduction;
    private float duration;
    public void StartEffect(float speedReduction, float duration)
    {
        this.speedReduction = speedReduction;
        this.duration = duration;
        ReduceEnemySpeed();
        CoroutineRunner.Instance.RunCoroutine(CancelSpeedReduction()); //cancel effect

    }


    private IEnumerator CancelSpeedReduction()
    {
        yield return new WaitForSeconds(this.duration);
        RestoreEnemySpeed();
    }

    private void ReduceEnemySpeed()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject gameObject in gameObjects)
        {
            if(gameObject != null)
            {
                gameObject.GetComponent<Enemy>().SetMoveSpeed(1f - speedReduction);
            }
        }
    }

    private void RestoreEnemySpeed()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject != null)
            {
                gameObject.GetComponent<Enemy>().SetMoveSpeed(1f);
            }
        }
    }


}
