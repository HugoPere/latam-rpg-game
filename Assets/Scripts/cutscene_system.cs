using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutscene_system : MonoBehaviour
{
    public Image image_left;
    public Image image_right;
    
    public Text Name;
    public Text dialog;

    public GameObject cutscene_canvas;
    public GameObject overworld_canvas;

    public GameObject cutscene_trigger;

    public cutscenes[] Cutscene;
    
    int x = 0;
    int y;
    

    public void continue_dialog()
    {
        x += 1;
        show_dialog(y);
    }

    public void show_dialog(int y) 
    {
        if( x < Cutscene[y].dialogs.Length)
        {
            
            image_left.sprite = Cutscene[y].Sprites_right[x];
            image_right.sprite = Cutscene[y].Sprites_left[x];
            Name.text = Cutscene[y].names[x];
            dialog.text = Cutscene[y].dialogs[x];
            
        }
        else
        {
            cutscene_canvas.SetActive(false);
            overworld_canvas.SetActive(true);
            cutscene_trigger.SetActive(false);
        }
        
    }

    

    
}
