﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class use_skill_from_menu : MonoBehaviour
{
    public Text Skill_Message;
    public Unit unit;
    public target target;
    // Start is called before the first frame update
    
    public void Use_Skill(int x)
    {
        if (unit.Unit_Skill[x].Skill_Target == target.SELF)
        {
            unit.Use_Skill(x);
            int text_number = unit.Unit_Skill[x].Skill_Damage * -1;
            Skill_Message.text = "Recovered " + text_number + " points"; 
        }
        else
        {
            Skill_Message.text = "Can't use this skill outside of combat";
        }
    }
}