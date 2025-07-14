using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject coinPrefab;
    public GameObject[] powerUps;

    public float spawnInterval = 1;
   // public float obstacleSpawnY = -2;
   // public float coinSpawnY = 0;
   // public float spawnDistance = 10;
    public float spawnLocationX;
    public float spawnLocationY;

    private float lastPlayerX;



    public Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPlayerX = playerTransform.position.x;
        InvokeRepeating("trySpawn", 1, spawnInterval);
    }

    void trySpawn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            spawn();
            
        }
        lastPlayerX = playerTransform.position.x;
    }

    void spawn()
    {
        //float spawnX = playerTransform.position.x + spawnDistance;

        int indexOb = Random.Range(0, obstacles.Length);
        int indexPu = Random.Range(0, powerUps.Length);
        GameObject obstacle = Instantiate(obstacles[indexOb], new Vector2(spawnLocationX, spawnLocationY), Quaternion.identity);
        int randNum = Random.Range(0, 5);
        if (randNum <= 3) //spawn coin
        {
            Instantiate(coinPrefab, new Vector2(spawnLocationX + Random.Range(1, 3), spawnLocationY + Random.Range(1, 3)), Quaternion.identity);
        }
        if (randNum < 3)
        {
            GameObject powerUp = Instantiate(powerUps[indexPu], new Vector2(spawnLocationX + Random.Range(1, 3), spawnLocationY + Random.Range(3, 4)), Quaternion.identity);
        }


    }
}
