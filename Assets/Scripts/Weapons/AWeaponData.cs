using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AWeaponData : ScriptableObject, IEquatable<AWeaponData>
{
    public string weaponName;
    public int damage;
    public Sprite sprite;
    public AudioClip soundEffect;
    public LayerMask hittableMask;

    public bool Equals(AWeaponData other)
    {
        return weaponName == other.weaponName;
    }

    public abstract bool CanBeUsed(Agent agent);
    public abstract void Attack(Agent agent);

    public virtual void DrawGizmo(Agent agent) {}
}
