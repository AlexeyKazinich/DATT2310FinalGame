using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInfo : MonoBehaviour
{
    //these are just defaults
    public static int CurrentHealth = 100;
    public static int MaxHealth = 100;
    public static int CurrentXP = 0;
    public static int MaxXP = 100;
    public static int level = 1;



    public static void addXP(int xp)
    {
        CurrentXP += xp;
        if(CurrentXP >= MaxXP)
        {
            CurrentXP -= MaxXP;
            LevelUp();
        }
    }


    private static void LevelUp()
    {
        level++;

        System.Random rnd = new System.Random();
        int bonusHealth = rnd.Next(1,6); //random number between 1 and 5
        CurrentHealth += bonusHealth;
        MaxHealth += bonusHealth;
    }
}
