using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap wallTilemap;
    public Vector2Int mapSize;
    public Tile[] allGroundTiles = new Tile[4];
    public Tile groundTile;
    public Tile wallTile;
    public float wallFillPercent;
    public string seed;
    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
            
        //    seed = "Atzensport"+Random.Range(0, 100000);
        //    int[,] a = GenerateMap();
        //    a = FillMapRandom(a);
        //    for (int i = 0; i < 3; i++)
        //    {
        //        a = SmoothMap(a);
        //    }
        //    ProcessMap(a);
        //    a = SetRandomFloorTiles(a);
        //    RenderMap(a);
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{

        //    seed = "Atzensport" + Random.Range(0, 100000);
        //    int[,] a = GenerateMap();
        //    a = FillMapRandom(a);
        //    for (int i = 0; i < 3; i++)
        //    {
        //        a = SmoothMap(a);
        //    }
        //    ProcessMap(a);
        //   a =  SetRandomFloorTiles(a);
        //    RenderMap(a);
        //}
    }
    private void Start()
    {
       
        
    }
    public int[,] GenerateMap()
    {
        int[,] mapValues = new int[mapSize.x, mapSize.y];
        mapValues = FillMapRandom(mapValues);
        for (int i = 0; i < 3; i++)
        {
            mapValues = SmoothMap(mapValues);
        }
        ProcessMap(mapValues);
        mapValues = SetRandomFloorTiles(mapValues);
        RenderMap(mapValues);
        return mapValues;

    }
    public int[,] FillMapRandom(int[,] map)
    {
        System.Random random = new System.Random(seed.GetHashCode());
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {

                if (random.Next(0, 100) < wallFillPercent)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }
    public int[,] ProcessMap(int[,] map)
    {
        List<List<Vector2Int>> regions = GetRegions(map, mapSize, 1);
        List<Vector2Int> biggestRegion = regions.OrderByDescending(r => r.Count).FirstOrDefault();

        foreach (List<Vector2Int> region in regions)
        {
            if (region != biggestRegion)
            {
                foreach (Vector2Int tile in region)
                {
                    map[tile.x, tile.y] = 0;
                }
            }
        }
        return map;
    }
    public int[,] SetRandomFloorTiles(int[,] map)
    {
        for(int x = 0; x < mapSize.x; x++)
        {
            for(int y = 0; y < mapSize.y; y++)
            {
                if (map[x, y] == 1)
                {
                    map[x, y] = Random.Range(2, 5);
                    
                }
            }
        }
        return map;
    }
    public void RenderMap(int[,] map)
    {
        for (int x = -1; x < mapSize.x + 1; x++)
        {
            for (int y = -1; y < mapSize.y + 1; y++)
            {
                if (x >= 0 && x < mapSize.x && y >= 0 && y < mapSize.y)
                {
                    Vector3Int vector3Intrq = new Vector3Int(x, y);
                    wallTilemap.SetTile(vector3Intrq,null);
                    switch (map[x, y])
                    {
                        case 0:
                            Vector3Int vector3Int = new Vector3Int(x, y);

                            wallTilemap.SetTile(vector3Int, wallTile);
                            break;
                        case 1:
                            Vector3Int vector3Inte = new Vector3Int(x, y);
                            tilemap.SetTile(vector3Inte, groundTile);
                            break;
                        case 2:
                            Vector3Int vector3Intr = new Vector3Int(x, y);
                            tilemap.SetTile(vector3Intr, allGroundTiles[0]);
                            break;
                        case 3:
                            Vector3Int vector3Inta = new Vector3Int(x, y);
                            tilemap.SetTile(vector3Inta, allGroundTiles[1]);
                            break;
                        case 4:
                            Vector3Int vector3In = new Vector3Int(x, y);
                            tilemap.SetTile(vector3In, allGroundTiles[2]);
                            break;
                        case 5:
                            Vector3Int vector3n = new Vector3Int(x, y);
                            tilemap.SetTile(vector3n, allGroundTiles[3]);
                            break;
                    }
                }
                else
                {
                    Vector3Int vector3Int = new Vector3Int(x, y);
                    wallTilemap.SetTile(vector3Int, wallTile);
                }

            }
        }
        wallTilemap.GetComponent<TilemapCollider2D>().enabled = false;
        wallTilemap.GetComponent<TilemapCollider2D>().enabled = true;
    }
    public int[,] SmoothMap(int[,] map)
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                int neighbourCount = GetNeighbourCount(map, new Vector2Int(x, y), 1);
                if (IsBorder(x, y, mapSize))
                {
                    continue;
                }
                if (neighbourCount > 4)
                {
                    map[x, y] = 1;
                }
                else if (neighbourCount < 4)
                {
                    map[x, y] = 0;
                }

            }
        }

        return map;
    }
    public int GetNeighbourCount(int[,] map, Vector2Int pos, int tileType)
    {
        int count = 0;
        for (int neighbourX = pos.x - 1; neighbourX <= pos.x + 1; neighbourX++)
        {
            for (int neighbourY = pos.y - 1; neighbourY <= pos.y + 1; neighbourY++)
            {

                if (neighbourX >= 0 && neighbourX < mapSize.x && neighbourY >= 0 && neighbourY < mapSize.y)
                {
                    //If the neighbour is not the center and a wall tile do count++;
                    if (neighbourX != pos.x || neighbourY != pos.y)
                    {
                        if (map[neighbourX, neighbourY] == tileType)
                            count++;
                    }
                }
                else
                {
                    count++;
                }
            }

        }
        return count;
    }
    bool IsInMapRange(int x, int y, Vector2Int size)
    {
        return x >= 0 && x < size.x && y >= 0 && y < size.y;
    }
    bool IsBorder(int x, int y, Vector2Int size)
    {
        return x == 0 || x == size.x - 1 || y == 0 || y == size.y - 1;
    }

    public List<List<Vector2Int>> GetRegions(int[,] map, Vector2Int size, int tileType)
    {
        List<List<Vector2Int>> regions = new List<List<Vector2Int>>();
        int[,] mapFlags = new int[size.x, size.y];

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                if (mapFlags[x, y] == 0 && map[x, y] == tileType)
                {
                    List<Vector2Int> regionTiles = GetRegionTiles(x, y, map, tileType);
                    regions.Add(regionTiles);

                    foreach (Vector2Int tile in regionTiles)
                    {
                        mapFlags[tile.x, tile.y] = 1;
                    }
                }
            }
        }
        return regions;
    }
    public List<Vector2Int> GetRegionTiles(int startX, int startY, int[,] map, int tileType)
    {
        List<Vector2Int> tiles = new List<Vector2Int>();
        int[,] mapFlags = new int[mapSize.x, mapSize.y];
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(new Vector2Int(startX, startY));
        mapFlags[startX, startY] = 1;

        int[] dirX = { 0, 0, 1, -1 };
        int[] dirY = { 1, -1, 0, 0 };

        while (queue.Count > 0)
        {
            Vector2Int tile = queue.Dequeue();
            tiles.Add(tile);

            for (int i = 0; i < 4; i++)
            {
                int neighbourX = tile.x + dirX[i];
                int neighbourY = tile.y + dirY[i];

                if (IsInMapRange(neighbourX, neighbourY, mapSize) && mapFlags[neighbourX, neighbourY] == 0 && map[neighbourX, neighbourY] == tileType)
                {
                    mapFlags[neighbourX, neighbourY] = 1;
                    queue.Enqueue(new Vector2Int(neighbourX, neighbourY));
                }
            }
        }
        return tiles;
    }


}


