using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    [SerializeField] Transform moveable;
    [SerializeField] public Transform destiny;
    [SerializeField] float speed;
    [SerializeField][Range(0f, 89f)] float angle = 60f;

    void Update()
    {
        Move();
    }

    // public void Move()
    // {
    //     moveable.LookAt(destiny);
    //     moveable.Translate(moveable.forward * Time.deltaTime * speed);
    //     moveable.RotateAround(destiny.position, Vector2.right, 20000 * Time.deltaTime);
    // }

    void Move()
    {
        Vector3 direction = destiny.position - moveable.position;
        direction = Quaternion.Euler(0, 0, angle) * direction;
        float distanceThisFrame = speed * Time.deltaTime;

        moveable.transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
}
