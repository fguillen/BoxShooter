using UnityEngine;

public class DebugUtils : MonoBehaviour
{
    public void Message(string message)
    {
        Debug.Log($"[DebugUtils] {message}");
    }
}
