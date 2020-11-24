using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_skills : MonoBehaviour
{

    public Text Skill_Name;
    /*
    public Text Skill_Type;
    public Text Skill_Description; */
    public int Skill_id;
    public Skills[] All_Skills;

    

    public void SetHUD_Skills(Unit unit)
    {
        Skill_id = All_Skills[0].id;
        Skill_Name.text = All_Skills[0].Skill_Name;
        /*Skill_Type.text = All_Skills[0].Skill_type;
         Skill_Description.text = All_Skills[0].Skill_Description; */
    }
}
