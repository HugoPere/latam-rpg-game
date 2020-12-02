using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public Unit enemy;
    public int trigger_HP;
    public int Skill_Counter;
    int damage;
    public int choose_action()
    {
        int enemyHP = enemy.Unit_Current_Hp;
        if (trigger_HP <= enemyHP || Skill_Counter == 3)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            int selected_skill = Random.Range(0, 2);
            damage = enemy.Unit_Skill[selected_skill].Skill_Damage;
            return damage;

        }
        else
        {
            int damage = enemy.Unit_Atk;
            Skill_Counter +=1;
            return damage;
           
        }
    }
}
