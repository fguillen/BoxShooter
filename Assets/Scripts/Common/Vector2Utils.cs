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
        bool result = (angle % (Mathf.PI / 2) == 0);

        return result;
    }
}
