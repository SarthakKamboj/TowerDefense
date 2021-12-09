using UnityEngine;

public class ShootingTower : MonoBehaviour
{

    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeBetweenShots;

    float timeUntilNextShot;

    void Start()
    {
        timeUntilNextShot = timeBetweenShots;
    }

    void Update()
    {
        timeUntilNextShot = Mathf.Max(0f, timeUntilNextShot - Time.deltaTime);

        if (timeUntilNextShot == 0f)
        {
            timeUntilNextShot = timeBetweenShots;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
