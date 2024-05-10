using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject lockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AreThereMoreEnemies();
    }

    public bool AreThereMoreEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0){

            GameObject lockObstacle = GameObject.FindGameObjectWithTag("Lock");

            if(lockObstacle != null){
                print("no more enemies, lock should be disabled");
                Destroy(lockObstacle);
            }
            
            return false;
        }
        return true;
    }
}
