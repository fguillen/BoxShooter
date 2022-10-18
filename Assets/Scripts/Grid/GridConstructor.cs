using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridConstructor : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] GameObject cellPrefab;

    void Start()
    {
        BuildGrid();
    }

    void BuildGrid()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector2 cellIndex = new Vector2(x, y);
                Vector2 position = GridUtils.CellPositionByIndex(cellIndex);
                InstantiateCell(position);
            }
        }
    }

    void InstantiateCell(Vector2 position)
    {
        Instantiate(cellPrefab, position, Quaternion.identity);
    }
}
