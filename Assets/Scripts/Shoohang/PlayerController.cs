using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasicPlane
{
    private void Update()
    {
        RotXValue = Input.GetAxis("Vertical");
        RotZValue = Input.GetAxis("Horizontal");
    }
}
