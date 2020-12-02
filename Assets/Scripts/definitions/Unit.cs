using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum type {ENEMY, PLAYER, BOSS };
public enum personality {PLAYER, AGGRESIVE, TIMID, WISE, CURIOUS, SOLEMN, WILD, SAVAGE, NONSKILL, BOSS } //ENEMY ONLY
//PASSIVE ORIENTED PERSONALITIES
//>TIMID, WISE, CURIOUS, SOLEMN
//AGGRESIVE ORIENTED PERSONALITIES
//>AGGRESIVE, WILD, SAVAGE

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
    public int Unit_Current_Atk;
    public int Unit_Def;
    public int Unit_Current_Def;
    public int Unit_Speed;
    public int Unit_Current_Speed;
    public int Unit_Int;
    public int Unit_Current_Int;
    public int Current_Exp;
    public int exp_to_level_up;
    public int Exp_cap; //Player_Only
    public int Exp_Value; //Enemy_Only
    public personality personality;//Enemy_Only
    //Booleans of stat increases
    

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
   
    int Skill_id;

    //USED ONLY FOR ENEMY
    //Button Texts

    public string peaceful_button_1;
    public string peaceful_button_2;
    

    public string aggresive_button_1;
    public string aggresive_button_2;
    
    //Responses
    public string peaceful_response;
    public string peaceful_button_1_response;
    public string peaceful_button_2_response;
    public string aggresive_response;
    public string aggresive_button_1_response;
    public string aggresive_button_2_response;
    //END


    public bool TakeDamage(int Unit_Atk) //BOTH
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

    public bool Give_Skills(int x) //PLAYER
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

    public void Set_Skills() //PLAYER
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

    public bool Use_Skill(int x) //PLAYER
    {

        if (Unit_Skill[x].Skill_effect == Skill_effect.HEAL)
        {

            Unit_Current_Hp += Unit_Skill[x].Skill_Damage;
            if (Unit_Current_Hp > Unit_Max_Hp)
            {
                Unit_Current_Hp = Unit_Max_Hp;
                
            }
        }
        else if(Unit_Skill[x].Skill_effect == Skill_effect.BUFF)
        {
            if(Unit_Skill[x].Skill_Stat_Target == stat_target.ATTACK)
            {
                
                Unit_Current_Atk = Unit_Current_Atk * Unit_Skill[x].Skill_Damage;
                
            }

            else if (Unit_Skill[x].Skill_Stat_Target == stat_target.DEFENSE)
            {
                Unit_Current_Def =  Unit_Current_Def * Unit_Skill[x].Skill_Damage;
                
            }

            else if (Unit_Skill[x].Skill_Stat_Target == stat_target.INTELLIGENCE)
            {
                Unit_Current_Int = Unit_Current_Def * Unit_Skill[x].Skill_Damage;
                
            }

            else if (Unit_Skill[x].Skill_Stat_Target == stat_target.SPEED)
            {
                Unit_Current_Speed = Unit_Current_Def * Unit_Skill[x].Skill_Damage;
                
            }

        }
        
        if (Unit_Current_Hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }



    }

    public void Substract_MP(int x) //BOTH
    {
        Unit_Current_Mp -= x;
        return;


    }

    public bool Level_up(int x) //PLAYER
    {
        Current_Exp += x;
        if (Current_Exp > exp_to_level_up)
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
            exp_to_level_up = exp_to_level_up * 3;
            return true;
        }
        else
        {
            return false;
        }
    }

    

   
}
