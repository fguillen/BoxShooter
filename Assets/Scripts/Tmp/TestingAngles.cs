using UnityEngine;

public class TestingAngles : MonoBehaviour
{
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    float angle;

    void Update()
    {


        Vector2 directionBetweenVectors = Vector2Utils.DirectionBetweenVectors(position1.position, position2.position);
        float angleBetweenVectors = Vector2Utils.AngleBetweenVectors(position1.position, position2.position);
        float angleBetweenVectorsInDegrees = Vector2Utils.AngleBetweenVectorsInDegrees(position1.position, position2.position);
        Debug.Log($"directionBetweenVectors: {directionBetweenVectors}, angleBetweenVectors: {angleBetweenVectors}, angleBetweenVectorsInDegrees: {angleBetweenVectorsInDegrees}");
    }

    // void OnGUI()
    // {
    //     //Output the angle found above
    //     GUI.Label(new Rect(25, 25, 200, 40), "Angle Between Objects" + angle);
    // }
}
