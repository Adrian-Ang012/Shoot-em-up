using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySmallPrefab;
    public GameObject enemyMediumPrefab;

    public float spawnInterval = 2f;
    public float spawnXMin = -5f;
    public float spawnXMax = 5f;
    public float spawnY = 4.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float x = Random.Range(spawnXMin, spawnXMax);
        Vector3 pos = new Vector3(x, spawnY, 0f);

        int choice = Random.Range(0, 2);
        GameObject prefab = (choice == 0) ? enemySmallPrefab : enemyMediumPrefab;

        Instantiate(prefab, pos, Quaternion.identity);
    }
}