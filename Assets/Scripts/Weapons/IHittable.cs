using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    Agent Agent();
    void GetHit(int damage, Vector2 point);
}
