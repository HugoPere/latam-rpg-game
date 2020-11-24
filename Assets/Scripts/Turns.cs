using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYER, ENEMY, WIN, DEFEAT, BATTLING, ENEMY_RAN}
public class Turns : MonoBehaviour
{
    //sprites and turns
    public BattleState state;
    public GameObject player;
    public GameObject enemy;
    public GameObject[] enemylist;
    

    //place in screen
    public Transform PlayerStation;
    public Transform EnemyStation;
    //stats and sprites
    Unit playerUnit;
    Unit enemyUnit;

    GameObject EnemyGO;
    //text
    public Text dialogueText;
    //player and enemy UI
    public PlayerHud playerhud;
    public EnemyHud enemyhud;

    //to start and end fights visually
    public GameObject overworld_canvas;
    public GameObject encounter;
    public GameObject enc_trigger;
    //reasoning canvases and objects
    public GameObject reason_canvas;
    public GameObject friendly_canvas;
    public GameObject aggresive_canvas;
    public GameObject skill_canvas;
    public GameObject PlayerHud_bg;
    //player skills canvases and objects
    public GameObject Player_Skills;
    //Enemy_HUD
    public int Skill_id;
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

    void Start()
    {
        state = BattleState.START;
        
    }

    public void Select_Enemy(int x)
    {
        enemy = enemylist[x];
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        
        GameObject PlayerGO =player;
        playerUnit = PlayerGO.GetComponent<Unit>();
        Instantiate(player, PlayerStation);
        EnemyGO = Instantiate(enemy, EnemyStation);
        enemyUnit = EnemyGO.GetComponent<Unit>();

        dialogueText.text = "A " + enemyUnit.Unit_Name + " draws near";

        playerhud.SetHUD(playerUnit);
        playerUnit.Set_Skills();
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYER;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        dialogueText.text = "A hit!";
        yield return new WaitForSeconds(1f);
        int base_hit = playerUnit.Unit_Atk;

        Random.seed = System.DateTime.Now.Millisecond;
        int modifier = Random.Range(1, 4);

        Debug.Log("The modifier is " + modifier);
        int level = playerUnit.Unit_Level;

        int going_atk = base_hit + modifier;

        Debug.Log("going_atk is " + going_atk);

        int result = going_atk - enemyUnit.Unit_Def;

        Debug.Log("the result is " + result);
        bool isDead = enemyUnit.TakeDamage(result);
        dialogueText.text = enemyUnit.Unit_Name + " took " + result + " damage!";
        yield return new WaitForSeconds(2f);
        
        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMY;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerReason()
    {
        dialogueText.text = "Which approach?";
        yield return new WaitForSeconds(1f);
        reason_canvas.SetActive(true);

        
    }

    IEnumerator EnemyTurn()
    {

        yield return new WaitForSeconds(1f);
        
        int action = Random.Range(1,10);
        int damage;

        
        if(action < 8)
        {
            dialogueText.text = enemyUnit.Unit_Name + "attacks!!";
            damage = enemyUnit.Unit_Atk;
        }
        else
        {
            dialogueText.text = enemyUnit.Unit_Name + "attacks with magic!!";
            damage = enemyUnit.Unit_Skill[0].Skill_Damage;
        }
        bool isDead = playerUnit.TakeDamage(damage);

        playerhud.SetHUD(playerUnit);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.DEFEAT;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYER;
            PlayerTurn();
        }

    }

    public void Finish_reasoning(int x)
    {
        if (x == 1)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else if(x == 2){
            state = BattleState.ENEMY;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            state = BattleState.ENEMY_RAN;
            EndBattle();
        }
    }

    IEnumerator End_Messages()
    {
        Debug.Log("Estoy en end message");
        if (state == BattleState.WIN)
        {
            Destroy(EnemyGO);
            //Destroy(enemyUnit);
            dialogueText.text = "Victory!";
            yield return new WaitForSeconds(1f);
            int exp = enemyUnit.Exp_Value;
            bool levelup = playerUnit.Level_up(exp);

            dialogueText.text = "Got " + exp + " experience points";
            yield return new WaitForSeconds(2f);
            if (levelup == true)
            {
                dialogueText.text = "Level up !!!";
                yield return new WaitForSeconds(2f);
            }
            overworld_canvas.SetActive(true);
            encounter.SetActive(false);
            Destroy(enc_trigger);
            if (enemyUnit.type == type.BOSS)
            {
                SceneManager.LoadScene("end_demo");
            }

        }

        if (state == BattleState.DEFEAT)
        {
            Destroy(EnemyGO);
            dialogueText.text = "You died";
            SceneManager.LoadScene("end_demo");

        }
        if (state == BattleState.ENEMY_RAN)
        {
            Destroy(EnemyGO);
            dialogueText.text = enemyUnit.Unit_Name + " ran away!!!";
            yield return new WaitForSeconds(2f);
            overworld_canvas.SetActive(true);
            encounter.SetActive(false);
            Destroy(enc_trigger);

        }
    }

    public void EndBattle()
    {
        Debug.Log("Estoy en end battle");
        StartCoroutine(End_Messages());
    }

    void PlayerTurn()
    {
        PlayerHud_bg.SetActive(true);
        dialogueText.text = "Choose an action";
    }

