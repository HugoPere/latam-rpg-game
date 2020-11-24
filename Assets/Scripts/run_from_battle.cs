using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run_from_battle : MonoBehaviour
{

    private int success;
    public GameObject enemy_canvas;
    public GameObject battle_canvas;
    public GameObject overworld_canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void escape()
    {
        success = Random.Range(0, 10);
        if (success > 5)
        {
            Debug.Log("Escaped!");
            enemy_canvas.SetActive(false);
            battle_canvas.SetActive(false);
            overworld_canvas.SetActive(true);
        }
        else
        {
            Debug.Log("Can't escape!");
        }
    }
}
