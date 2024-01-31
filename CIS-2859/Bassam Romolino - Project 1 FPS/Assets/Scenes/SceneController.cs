using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    private GameObject enemy;

    private int currentRound = 0;

    [SerializeField]
    private float respawnTime = 3.0f;

    private float timer;

    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && currentRound < 3)
        {

            if (currentRound == 0) 
            {
                currentRound++;
                Spawn(currentRound);
            }

            else
            {
                timer += Time.deltaTime;
                if (timer >= respawnTime)
                {
                    currentRound++;
                    timer = 0;
                    Spawn(currentRound);
                }
            }
        }
    }

    private void Spawn(int currentRound)
    {
        for (int i = 0; i < currentRound; i++)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.GetComponent<WanderingAI>().health = currentRound;
            enemy.transform.position = new Vector3((Random.Range(-10, 10)), 1, (Random.Range(-5, 5)));
        }
    }
}
