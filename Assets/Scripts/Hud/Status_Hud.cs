using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_Hud : MonoBehaviour
{
    // Start is called before the first frame update
    public Text HitPoint;
    public Text ManaPoint;
    public Text ExpPoint;
    public Text Level;

    public Text Attack;
    public Text Defense;
    public Text Intelligence;
    public Text Speed;

    public Text Skill_Name_1;
    public Text Skill_Name_2;
    public Text Skill_Name_3;
    public Text Skill_Name_4;
    public Text Skill_Name_5;
    public Text Skill_Name_6;
    public Text Skill_Name_7;
    public Text Skill_Name_8;


    public int HP;
    public int MP;
    public int EXP;
    public int LVL;
    public Unit unit;

    //private void Start()
    //{
    //    SetHUD(unit);
    //}
    private void Update()
    {
        SetHUD(unit);
    }
    public void SetHUD(Unit unit)
    {
        HitPoint.text = "HP: " + unit.Unit_Current_Hp + "/" + unit.Unit_Max_Hp;
        ManaPoint.text = "MP: " + unit.Unit_Current_Mp + "/" + unit.Unit_Max_Mp;
        ExpPoint.text = "Current Exp: " + unit.Current_Exp;
        Level.text = "Level: " + unit.Unit_Level;

        Attack.text = "Atk: " + unit.Unit_Atk;
        Defense.text = "Def: " + unit.Unit_Def;
        Intelligence.text = "Int: " + unit.Unit_Int;
        Speed.text = "Spd: " + unit.Unit_Speed;

        Skill_Name_1.text = unit.Unit_Skill[0].Skill_Name;
        Skill_Name_2.text = unit.Unit_Skill[1].Skill_Name;
        Skill_Name_3.text = unit.Unit_Skill[2].Skill_Name;
        Skill_Name_4.text = unit.Unit_Skill[3].Skill_Name;
        Skill_Name_5.text = unit.Unit_Skill[4].Skill_Name;
        Skill_Name_6.text = unit.Unit_Skill[5].Skill_Name;
        Skill_Name_7.text = unit.Unit_Skill[6].Skill_Name;
        Skill_Name_8.text = unit.Unit_Skill[7].Skill_Name;

        HP = unit.Unit_Current_Hp;
        MP = unit.Unit_Current_Mp;
        EXP = unit.Current_Exp;
        LVL = unit.Unit_Level;
    }
}
