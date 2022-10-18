using UnityEngine;

public class RotatorTowardsDirection : MonoBehaviour
{
    [SerializeField] Vector2 direction;

    public void Rotate(Vector2 direction)
    {
        this.direction = direction;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = target;
    }

    void OnValidate()
    {
        Rotate(direction);
    }
}
