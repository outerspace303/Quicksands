using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile: MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;
    
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable => isPlaceable;

    private GridManager _gridManager;
    private PathFinder _pathFinder;
    private Vector2Int coordinates = new Vector2Int();

    private void Start()
    {
        if (_gridManager != null)
        {
            coordinates = _gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable)
            {
                _gridManager.BlockNode(coordinates);
            }
        }
    }

    private void Awake()
    {
        _pathFinder = FindObjectOfType<PathFinder>();
        _gridManager = FindObjectOfType<GridManager>();
    }
    
    private void OnMouseDown()
    {
        if(_gridManager.getNode(coordinates).isWalkable && !_pathFinder.WillBlockPath(coordinates))
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
            _gridManager.BlockNode(coordinates);
        }

    }
}
