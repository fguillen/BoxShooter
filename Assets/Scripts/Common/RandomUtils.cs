using UnityEngine;

public static class RandomUtils
{
    public static Vector2 RandomPointInBox(BoxCollider2D collider)
    {
        // var center = (Vector2)collider.transform.localPosition + collider.offset;
        var center = collider.bounds.center;
        var size = collider.bounds.size;

        float x = UnityEngine.Random.Range(center.x - size.x, center.x + size.x);
        float y = UnityEngine.Random.Range(center.y - size.y, center.y + size.y);

        Vector2 result = new Vector2(x, y);

        return result;
    }
}
