using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWindow : MonoBehaviour
{
    [SerializeField] Ability ability;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Ability GetAbility()
    {
        return ability;
    }

    public void SetAbility(Ability ability)
    {
        this.ability = ability;
    }
}
