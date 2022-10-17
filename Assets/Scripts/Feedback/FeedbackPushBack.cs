using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPushBack : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float force = 10f;

    public void Perform(Vector2 point)
    {
        Vector2 direction = ((Vector2)transform.position - point).normalized;
        rb2d.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
