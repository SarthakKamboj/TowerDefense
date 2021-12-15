using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] float timeBetweenSpawns = 5f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] LayerMask groundLayerMask;

    float timeSinceLastSpawn = 0f;
    Vector3 spawnPoint;

    void Start()
    {
        Transform pathNodesParent = GameObject.Find("Path Nodes").transform;
        foreach (Transform path in pathNodesParent)
        {
            RaycastHit groundHit;
            Ray ray = new Ray();
            ray.direction = Vector3.down;
            ray.origin = path.position;
            if (Physics.Raycast(ray, out groundHit, Mathf.Infinity, groundLayerMask))
            {
                Vector3 pos = transform.position;
                pos = groundHit.point;
                spawnPoint = pos;
                pos.y += GetComponent<Collider>().bounds.extents.y;
                transform.position = pos;
            }
            break;
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            timeSinceLastSpawn = 0f;
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            Vector3 pos = enemy.transform.position;
            pos.y += enemy.GetComponent<Collider>().bounds.extents.y;
            enemy.transform.position = pos;
        }
    }

}
