using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_cutscene : MonoBehaviour
{
    public GameObject player;

    public GameObject cutscene_canvas;
    public GameObject overworld_canvas;

    public cutscene_system cutscene_system;

    
    public int choice;

    void OnTriggerEnter(Collider player)
    {
        overworld_canvas.SetActive(false);
        cutscene_canvas.SetActive(true);
        cutscene_system.show_dialog(choice);
        Object.Destroy(this.gameObject);
    }
}
