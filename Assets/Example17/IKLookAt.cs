using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLookAt : MonoBehaviour
{
    public Transform target;
    public float weight = 1f;
     Animator anim;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Callback for setting up animation IK (inverse kinematics).
    /// </summary>
    /// <param name="layerIndex">Index of the layer on which the IK solver is called.</param>
    void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtPosition(target.position);
        anim.SetLookAtWeight(weight); 
    }
}
