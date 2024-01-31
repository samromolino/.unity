using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthorbScript : MonoBehaviour
{
    [SerializeField]
    private int heal = 2;


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        string type = other.name;

        if (type == "Player")
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();

            if (player != null)
            {
                player.Hurt(heal);
                Destroy(this.gameObject);
            }
        }
    }
}
