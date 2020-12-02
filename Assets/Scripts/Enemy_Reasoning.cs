using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum attitude { STARTING, ANGRY, HAPPY, PLEASED, AFRAID } //ENEMY ONLY
    /*
     * Personality explanations:
     * Aggresive: Most enemies, they need an aggresive approach and show dominance
     * Timid: Fairies and stuff, need a peaceful approach
     * Wise: Old and sacred enemies, may need to show weakness or intelligence
     * Curious: Young looking enemies, may need to show a trick or 2
     * Solemn: Gods and historical figures, may need to show respect
     * Savage: Zombies, animals, can't be reasoned with
     * Nonskill: Humans, can be reasoned but can't give skills on a succesfull attempt
     * Boss: Can be reasoned but it will always fail
    */

public class Enemy_Reasoning : MonoBehaviour
{
    //Button Texts
    /*
    public string peaceful_button_1;
    public string peaceful_button_2;*/

    public Text peaceful_button_text_1;
    public Text peaceful_button_text_2;
    /*
    public string aggresive_button_1;
    public string aggresive_button_2;*/
    public Text aggresive_button_text_1;
    public Text aggresive_button_text_2;
    //Responses
    public string peaceful_response;
    public string peaceful_button_1_response;
    public string peaceful_button_2_response;
    public string aggresive_response;
    public string aggresive_button_1_response;
    public string aggresive_button_2_response;
    //Battle dialogs
    public Text Upper_Text;
    //personality
    public personality pers;
    public attitude att;
    //Canvases and stuff
    public GameObject Reasoning_Canvas;
    public GameObject friendly_canvas;
    public GameObject aggresive_canvas;
    public GameObject skill_canvas;
    public GameObject overworld_canvas;
    public GameObject encounter;
    public GameObject enc_trigger;
    public GameObject enemy;
    Unit enemyUnit;
    GameObject EnemyGO;
    public Unit playerUnit;
    public EnemyHud enemyhud;
    public Turns turns;
    //public Text Reason_first_first_button;
    //public Text Reason_first_first_button;


    private void Start()
    {
        att = attitude.STARTING;
        enemy = turns.enemy;
        //EnemyGO = Instantiate(enemy);
        enemyUnit = enemy.GetComponent<Unit>();
    }

    public void reasoning_start()
    {
        if (pers == personality.SAVAGE && pers == personality.BOSS)
        {
            
            Upper_Text.text = "Can't be reasoned with!!!";
            Debug.Log("Can't be reasoned with!!!");
            EndBattle(2);

        }


        else
        {
            if(enemyUnit.type == type.BOSS)
            {
                Upper_Text.text = "It's impossible to reason with them!";
                Debug.Log("Imposible");
                EndBattle(2);
            }
            else
            {
                StartCoroutine(reasoning_1st());
            }
            
        }
    }

    IEnumerator reasoning_1st()
    {
        yield return new WaitForSeconds(1f);
        Upper_Text.text = "Wich approach?";
        Reasoning_Canvas.SetActive(true);
    }

    //THESE BUTTONS AND COROUTEINES ARE ONLY WHILE ON REASONING MODE

    public void FriendlyApproach()
    {
        Upper_Text.text = "You try a friendly approach...";
        Reasoning_Canvas.SetActive(false);
        StartCoroutine(friendly());
    }
    public void AggresiveApproach()
    {
        Upper_Text.text = "You try an aggresive approach";
        Reasoning_Canvas.SetActive(false);
        StartCoroutine((aggresive()));
    }

    IEnumerator friendly()
    {
        yield return new WaitForSeconds(1f);
        Upper_Text.text = enemyUnit.Unit_Name + " says...";
        yield return new WaitForSeconds(1f);
        Upper_Text.text = enemyUnit.peaceful_response;
        peaceful_button_text_1.text = enemyUnit.peaceful_button_1;
        peaceful_button_text_2.text = enemyUnit.peaceful_button_2;
        Reasoning_Canvas.SetActive(false);
        friendly_canvas.SetActive(true);
    }

    IEnumerator aggresive()
    {
        yield return new WaitForSeconds(1f);
        Upper_Text.text = enemyUnit.Unit_Name + " says...";
        yield return new WaitForSeconds(1f);
        Upper_Text.text = enemyUnit.aggresive_response;
        aggresive_button_text_1.text = enemyUnit.aggresive_button_1;
        aggresive_button_text_2.text = enemyUnit.aggresive_button_2;
        Reasoning_Canvas.SetActive(false);
        aggresive_canvas.SetActive(true);
    }

