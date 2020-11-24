using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_battle : MonoBehaviour
{
    //public GameObject encounter;

    public GameObject battle;

    public GameObject player;

    public GameObject overworld_canvas;

    public Turns turn;

    public int choice;

    public GameObject self;

    //public GameObject enemy_group;

    void OnTriggerEnter(Collider player)
    {
        //Debug.Log("Battle Start");

        overworld_canvas.SetActive(false);

        battle.SetActive(true);

        self.SetActive(false);

        turn.Select_Enemy(choice);

        
        //enemy_group.SetActive(true);
    }


}
