// From here: https://medium.com/@indivisibleparticles/a-simple-way-to-move-an-object-in-a-spiral-around-a-point-in-unity-bbf3fbab21f9

using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    [SerializeField] Transform moveable;
    [SerializeField] public Transform destiny;
    [SerializeField] float speed;

    // as higher as smoother approach, but it can not be more than 90, or it will start getting away.
    [SerializeField][Range(0f, 89f)] float angle = 60f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = destiny.position - moveable.position;
        direction = Quaternion.Euler(0, 0, angle) * direction;
        float distanceThisFrame = speed * Time.deltaTime;

        moveable.transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
}
