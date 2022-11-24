using UnityEngine;

public static class Vector2Utils
{
    public static Vector2 DirectionBetweenVectors(Vector2 position1, Vector2 position2)
    {
        return position2 - position1;
    }

    public static float AngleBetweenVectors(Vector2 position1, Vector2 position2)
    {
        Vector2 direction = DirectionBetweenVectors(position1, position2);
        float result = Mathf.Atan2(direction.y, direction.x);

        return result;
    }

    public static float AngleBetweenVectorsInDegrees(Vector2 position1, Vector2 position2)
    {
        float angleInRadians = AngleBetweenVectors(position1, position2);
        return angleInRadians * Mathf.Rad2Deg;
    }

    public static bool AngleBetweenVectorsIs90DegreesMultiple(Vector2 position1, Vector2 position2)
    {
        float angle = AngleBetweenVectors(position1, position2);
        float angleMod = angle % (Mathf.PI / 2);
        bool result = angleMod == 0f;

        // Debug.Log($"AngleBetweenVectorsIs90DegreesMultiple: {angle}, {angleMod}, {result}");

        return result;
    }

    public static Vector2 DirectionDiscrete(Vector2 direction)
    {
        direction = direction.normalized;
        int x = Mathf.RoundToInt(direction.x);
        int y = x == 0 ? Mathf.RoundToInt(direction.y) : 0;
        Vector2 result = new Vector2(x, y);
        result = result.normalized;

        return result;
    }

    public static Quaternion ToRotation(Vector2 vector)
    {
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public static bool CloseEnough(Vector2 vectorA, Vector2 vectorB, float offset)
    {
        return (vectorA - vectorB).magnitude < offset;
    }
}