    public void ON_peaceful_button_1()
    {
        if(enemyUnit.personality == personality.CURIOUS || enemyUnit.personality == personality.SOLEMN)
        {
            Upper_Text.text = enemyUnit.peaceful_button_1_response;
            friendly_canvas.SetActive(false);
            EndBattle(3);
        }
        else if (enemyUnit.personality == personality.WISE || enemyUnit.personality == personality.TIMID)
        {
            Upper_Text.text = enemyUnit.peaceful_button_1_response;
            friendly_canvas.SetActive(false);
            EndBattle(3);
        }
        else
        {
            Upper_Text.text = enemyUnit.peaceful_button_1_response;
            friendly_canvas.SetActive(false);
            EndBattle(2);
        }

    }

    public void ON_peaceful_button_2()
    {
        if (enemyUnit.personality == personality.CURIOUS || enemyUnit.personality == personality.SOLEMN)
        {
            Upper_Text.text = enemyUnit.peaceful_button_2_response;
            friendly_canvas.SetActive(false);
            EndBattle(3);
        }
        else if (enemyUnit.personality == personality.WISE || enemyUnit.personality == personality.TIMID)
        {
            Upper_Text.text = "You know what? Take one";

            friendly_canvas.SetActive(false);
            skill_canvas.SetActive(true);
            turns.SetHUD_Skills(enemyUnit);
        }
        else
        {
            Upper_Text.text = enemyUnit.peaceful_button_2_response;
            friendly_canvas.SetActive(false);
            EndBattle(2);
        }

    }

    public void ON_aggresive_button_1()
    {
        
        if (enemyUnit.personality == personality.AGGRESIVE || enemyUnit.personality == personality.WILD)
        {
            
            Upper_Text.text = "You know what? Take one";
            
            aggresive_canvas.SetActive(false);
            skill_canvas.SetActive(true);
            turns.SetHUD_Skills(enemyUnit);
        }
        else if (enemyUnit.personality == personality.TIMID || enemyUnit.personality == personality.SOLEMN || enemyUnit.personality == personality.WISE)
        {

            Upper_Text.text = enemyUnit.aggresive_button_1_response;
            aggresive_canvas.SetActive(false);
            EndBattle(2);
        }
        else
        {
            Upper_Text.text = enemyUnit.aggresive_button_1_response;
            aggresive_canvas.SetActive(false);
            EndBattle(3);
        }
    }

    public void ON_aggresive_button_2()
    {
        
        if (enemyUnit.personality == personality.WILD || enemyUnit.personality == personality.CURIOUS)
        {

            Upper_Text.text = "You know what? Take one";

            aggresive_canvas.SetActive(false);
            skill_canvas.SetActive(true);
            turns.SetHUD_Skills(enemyUnit);
        }
        else if (enemyUnit.personality == personality.AGGRESIVE || enemyUnit.personality == personality.SOLEMN)
        {

            Upper_Text.text = enemyUnit.aggresive_button_2_response;
            aggresive_canvas.SetActive(false);
            EndBattle(3);
        }
        else
        {
            Upper_Text.text = enemyUnit.aggresive_button_2_response;
            aggresive_canvas.SetActive(false);
            EndBattle(2);
        }
    }
    public void OnSkill_Button(int x)
    {
        Debug.Log(x);
        Upper_Text.text = "That one huh?, it's yours";
        Debug.Log(enemyUnit.Unit_Skill[x].id);
        Debug.Log(enemyUnit.Unit_Skill[x].Skill_Name);
        x = enemyUnit.Unit_Skill[x].id;
        Debug.Log(x);
        
        bool skill_given = playerUnit.Give_Skills(x);
        if (skill_given == true)
        {
            Upper_Text.text = "Habilidad concedida";
        }
        else
        {
            Upper_Text.text = "Espacios llenos";
        }
        EndBattle(1);

    }

    void EndBattle(int x)
    {
        
        //1 : Enemy concedes victory
        //2 : Enemy attacks
        //3 : Enemy runs
        skill_canvas.SetActive(false);
        turns.Finish_reasoning(x);
            
    }
}
