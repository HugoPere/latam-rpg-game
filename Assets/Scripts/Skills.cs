using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum target { ENEMY, SELF, SELF_ALL }

public class Skills : MonoBehaviour
{
    public int id;
    public string Skill_Name;
    public string Skill_Description;
    public string Skill_type;
    public string Skill_Attribute;
    public int Skill_Damage;
    public int Skill_Cost;
    public target Skill_Target;

    public Skills(Skills s)
    {
        id = s.id;
        Skill_Name = s.Skill_Name;
        Skill_Description = s.Skill_Description;
        Skill_type = s.Skill_type;
        Skill_Attribute = s.Skill_Attribute;
        Skill_Damage = s.Skill_Damage;
        Skill_Cost = s.Skill_Cost;
        Skill_Target = s.Skill_Target;
    }

    
}
