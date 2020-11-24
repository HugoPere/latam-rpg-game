
using UnityEngine;

public class damage : MonoBehaviour
{
    public int damage_value;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Jugador")
        {
            Debug.Log("Sufriste puntos de daño =" + damage_value);
        }
    }

}
