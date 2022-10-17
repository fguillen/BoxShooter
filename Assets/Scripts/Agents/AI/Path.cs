using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{
    PolygonCollider2D polygon;
    List<Vector2> points;

    void Awake()
    {
        polygon = GetComponent<PolygonCollider2D>();
        points = polygon.points.ToList().Select(e => (Vector2)transform.TransformPoint(e)).ToList();
    }

    public Vector2 ClosestPoint(Vector2 position)
    {
        return points.OrderBy(e => (e - position).magnitude).ToList().First();
    }

    public Vector2 NextPoint(Vector2 actualPoint)
    {
        int index = points.IndexOf(actualPoint);
        int nextIndex = index == points.Count - 1 ? 0 : index + 1;

        return points[nextIndex];
    }
}
