using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ClickToPos : MonoBehaviour
{
    public Camera mainCam;
    public GameObject player;
    public TileMapTracker tilemapTracker;
    public Tilemap groundTilemap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FindMovePos();
    }

    public void FindMovePos()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 worldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
            worldPos.z = 0f;

            Vector3Int tilePos = groundTilemap.WorldToCell(worldPos);
            Debug.Log("Converted to tile position: " + tilePos);

            if (tilemapTracker.IsWalkable(tilePos))
            {
                Vector3 centerWorldPos = groundTilemap.GetCellCenterWorld(tilePos);
                player.GetComponent<ClickedMovment>().SetTargetPosition(centerWorldPos);
            }
            else
            {
                Debug.Log("Clicked position is not walkable: " + tilePos);
            }

            Debug.Log("Clicked world position: " + worldPos);

        }
    }
}
