using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour { 

    public float horizontalmove;
    public float verticalmove;
    public CharacterController player;
    public float playerspeed;

    public KeyCode forward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode backwards;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent <CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalmove = Input.GetAxis("Horizontal");
        verticalmove = Input.GetAxis("Vertical");
        //player.Move(new Vector3(horizontalmove, 0, verticalmove) * playerspeed * Time.deltaTime);
        if (Input.GetKeyDown(forward))
        {
            player.Move(transform.TransformDirection(Vector3.forward) * playerspeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(forward))
        {
            player.Move(transform.TransformDirection(Vector3.back) * playerspeed * Time.deltaTime);
        }


    }

    
}
