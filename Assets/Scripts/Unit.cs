using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum type {ENEMY, PLAYER, BOSS };
public class Unit : MonoBehaviour
{
    public int ID;
    public string Unit_Name;
    public int Unit_Level;
    public int Unit_Max_Hp;
    public int Unit_Current_Hp;
    public int Unit_Max_Mp;
    public int Unit_Current_Mp;
    public int Unit_Atk;
    public int Unit_Def;
    public int Unit_Speed;
    public int Unit_Int;
    public int Current_Exp;
    public int Exp_Value; //Enemy_Only
    public Skills[] Unit_Skill;

    public Skills[] All_Skills;
    public type type;
    public Text Skill_Name_1;
    public Text Skill_Name_2;
    public Text Skill_Name_3;
    public Text Skill_Name_4;
    public Text Skill_Name_5;
    public Text Skill_Name_6;
    public Text Skill_Name_7;
    public Text Skill_Name_8;
    /*
     Text Skill_Type;
     Text Skill_Description; */
    int Skill_id;


    public bool TakeDamage(int Unit_Atk)
    {
        Unit_Current_Hp -= Unit_Atk;

        if(Unit_Current_Hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Give_Skills(int x)
    {
        int y = 0;
        int z;
        while(Unit_Skill[y].id != 0 && y < 8)
        {
            y = y + 1;
        }
        if(Unit_Skill[y].id == 0)
        {
            x = All_Skills[x].id;
            Unit_Skill[y] = All_Skills[x];
            return true;
        }
        else
        {
           
            return false;
        }
    }

    public void Set_Skills()
    {
        Skill_Name_1.text = Unit_Skill[0].Skill_Name;
        Skill_Name_2.text = Unit_Skill[1].Skill_Name;
        Skill_Name_3.text = Unit_Skill[2].Skill_Name;
        Skill_Name_4.text = Unit_Skill[3].Skill_Name;
        Skill_Name_5.text = Unit_Skill[4].Skill_Name;
        Skill_Name_6.text = Unit_Skill[5].Skill_Name;
        Skill_Name_7.text = Unit_Skill[6].Skill_Name;
        Skill_Name_8.text = Unit_Skill[7].Skill_Name;

    }

    public void Use_Skill(int x)
    {
        Unit_Current_Hp -= Unit_Skill[x].Skill_Damage;
        if(Unit_Current_Hp > Unit_Max_Hp)
        {
            Unit_Current_Hp = Unit_Max_Hp;
            return;
        }
        

    }

    public void Substract_MP(int x)
    {
        Unit_Current_Mp -= x;
        return;


    }

    public bool Level_up(int x)
    {
        Current_Exp += x;
        if (Current_Exp > 3 && Unit_Level <= 1)
        {
            Unit_Level += 1;
            Unit_Max_Hp += 1;
            Unit_Current_Hp = Unit_Max_Hp;
            Unit_Max_Mp += 1;
            Unit_Current_Mp = Unit_Max_Mp;
            Unit_Atk += 1;
            Unit_Def += 1;
            Unit_Speed += 1;
            Unit_Int += 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}
