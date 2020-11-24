using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHud : MonoBehaviour
{
    public Text Skill_Name;
    public Text Skill_Type;
    public Text Skill_Description;
    public int Skill_id_2;
    public Text Skill_Name_2;
    public Text Skill_Type_2;
    public Text Skill_Description_2;
    public int Skill_id_3;
    public Text Skill_Name_3;
    public Text Skill_Type_3;
    public Text Skill_Description_3;
    public int Skill_id;
    public Skills[] All_Skills;
    

    
    public void SetHUD_Skills(Unit unit)
    {
        Skill_id = All_Skills[0].id;
        Skill_Name.text = All_Skills[0].Skill_Name;
        Skill_Type.text = All_Skills[0].Skill_type;
        Skill_Description.text = All_Skills[0].Skill_Description;

        Skill_id_2 = All_Skills[1].id;
        Skill_Name_2.text = All_Skills[1].Skill_Name;
        Skill_Type_2.text = All_Skills[1].Skill_type;
        Skill_Description_2.text = All_Skills[1].Skill_Description;

        Skill_id_3 = All_Skills[2].id;
        Skill_Name_3.text = All_Skills[2].Skill_Name;
        Skill_Type_3.text = All_Skills[2].Skill_type;
        Skill_Description_3.text = All_Skills[2].Skill_Description;


    }
}