    public void OnAttackButton()
    {
        if (state == BattleState.PLAYER)
        {
            state = BattleState.BATTLING;
            StartCoroutine(PlayerAttack());
            
        }
        else { 
        dialogueText.text = "Not your turn";
        return;
        }
    }

    public void OnRunButton()
    {
        int success = Random.Range(0, 10);
        if (success > 5)
        {
            Debug.Log("Escaped!");
            state = BattleState.ENEMY_RAN;
            EndBattle();
        }
        else
        {
            Debug.Log("Can't escape!");
            dialogueText.text = "Can't escape!";
            state = BattleState.ENEMY;
            EnemyTurn();
        }
    }

    public void OnReasonButton()
    {
        if (state == BattleState.PLAYER)
        {
            if(enemyUnit.type != type.BOSS)
            {
                dialogueText.text = "It's impossible to reason with them!";
                Debug.Log("Imposible");
                
            }
            else
            {
                state = BattleState.BATTLING;
                PlayerHud_bg.SetActive(false);
                StartCoroutine(PlayerReason());

            }
            

        }
        else
        {
            dialogueText.text = "Not your turn";
            return;
        }
    }

    public void OnPlayerSkillButton()
    {
        Player_Skills.SetActive(true);
    }
    
    public void On_PlayerSkill_Button_X(int x)
    {
        if (state == BattleState.PLAYER)
        {
            int playerMP = playerUnit.Unit_Current_Mp;
            int SkillCost = playerUnit.Unit_Skill[x].Skill_Cost;

            if (playerMP >= SkillCost)
            {
                playerUnit.Substract_MP(SkillCost);
                state = BattleState.BATTLING;
                StartCoroutine(PlayerSkill(x));
            }

            else
            {
                dialogueText.text = "Not enough MP";
            }
            
        }
        else
        {
            dialogueText.text = "Not your turn";

            return;
        }
        
    }

    IEnumerator PlayerSkill(int x)
    {
        Player_Skills.SetActive(false);

        dialogueText.text = "You cast " + playerUnit.Unit_Skill[x].Skill_Name;
        
        yield return new WaitForSeconds(1f);

        
        if (playerUnit.Unit_Skill[x].Skill_Target == target.ENEMY)
            {
                //Calculating damage
                int base_power = playerUnit.Unit_Skill[x].Skill_Damage;
                Random.seed = System.DateTime.Now.Millisecond;
                int modifier = Random.Range(1, 4);
                Debug.Log("The modifier is " + modifier);
                int INT_stat = playerUnit.Unit_Int;
                int level = playerUnit.Unit_Level;
                int going_power = base_power + modifier + INT_stat;
                Debug.Log("going_power is " + going_power);
                int result = going_power - enemyUnit.Unit_Def;
                Debug.Log("the result is " + result);
                
                //End Calculus
                bool isDead = enemyUnit.TakeDamage(result);
                dialogueText.text = enemyUnit.Unit_Name + " took " + result + " of magic damage!";
                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    state = BattleState.WIN;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMY;
                    StartCoroutine(EnemyTurn());
                }
            }
        else
            {
                //HEALING SKILL

                //Calculating damage
                int base_power = playerUnit.Unit_Skill[x].Skill_Damage;
                Random.seed = System.DateTime.Now.Millisecond;
                int modifier = Random.Range(1, 4);
                Debug.Log("The modifier is " + modifier);
                int INT_stat = playerUnit.Unit_Int;
                int level = playerUnit.Unit_Level;
                int going_power = base_power + modifier + INT_stat;
                Debug.Log("going_power is " + going_power);
                int result = going_power;
                Debug.Log("the result is " + result);
                int result_in_text = result * -1;
                dialogueText.text = playerUnit.Unit_Name + " restored " + result_in_text + " of life!!";

                //End Calculus
                bool isDead = playerUnit.TakeDamage(result);
                if(playerUnit.Unit_Current_Hp > playerUnit.Unit_Max_Hp)
                {
                playerUnit.Unit_Current_Hp = playerUnit.Unit_Max_Hp;
                }
                yield return new WaitForSeconds(2f);

                if (isDead)
                {
                    state = BattleState.WIN;
                    EndBattle();
                }
                else
                {
                    state = BattleState.ENEMY;
                    StartCoroutine(EnemyTurn());
                }
            }
        
    }

    public void SetHUD_Skills(Unit unit)
    {
        Debug.Log("Estoy poniendo skills de enemigo");
        Skill_id = enemyUnit.Unit_Skill[0].id;
        Skill_Name.text = enemyUnit.Unit_Skill[0].Skill_Name;
        Skill_Type.text = enemyUnit.Unit_Skill[0].Skill_type;
        Skill_Description.text = enemyUnit.Unit_Skill[0].Skill_Description;

        Skill_id_2 = enemyUnit.Unit_Skill[1].id;
        Skill_Name_2.text = enemyUnit.Unit_Skill[1].Skill_Name;
        Skill_Type_2.text = enemyUnit.Unit_Skill[1].Skill_type;
        Skill_Description_2.text = enemyUnit.Unit_Skill[1].Skill_Description;

        Skill_id_3 = enemyUnit.Unit_Skill[2].id;
        Skill_Name_3.text = enemyUnit.Unit_Skill[2].Skill_Name;
        Skill_Type_3.text = enemyUnit.Unit_Skill[2].Skill_type;
        Skill_Description_3.text = enemyUnit.Unit_Skill[2].Skill_Description;


    }
    
}
