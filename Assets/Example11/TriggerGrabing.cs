﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrabing : MonoBehaviour
{
    public GameObject rootPos;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<ClimbUp>().GrabEdge(rootPos.transform);
    }
}
