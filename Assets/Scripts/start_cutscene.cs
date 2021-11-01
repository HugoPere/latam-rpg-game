using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_cutscene : MonoBehaviour
{
    public GameObject player;

    public GameObject cutscene_canvas;
    public GameObject overworld_canvas;

    public cutscene_system cutscene_system;

    public GameObject self;

    
    public int choice;

    void OnTriggerEnter(Collider player)
    {
        Debug.Log("ENTRANDO A CUTSCENE");
        self.SetActive(false);
        Debug.Log("APAGUE TRIGGER");
        overworld_canvas.SetActive(false);
        Debug.Log("APAGUE CANVAS MUNDO");
        cutscene_canvas.SetActive(true);
        Debug.Log("INICIE CANVAS ESCENAS");
        Debug.Log("VOY A ESCENA NUMERO " + choice);
        cutscene_system.start_dialog(choice);
        Debug.Log("SALI DE ESCENA " + choice);
        //Object.Destroy(this.gameObject);
    }
}
