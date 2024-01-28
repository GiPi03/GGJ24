using Pathfinding;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public int[] groundTiles;
    public MapGenerator mapGenerator;
    public GameObject playerPrefab;
    public GameObject[] enemyPrefabs;
    public GameObject player = null;
    public GameObject portalPrefab;
    public int minEnemy = 1;
    public int maxEnemy = 20;
    public int spawnEnemy = 3;
    int[,] mapValue;
    int i = 1;
    bool allEnemyDead = false;
    void Start()
    {
        mapValue = mapGenerator.GenerateMap(0);
        player = SpawnPlayer();
        AstarPath.active.Scan();
        SpawnEnemies();
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 != allEnemyDead)
        {
            allEnemyDead = true;
            SpawnPortal();
        }
        Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
    void SpawnPortal()
    {
        Vector2Int portalSpawnPoint = mapGenerator.region[Random.Range(0, mapGenerator.region.Count)];
        Instantiate(portalPrefab, new Vector3(portalSpawnPoint.x, portalSpawnPoint.y, 0), Quaternion.identity);

    }

    public void NextMap()
    {
        mapGenerator.tilemap.ClearAllTiles();
        mapGenerator.wallTilemap.ClearAllTiles();
        mapValue = mapGenerator.GenerateMap(i);
        StartCoroutine(UpdateCollider());
        AstarPath.active.Scan();
        
        Destroy(player);
        player = SpawnPlayer();
        spawnEnemy = Random.Range(minEnemy, maxEnemy);
        SpawnEnemies();
        allEnemyDead = false;
        i++;
    }
    GameObject SpawnPlayer()
    {
        Vector2Int spawnPos = new Vector2Int();

        spawnPos = mapGenerator.region[Random.Range(0, mapGenerator.region.Count)];
        return Instantiate(playerPrefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
    }

    void SpawnEnemies()
    {
        Vector2Int spawnPos = new Vector2Int();
        for (int i = 0; i < spawnEnemy; i++)
        {
            spawnPos = mapGenerator.region[Random.Range(0, mapGenerator.region.Count)];
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
        }
    }
    IEnumerator UpdateCollider()
    {
        mapGenerator.wallTilemap.GetComponent<TilemapCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.05f);// Wait one frame
        mapGenerator.wallTilemap.GetComponent<TilemapCollider2D>().enabled = true;
    }
}
