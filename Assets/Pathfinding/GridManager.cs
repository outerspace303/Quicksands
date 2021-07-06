using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;

    [Tooltip("World grid size - should match UnityEditor snap settings")] 
    [SerializeField]
    private int unityGridSize = 10;
    public int UnityGridSize => unityGridSize;

    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid => grid;


    private void Awake()
    {
        CreateGrid();
    }

    public Node getNode(Vector2Int coordinates)
    {
        return grid.ContainsKey(coordinates) ? grid[coordinates] : null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;
        return position;
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}
