using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public int[] groundTiles;
    public MapGenerator mapGenerator;
    public GameObject playerPrefab;
    public GameObject[] enemyPrefabs;
    public GameObject[] vasePrefabs;

    public GameObject player = null;
    public GameObject portalPrefab;
    public int minEnemy = 1;
    public int maxEnemy = 20;
    public int spawnEnemy = 3;
    public int spawnVase = 6;
    public int ogNPCSize;
    public GameObject Boss;
    public GameObject[] dialogCharacter;
    public GameObject currentNPC;

    int[,] mapValue;
    int i = 1;
    bool allEnemyDead = false;
    int npcCounter = 0;
    int npcMax = 0;
    void Start()
    {

        ogNPCSize = dialogCharacter.Length;
        DontDestroyOnLoad(mapGenerator);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(mapGenerator.wallTilemap);
        mapValue = mapGenerator.GenerateMap(0);
        player = SpawnPlayer();
        AstarPath.active.Scan();
        SpawnNPC();
        SpawnEnemies();
        SpawnVase();
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
    void SpawnNPC()
    {

        if (dialogCharacter.Length > 0)
        {

            if (dialogCharacter.Length == ogNPCSize)
            {
                Destroy(currentNPC); currentNPC = null;
                GameObject npca = Instantiate(dialogCharacter[0], (Vector3)(Vector2)mapGenerator.region[Random.Range(0, mapGenerator.region.Count)], Quaternion.identity);
                List<GameObject> dialogCharacteree = dialogCharacter.ToList();
                dialogCharacteree.RemoveAt(0);
                dialogCharacter = dialogCharacteree.ToArray();
                currentNPC = npca;

            }
            else
            {
                Destroy(currentNPC); currentNPC = null;
                GameObject npc = Instantiate(dialogCharacter[0], (Vector3)(Vector2)mapGenerator.region[Random.Range(0, mapGenerator.region.Count)], Quaternion.identity);
                List<GameObject> dialogCharactere = dialogCharacter.ToList();
                dialogCharactere.RemoveAt(0);
                dialogCharacter = dialogCharactere.ToArray();
                currentNPC = npc;
            }
        }
        else
        {
            SpawnBoss();
        }
    }
    void SpawnVase()
    {
        Vector2Int spawnPos = new Vector2Int();
        for (int i = 0; i < spawnVase; i++)
        {
            for (int x = 0; x < mapValue.GetLength(0); x++)
            {
                for (int y = 0; y < mapValue.GetLength(1); y++)
                {
                    if (mapValue[x, y] == 2)
                    {
                        spawnPos = new Vector2Int(x, y);
                        break;
                    }
                }
            }
            Instantiate(vasePrefabs[Random.Range(0, vasePrefabs.Length)], new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
        }
    }
    void SpawnPortal()
    {
        Vector2Int portalSpawnPoint = mapGenerator.region[Random.Range(0, mapGenerator.region.Count)];
        Instantiate(portalPrefab, new Vector3(portalSpawnPoint.x, portalSpawnPoint.y, 0), Quaternion.identity);

    }

    public void NextMap()
    {

        mapGenerator.wallTilemap.ClearAllTiles();
        mapGenerator.tilemap.ClearAllTiles();

        mapValue = mapGenerator.GenerateMap(i);
        StartCoroutine(UpdateCollider());
        AstarPath.active.Scan();

        Destroy(player);
        player = SpawnPlayer();
        if (dialogCharacter.Length != 0)
        {
            spawnEnemy = Random.Range(minEnemy, maxEnemy);
            SpawnEnemies();
            if (npcCounter >= npcMax)
            {
                SpawnNPC();
                npcCounter = 0;
            }
            else
            {
                npcCounter++;
            }

            allEnemyDead = false;
        }
        else
        {

        }
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
        if (mapGenerator.wallTilemap != null)
        {
            mapGenerator.wallTilemap.GetComponent<TilemapCollider2D>().enabled = false;
            yield return null; // Wait one frame
                               // Ensure the wallTilemap wasn't destroyed during the frame delay
            if (mapGenerator.wallTilemap != null)
            {
                mapGenerator.wallTilemap.GetComponent<TilemapCollider2D>().enabled = true;
            }
        }
    }
    void SpawnBoss()
    {
        GameObject npc = Instantiate(Boss, (Vector3)(Vector2)mapGenerator.region[Random.Range(0, mapGenerator.region.Count)], Quaternion.identity);
    }
}
