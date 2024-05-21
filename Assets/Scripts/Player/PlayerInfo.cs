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

    public static bool LifeSteal = false; //if leech ability
    private static int LifeStealAmnt = 2; //2hp per hit

    public static float DmgReduction = 0f;


    //base damage for left clicking mobs
    public static int BaseDamage = 5;
    public static float PlayerSpeed = 4f;


    //player abilities
    public static string Ability1 = null;
    public static string Ability2 = null;
    public static string Ability3 = null;


    public static Ability ability1 = null;
    public static Ability ability2 = null;
    public static Ability ability3 = null;

    //once it hits 6, next level is boss fight
    public static int levelsGoneThrough = 1;

    //this is for the end screen to show different things
    //Died or Won
    public static bool victory = false;


    //fix this later
    public static void ResetToDefault()
    {
        CurrentHealth = 100;
        MaxHealth = 100;
        CurrentXP = 0;
        MaxXP = 100;
        level = 1;

        LifeSteal = false;
        LifeStealAmnt = 2;
        DmgReduction = 0f;

        BaseDamage = 5;
        PlayerSpeed = 4f;

        Ability1 = null;
        Ability2 = null;
        Ability3 = null;

        ability1 = null;
        ability2 = null;
        ability3 = null;

        levelsGoneThrough = 1;

        victory = false;


    }


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
        int choice = rnd.Next(1, 3); //random between 1 and 2


        switch (choice)
        {
            case 1:
                int bonusHealth = rnd.Next(1, 6); //random number between 1 and 5
                CurrentHealth += bonusHealth;
                MaxHealth += bonusHealth;
                break;
            case 2:
                int bonusSpeed = rnd.Next(200, 600);
                float bnsSpeed = ((float)(bonusSpeed) / 1000f);
                PlayerSpeed += bnsSpeed;
                break;
        }
        
    }

    public static void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
    }

    //This is called when an enemy is hit. It allows the game to know 
    // how much to heal the player if he has leech
    public static void DamageDoneToEnemy(int amount)
    {
        if (LifeSteal)
        {
            Heal(LifeStealAmnt);
        }
    }
}
