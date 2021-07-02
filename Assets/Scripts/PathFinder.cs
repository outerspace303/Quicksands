using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Node currentSearchNode;
    private Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    private GridManager _gridManager;
    private Dictionary<Vector2Int, Node> grid;

    [SerializeField] List<Node> neighbours;

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        if (_gridManager != null)
        {
            grid = _gridManager.Grid;
        }
    }

    private void Start()
    {
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        neighbours = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int searchNode = currentSearchNode.coordinates + direction;
            if (grid.ContainsKey(searchNode))
            {
                neighbours.Add(grid[searchNode]);
                
                // for testing purposes
                grid[searchNode].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }

    }
}
