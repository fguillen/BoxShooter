using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPushBack : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float force = 10f;
    float previousDrag;

    public void Perform(Vector2 point)
    {
        Debug.Log($"FeedbackPushBack({transform.position}, {point})");

        Vector2 direction = ((Vector2)transform.position - point).normalized;
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(direction * force, ForceMode2D.Impulse);

        previousDrag = rb2d.drag;
        rb2d.drag = 4f;

        Invoke("SetPreviousDrag", 1f);
    }

    void SetPreviousDrag()
    {
        rb2d.drag = previousDrag;
    }
}
