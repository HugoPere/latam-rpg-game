using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    // Start is called before the first frame update
    public Text HitPoint;
    public Text ManaPoint;
    public int HP;
    public int MP;

    public void SetHUD(Unit unit)
    {
        HitPoint.text = "HP: " + unit.Unit_Current_Hp;
        ManaPoint.text = "MP: " + unit.Unit_Current_Mp;
        HP = unit.Unit_Current_Hp;
        MP = unit.Unit_Current_Mp;
    }

    
}
