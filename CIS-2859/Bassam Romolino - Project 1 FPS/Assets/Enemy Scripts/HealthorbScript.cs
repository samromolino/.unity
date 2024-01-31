using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthorbScript : MonoBehaviour
{
    [SerializeField]
    private int heal = 2;


    [SerializeField]
    private float maxTime = 5;

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (maxTime - timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string type = other.name;

        if (type == "Player")

        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();

            if (player != null)
            {
                player.Heal(heal);
                Destroy(this.gameObject);
            }
        }
    }
}
