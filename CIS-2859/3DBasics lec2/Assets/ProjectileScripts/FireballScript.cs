using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private int damage = 1;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        string type = other.name;

        if (type == "Player")
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();

            if (player != null)
            {
                player.Hurt(damage);
                Destroy(this.gameObject);
            }
        }

        else if (type == "Enemy(Clone)")
        {
            ReactiveTarget enemy = other.GetComponent<ReactiveTarget>();
            if (enemy != null)
            {
                enemy.ReactToHit();
                Destroy(this.gameObject);
            }
        }

        else if(type == "Fireball(Clone)")
        {
            //nothing
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
