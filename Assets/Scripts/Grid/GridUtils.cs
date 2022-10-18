using UnityEngine;

public static class GridUtils
{
    public static Vector2 CellPositionInDirection(Vector2 actualPosition, Vector2 direction)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;
        Vector2 result = CellPositionByPosition(actualPosition + (direction * gridSize));
        Debug.Log($"GridUtils.CellPositionInDirection({actualPosition}, {direction}): {result}");

        return result;
    }

    public static Vector2 CellPositionByPosition(Vector2 position)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;

        Vector2 cellIndex = CellIndexByPosition(position);
        Vector2 result = CellPositionByIndex(cellIndex);

        Debug.Log($"GridUtils.CellPosition({position}): {result}");

        return result;
    }

    public static Vector2 CellPositionByIndex(Vector2 index)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;

        return index * gridSize;
    }

    public static Vector2 CellIndexByPosition(Vector2 position)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;
        Vector2 result = position / gridSize;
        result = new Vector2(Mathf.Ceil(result.x), Mathf.Ceil(result.y));

        Debug.Log($"GridUtils.CellIndexByPosition({position}): {result}");

        return result;
    }
}
