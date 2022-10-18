using UnityEngine;

public static class MovementUtils
{
    public static Vector2 DirectionDiscrete(Vector2 direction)
    {
        int x = Mathf.RoundToInt(direction.x);
        int y = x == 0 ? Mathf.RoundToInt(direction.y) : 0;
        Vector2 result = new Vector2(x, y);

        return result;
    }
}
