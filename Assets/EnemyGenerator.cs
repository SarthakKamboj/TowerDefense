using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float SpawnTime = 2f;

    float spawnTime;
    int i = 0;

    void Start()
    {
        spawnTime = SpawnTime;
    }

    void Update()
    {
        spawnTime = Mathf.Max(0, spawnTime - Time.deltaTime);
        if (spawnTime == 0f)
        {
            spawnTime = SpawnTime;
            GameObject obj = Instantiate(enemyPrefab);
            obj.name = "Enemy " + i.ToString();
            i += 1;
        }
    }
}
