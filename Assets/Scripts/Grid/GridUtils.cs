using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class GridUtils
{
    public static Vector2 CellPositionInDirection(Vector2 actualPosition, Vector2 direction)
    {
        float gridSize = GridSize();
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
        float gridSize = GridSize();

        return index * gridSize;
    }

    public static Vector2 CellIndexByPosition(Vector2 position)
    {
        float gridSize = GridSize();
        Vector2 result = position / gridSize;
        result = new Vector2(Mathf.Round(result.x), Mathf.Round(result.y));

        // Debug.Log($"GridUtils.CellIndexByPosition({position}): {result}");

        return result;
    }

    public static float GridSize()
    {
        #if UNITY_EDITOR
            var path = "Assets/Data/Game/GameConfiguration.asset";
            GameConfiguration gameConfiguration = AssetDatabase.LoadAssetAtPath<GameConfiguration>(path);
            return gameConfiguration.gridSize;
        #else
            return GameManager.instance.gameConfiguration.gridSize;
        #endif
    }
}
