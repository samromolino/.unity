using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private GameObject fireballPrefab;

    [SerializeField]
    private GameObject healthorbPrefab;

    [SerializeField]
    private float firerate = 1.0f;

    private float timer;

    private GameObject fireball;

    private GameObject healthorb;

    public int health;

    public bool isAlive;

    private float minDistance = 3.0f;

    private PlayerCharacter player;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        timer = firerate;
        isAlive = true;
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }


    public void TakeDamage (int damage)
    {
        this.health--;
        if (health <= 0)
        {
            isAlive = false;
            healthorb = Instantiate(healthorbPrefab) as GameObject;
            healthorb.transform.position = transform.TransformPoint(Vector3.forward);

        }
    }

    void Update()
    {
        if (player.isAlive)
        {
            if (isAlive)
            {
                timer += Time.deltaTime;

                transform.LookAt(target.position);
                if (Vector3.Distance(transform.position, target.position) >= minDistance)
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);

                }

                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.SphereCast(ray, 0.75f, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;

                    if (hitObject.GetComponent<PlayerCharacter>())
                    {
                        if (fireball == null && (firerate - timer <= 0))
                        {
                            fireball = Instantiate(fireballPrefab) as GameObject;

                            fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            fireball.transform.rotation = transform.rotation;

                            timer = 0;
                        }
                    }
                }
            }
        }
    }
}
