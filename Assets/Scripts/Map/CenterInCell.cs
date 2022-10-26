using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterInCell : MonoBehaviour
{
    void Start()
    {
        Center();
    }

    public void Center()
    {
        transform.position = GridUtils.CellPositionByPosition(transform.position);
    }
}
