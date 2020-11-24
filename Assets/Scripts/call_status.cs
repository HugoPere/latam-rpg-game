using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call_status : MonoBehaviour
{
    public GameObject overworld;
    public GameObject status;
    private void Update()
    {
        if (overworld.activeSelf == true && status.activeSelf == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                overworld.SetActive(false);
                
                status.SetActive(true);
            }
            
        }
        else if (overworld.activeSelf == false && status.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                overworld.SetActive(true);

                status.SetActive(false);
            }

        }
    }
}
