using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_info : MonoBehaviour
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

    public void show_info()
    {
        //statblock = GameObject.Find("StatBlock");
        stats stats = Enemy.GetComponent<stats>();
        int hp = stats.hitpoint;
        Debug.Log("Li' Devi'");
        Debug.Log("Demonio travieso");
        Debug.Log("HP:" + hp);
    }
}
