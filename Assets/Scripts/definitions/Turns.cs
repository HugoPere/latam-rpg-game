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
    Sprite enemy_sprite;
    enemy_behaviour enemy_behav;

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
    public ShakeBehaviour Player_Camera;
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

    //MUSIC (MAKE INTO IT'S OWN SCRIPT)
    public AudioSource overworld_music;
    public AudioSource battle_music;

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

        state = BattleState.START;
        GameObject PlayerGO =player;
        playerUnit = PlayerGO.GetComponent<Unit>();
        //SETSTATS
        playerUnit.Unit_Current_Atk = playerUnit.Unit_Atk;
        playerUnit.Unit_Current_Def = playerUnit.Unit_Def;
        playerUnit.Unit_Current_Int = playerUnit.Unit_Int;
        playerUnit.Unit_Current_Speed = playerUnit.Unit_Speed;
        //SETSTATS
        //Instantiate(player, PlayerStation);
        EnemyGO = Instantiate(enemy, EnemyStation);
        enemyUnit = EnemyGO.GetComponent<Unit>();
        //SETSTATS
        enemyUnit.Unit_Current_Atk = enemyUnit.Unit_Atk;
        enemyUnit.Unit_Current_Def = enemyUnit.Unit_Def;
        enemyUnit.Unit_Current_Int = enemyUnit.Unit_Int;
        enemyUnit.Unit_Current_Speed = enemyUnit.Unit_Speed;
        //SETSTATS
        enemy_behav = EnemyGO.GetComponent<enemy_behaviour>();

        overworld_music.Stop();
        battle_music.Play();
        
        dialogueText.text = "A " + enemyUnit.Unit_Name + " draws near";

        playerhud.SetHUD(playerUnit);
        playerUnit.Set_Skills();
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYER;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        Debug.Log("STAT ATTACK IS " + playerUnit.Unit_Atk);
        dialogueText.text = "A hit!";
        playerUnit.Hit_Sound();
        //
        //BLINKING ANIMATION
        int blinking = 0;
        
        while (blinking < 3)
        {

            EnemyGO.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            EnemyGO.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            blinking += 1;
        }
        //END BLINKING ANIMATION
        //
        int base_hit = playerUnit.Unit_Current_Atk;

        Random.seed = System.DateTime.Now.Millisecond;
        int modifier = Random.Range(1, 4);

        Debug.Log("The modifier is " + modifier);
        int level = playerUnit.Unit_Level;

        int going_atk = base_hit + modifier;

        Debug.Log("going_atk is " + going_atk);

        int result = going_atk - enemyUnit.Unit_Current_Def;

        Debug.Log("the result is " + result);
        bool isDead = enemyUnit.TakeDamage(result);
        
        dialogueText.text = enemyUnit.Unit_Name + " took " + result + " damage!";
        yield return new WaitForSeconds(1f);

        
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
        bool isDead;
        

        if (action < 8)
        {

            dialogueText.text = enemyUnit.Unit_Name + "does a physical attack!";
            yield return new WaitForSeconds(1f);
            damage = enemyUnit.Unit_Atk;
            Debug.Log("I did a physical");
            enemyUnit.Hit_Sound();
            dialogueText.text = "You suffer " + damage + " points of damage";
            isDead = playerUnit.TakeDamage(damage);
            Debug.Log("Kapow enemigo");
            
            Player_Camera.TriggerShake();
        }
        else
        {
            Random.seed = System.DateTime.Now.Millisecond;
            int selected_skill = Random.Range(0, 2);
            

            dialogueText.text = enemyUnit.Unit_Name + " casts " + enemyUnit.Unit_Skill[selected_skill].Skill_Name;
            yield return new WaitForSeconds(1f);

            if (enemyUnit.Unit_Skill[selected_skill].Skill_Target == target.SELF)
            {

               isDead = enemyUnit.Use_Skill(selected_skill);
            }
            else
            {
                enemyUnit.Hit_Sound();
                damage = enemyUnit.Unit_Skill[selected_skill].Skill_Damage;
                Player_Camera.TriggerShake();
                dialogueText.text = "You suffer " + damage + " points of damage";
                yield return new WaitForSeconds(1f);
                Debug.Log("I did a magical");
                isDead = playerUnit.TakeDamage(damage);
            }
            
        }
        
        
        playerhud.SetHUD(playerUnit);

        yield return new WaitForSeconds(1f);

        if (isDead == true)
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
            overworld_music.Play();
            battle_music.Stop();
            if (enemyUnit.type == type.BOSS)
            {
                SceneManager.LoadScene("end_demo");
            }

        }

        if (state == BattleState.DEFEAT)
        {
            Destroy(EnemyGO);
            dialogueText.text = "You died";
            yield return new WaitForSeconds(2f);
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
        playerUnit.Unit_Current_Atk = playerUnit.Unit_Atk;
        playerUnit.Unit_Current_Def = playerUnit.Unit_Def;
        playerUnit.Unit_Current_Int = playerUnit.Unit_Int;
        playerUnit.Unit_Current_Speed = playerUnit.Unit_Speed;
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
                Debug.Log("I'm Here");
                if (playerUnit.Unit_Skill[x].Skill_effect == Skill_effect.BUFF)
                {
                    Debug.Log("I passed as a buff");
                    if (playerUnit.Unit_Current_Atk > playerUnit.Unit_Atk)
                    {
                        Debug.Log("and I'm denied! :D");
                        dialogueText.text = "Attack is already high";
                        Debug.Log("Attack is already high");
                    }

                    else if (playerUnit.Unit_Current_Def > playerUnit.Unit_Def)
                    {
                        dialogueText.text = "Defense is already high";
                        Debug.Log("Defense is already high");
                    }
                    else if (playerUnit.Unit_Current_Int > playerUnit.Unit_Int)
                    {
                        dialogueText.text = "Intelligence is already high";
                        Debug.Log("Intelligence is already high");
                    }
                    else if (playerUnit.Unit_Current_Speed > playerUnit.Unit_Speed)
                    {
                        dialogueText.text = "Speed is already high";
                        Debug.Log("Speed is already high");
                    }
                    else
                    {
                        Debug.Log("And here I'm about to substract");
                        playerUnit.Substract_MP(SkillCost);
                        state = BattleState.BATTLING;
                        StartCoroutine(PlayerSkill(x));
                    }

                }
                else
                {
                    Debug.Log("And here I'm about to substract");
                    playerUnit.Substract_MP(SkillCost);
                    state = BattleState.BATTLING;
                    StartCoroutine(PlayerSkill(x));
                }
                
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
            int blinking = 0;
            while (blinking < 3)
            {

                EnemyGO.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                EnemyGO.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                blinking += 1;
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

        else
            {
            
            bool isDead = playerUnit.Use_Skill(x);
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
