using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameConfiguration gameConfiguration;
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
}
