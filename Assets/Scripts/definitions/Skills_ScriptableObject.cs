using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public enum target { ENEMY, SELF, SELF_ALL }
public enum Skill_effect { ATTACK, HEAL, BUFF }
public enum skill_type { SPELL, SONG, LAND, SUMMON }
public enum stat_target { NONE, ATTACK, DEFENSE, SPEED, INTELLIGENCE };
*/
[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skills_S : ScriptableObject
{
    

        public int id;
        public string Skill_Name;
        public string Skill_Code;
        public string Skill_Description;
        public skill_type type_script;
        public string Skill_type;
        public string Skill_Attribute;
        public int Skill_Damage;
        public int Skill_Cost;
        public target Skill_Target_script;
        public Skill_effect Skill_effect_script;
        public stat_target Skill_Stat_Target_script;

       
}
