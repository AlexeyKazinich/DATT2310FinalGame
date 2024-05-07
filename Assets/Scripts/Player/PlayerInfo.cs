using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //these are just defaults
    public static int CurrentHealth = 15;
    public static int MaxHealth = 15;
    public static int CurrentXP = 0;
    public static int MaxXP = 100;
    public static int level = 1;



    public static void addXP(int xp)
    {
        CurrentXP += xp;
        if(CurrentXP >= MaxXP)
        {
            CurrentXP -= MaxXP;
            level++;
        }
    }
}
