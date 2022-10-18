using UnityEngine;

public static class MoveInGrid
{
    public static Vector2 CellPositionInDirection(Vector2 actualPosition, Vector2 direction)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;
        Vector2 result = CellPosition(actualPosition + (direction * gridSize));
        Debug.Log($"MoveInGrid.CellPositionInDirection({actualPosition}, {direction}): {result}");

        return result;
    }

    public static Vector2 CellPosition(Vector2 position)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;

        Vector2 cellIndex = CellIndex(position);
        Vector2 result = cellIndex * gridSize;

        Debug.Log($"MoveInGrid.CellPosition({position}): {result}");

        return result;
    }

    public static Vector2 CellIndex(Vector2 position)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;
        Vector2 result = position / gridSize;
        result = new Vector2(Mathf.Ceil(result.x), Mathf.Ceil(result.y));

        Debug.Log($"MoveInGrid.CellIndex({position}): {result}");

        return result;
    }
}
