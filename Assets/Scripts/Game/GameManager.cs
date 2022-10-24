using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameConfiguration gameConfiguration;
    public static GameManager instance;

    public MapManager mapManager;

    void Awake()
    {
        instance = this;
        mapManager = GameObject.FindObjectOfType<MapManager>();
    }
}
