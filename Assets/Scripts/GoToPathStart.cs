using UnityEngine;

public class GoToPathStart : MonoBehaviour
{

    [SerializeField] float timeBetweenSpawns = 5f;
    [SerializeField] GameObject enemyPrefab;

    float timeSinceLastSpawn = 0f;

    void Start()
    {
        Transform pathNodesParent = GameObject.Find("Path Nodes").transform;
        foreach (Transform path in pathNodesParent)
        {
            transform.position = path.position;
            break;
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            timeSinceLastSpawn = 0f;
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Vector3 pos = enemy.transform.position;
            pos.y += enemy.transform.Find("GFX").GetComponent<Renderer>().bounds.extents.y - transform.Find("GFX").GetComponent<Renderer>().bounds.extents.y;
            enemy.transform.position = pos;
        }
    }

}
