using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color blockedColor = Color.red;
    [SerializeField] private Color exploredColor = Color.magenta;
    [SerializeField] private Color pathColor = new Color(1f, 0.5f, 0f);
    
    private TextMeshPro label;
    private Vector2Int coordinates;
    private GridManager _gridManager;

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;

        }
        SetLabelColor();
        ToggleLabels();

    }

    private void SetLabelColor()
    {
        if (_gridManager == null) { return; }

        Node node = _gridManager.getNode(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        
        else
        {
            label.color = defaultColor;
        }
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }

    }

    private void DisplayCoordinates()
    {
        if(_gridManager == null) {return;}
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / _gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / _gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
