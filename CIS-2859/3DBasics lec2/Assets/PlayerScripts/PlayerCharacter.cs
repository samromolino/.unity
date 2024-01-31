using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private int health = 25;

    public bool isAlive;

    void Awake()
    {
        isAlive = true;
    }

    public void Hurt (int damage)
    {
        health -= damage;

        Debug.Log($"Health: {health}");

        if (health <= 0)
        {
            isAlive = false;
            Debug.Log("Player has died");
        }
    }

    public void Heal (int heal) 
    { 
        health += heal;
        if (health > 25) 
        { 
            health = 25;
        }
        Debug.Log($"Health: {health}");

    }
}
