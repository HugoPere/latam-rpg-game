using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class transport : MonoBehaviour
{

    public GameObject player;

    public string level;

    void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene(level);
    }
}
