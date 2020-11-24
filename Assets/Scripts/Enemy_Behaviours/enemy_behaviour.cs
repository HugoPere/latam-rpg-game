using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public Unit enemy;

    

    public int trigger_HP;
    public int Skill_Counter;

    public void choose_action()
    {
        int enemyHP = enemy.Unit_Current_Hp;
        if (trigger_HP <= enemyHP)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            int selected_skill = Random.Range(0, 2);
            int damage = enemy.Unit_Skill[selected_skill].Skill_Damage;

        }
    }
}
