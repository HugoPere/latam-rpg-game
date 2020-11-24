using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_enemy : MonoBehaviour
{

    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        //Enemy = GameObject.Find("Enemy");
        stats stats = Enemy.GetComponent<stats>();
        int CurrentHP = stats.hitpoint;
        CurrentHP = CurrentHP - 1;
        Enemy.GetComponent<stats>().hitpoint = CurrentHP;
        Debug.Log("You attack!!!");

        Debug.Log("Enemy Turn!!!");
    }
}
