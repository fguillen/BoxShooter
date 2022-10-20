using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterInCell : MonoBehaviour
{
    void Start()
    {
        transform.position = GridUtils.CellPositionByPosition(transform.position);
    }
}
