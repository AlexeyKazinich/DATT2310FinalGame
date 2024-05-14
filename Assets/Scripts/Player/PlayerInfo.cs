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


    //base damage for left clicking mobs
    public static int BaseDamage = 5;


    //player abilities
    public static string Ability1 = null;
    public static string Ability2 = null;
    public static string Ability3 = null;


    public static Ability ability1;
    public static Ability ability2;
    public static Ability ability3;




    public static void addXP(int xp)
    {
        CurrentXP += xp;
        if(CurrentXP >= MaxXP)
        {
            CurrentXP -= MaxXP;
            MaxXP = ((int)(MaxXP*1.3)); //30% increase to max xp every level
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
