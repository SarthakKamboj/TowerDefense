using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int health = 100;

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
