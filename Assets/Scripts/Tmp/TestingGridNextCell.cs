using UnityEngine;

public class TestingGridNextCell : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] Transform destiny;
    float angle;
    Vector2 direction;
    Vector2 nextCellPosition;

    void Update()
    {
        direction = destiny.position - origin.position;
        nextCellPosition = GridUtils.CellPositionInDirection(origin.position, direction);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(nextCellPosition, 0.1f);
    }



    // void OnGUI()
    // {
    //     //Output the angle found above
    //     GUI.Label(new Rect(25, 25, 200, 40), "Angle Between Objects" + angle);
    // }
}
