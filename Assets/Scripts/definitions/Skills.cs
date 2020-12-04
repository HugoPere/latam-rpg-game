using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum target { ENEMY, SELF, SELF_ALL }
public enum Skill_effect { ATTACK, HEAL, BUFF}
public enum skill_type { SPELL, SONG, LAND, SUMMON}
public enum stat_target { NONE, ATTACK, DEFENSE, SPEED, INTELLIGENCE};
[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skills : ScriptableObject
{
    public int id;
    public string Skill_Name;
    public string Skill_Description;
    public skill_type type;
    public string Skill_type;
    public string Skill_Attribute;
    public int Skill_Damage;
    public int Skill_Cost;
    public target Skill_Target;
    public Skill_effect Skill_effect;
    public stat_target Skill_Stat_Target;
    /*
    public Skills(Skills s)
    {
        id = s.id;
        Skill_Name = s.Skill_Name;
        Skill_Description = s.Skill_Description;
        type = s.type;
        Skill_type = s.Skill_type;
        Skill_Attribute = s.Skill_Attribute;
        Skill_Damage = s.Skill_Damage;
        Skill_Cost = s.Skill_Cost;
        Skill_Target = s.Skill_Target;
        Skill_effect = s.Skill_effect;
        Skill_Stat_Target = s.Skill_Stat_Target;        
    }*/
}
