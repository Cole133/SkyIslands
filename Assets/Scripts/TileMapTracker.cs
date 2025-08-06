using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTracker : MonoBehaviour
{
    public Tilemap groundTilemap;
    public HashSet<Vector3Int> walkableTiles = new HashSet<Vector3Int>();

    void Start()
    {
        // Scan the bounds of the tilemap and store all non-empty tiles
        BoundsInt bounds = groundTilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                for (int z = bounds.zMin; z < bounds.zMax; z++)
                {
                    Vector3Int rawPos = new Vector3Int(x, y, z);

                    if (groundTilemap.HasTile(rawPos))
                    {
                        // Normalize the position to z = 0 for consistency
                        Vector3Int normalizedPos = new Vector3Int(x, y, 0);
                        walkableTiles.Add(normalizedPos);
                        break; 
                    }
                }
            }
        }


        Debug.Log($"Walkable tiles loaded: {walkableTiles.Count}");
    }

    // Helper method for others to check walkability
    public bool IsWalkable(Vector3Int tilePos)
    {
        tilePos.z = 0;
        return walkableTiles.Contains(tilePos);
    }

    // Later: public void AddTile(Vector3Int pos) to support island expansion
}
