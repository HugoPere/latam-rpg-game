using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills_All : MonoBehaviour
{
    Skills[] All_Skill;
    // Start is called before the first frame update
    void Start()
    {
        All_Skill[0].id = 1;
        All_Skill[0].Skill_Name = "Fire 1";
        All_Skill[0].Skill_Description = "Low fire damage";
        All_Skill[0].Skill_type = "Spell";
        All_Skill[0].Skill_Damage = 5;
        
    }

   
}
