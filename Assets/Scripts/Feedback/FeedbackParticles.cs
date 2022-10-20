using UnityEngine;

public class FeedbackParticles : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void InstantiatePrefab()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
