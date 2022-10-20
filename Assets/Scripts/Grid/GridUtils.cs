using UnityEngine;

public static class GridUtils
{
    public static Vector2 CellPositionInDirection(Vector2 actualPosition, Vector2 direction)
    {
        float gridSize = GameManager.instance.gameConfiguration.gridSize;
        Vector2 actualCellIndex = CellIndexByPosition(actualPosition);
        Vector2 directionDiscrete = Vector2Utils.DirectionDiscrete(direction);
        Vector2 actualCellPosition = CellPositionByIndex(actualCellIndex);
        Vector2 directionDiscreteToActualCellPosition = Vector2Utils.DirectionDiscrete(actualCellPosition - actualPosition);

        // Debug.Log($"actualCellIndex: {actualCellIndex}");
        // Debug.Log($"directionDiscrete: {directionDiscrete}");
        // Debug.Log($"actualCellPosition: {actualCellPosition}");
        // Debug.Log($"directionDiscreteToActualCellPosition: {directionDiscreteToActualCellPosition}");


        if(directionDiscreteToActualCellPosition == directionDiscrete)
            return actualCellPosition;

        Vector2 nextCellIndex = actualCellIndex + directionDiscrete;
        Vector2 result = CellPositionByIndex(nextCellIndex);
        // Debug.Log($"GridUtils.CellPositionInDirection({actualPosition}, {direction}): {result}");

        return result;
    }

    public static Vector2 CellPositionByPosition(Vector2 position)
    {
        Vector2 cellIndex = CellIndexByPosition(position);
        Vector2 result = CellPositionByIndex(cellIndex);

        // Debug.Log($"GridUtils.CellPosition({position}): {result}");

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
        result = new Vector2(Mathf.Round(result.x), Mathf.Round(result.y));

        // Debug.Log($"GridUtils.CellIndexByPosition({position}): {result}");

        return result;
    }
}
