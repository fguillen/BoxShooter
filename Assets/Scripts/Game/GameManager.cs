using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameConfiguration gameConfiguration;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
}
