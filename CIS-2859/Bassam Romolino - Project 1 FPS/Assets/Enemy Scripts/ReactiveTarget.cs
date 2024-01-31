using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    public ChaseAI behavior;

    public void ReactToHit()
    {
        behavior = GetComponent<ChaseAI>();

        if (behavior != null)
        {
            if (behavior.isAlive) 
            {
                behavior.TakeDamage(damage);
                if (!behavior.isAlive)
                {
                    StartCoroutine(Die());
                }
            }
            else
            {
                behavior.health -= damage;
            }
        }
    }

    public bool ShootThrough()
    {
        return behavior.health >= 0;
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
