using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    float originalScaleX;

    void Awake()
    {
        originalScaleX = Mathf.Abs(transform.parent.localScale.x);
    }

    public void FaceDirection(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) < 0.01f) return;

        float newScaleX = (direction.x < 0f) ? (-1 * originalScaleX) : originalScaleX;

        transform.localScale = new Vector3(newScaleX, transform.parent.localScale.y, transform.parent.localScale.z);
    }
}
