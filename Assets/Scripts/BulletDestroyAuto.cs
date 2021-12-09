using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyAuto : MonoBehaviour
{

    [SerializeField] float totalBulletLifeSpan = 2f;
    static int i = 0;

    void Start()
    {
        gameObject.name = "Bullet " + i;
        i += 1;
        Destroy(gameObject, totalBulletLifeSpan);
    }

}
