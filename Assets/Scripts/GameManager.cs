using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public GameObject playerPrefab;
    public GameObject[] enemyPrefabs;
    int[,] mapValue;
    void Start()
    {
        mapValue = mapGenerator.GenerateMap();
        SpawnPlayer();
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
    
}
