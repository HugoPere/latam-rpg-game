using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    public int hp;
    public GameObject Canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stats stats = Enemy.GetComponent<stats>();
        hp = stats.hitpoint;
        if (hp <= 0)
        {
            Destroy(Enemy);
            Canvas.SetActive(true);
        }
    }
    public void checkandkill()
    {
        
    }
}
