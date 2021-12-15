using UnityEngine;

public class ShootingTower : MonoBehaviour
{

    [SerializeField] Transform shootingPipeStart, shootingPipeEnd;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float force = 1000f;

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
        Vector3 dir = (shootingPipeEnd.position - shootingPipeStart.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, shootingPipeStart.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(dir * force, ForceMode.Impulse);
    }
}
