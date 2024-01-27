using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] groundTiles;
    public MapGenerator mapGenerator;
    public GameObject playerPrefab;
    public GameObject[] enemyPrefabs;

    public int spawnEnemy = 3;
    int[,] mapValue;
    void Start()
    {
        mapValue = mapGenerator.GenerateMap();
        SpawnPlayer();
        SpawnEnemies();
    }
    void SpawnPlayer()
    {
          Vector2Int spawnPos = new Vector2Int();
        for (int i = 0; i < mapValue.GetLength(0); i++)
        {
            for (int j = 0; j < mapValue.GetLength(1); j++)
            {
                if (mapValue[i, j] == 1)
                {
                    spawnPos = new Vector2Int(i, j);
                    break;
                }
            }
        }
        Instantiate(playerPrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
    }
    
    void SpawnEnemies()
    {
        Vector2Int spawnPos = new Vector2Int();
        for (int i = 0; i < spawnEnemy; i++)
        {
            for (int x = 0; x < mapValue.GetLength(0); x++)
            {
                for(int y = 0; y < mapValue.GetLength(1); y++)
                {
                    if (mapValue[x, y] == 3)
                    {
                        spawnPos = new Vector2Int(x, y);
                        break;
                    }
                }
            }
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
        }
        }
}
