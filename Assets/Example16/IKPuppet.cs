using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKPuppet : MonoBehaviour
{
    public Transform target;
    Animator animator;
    float weight = 1f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Callback for setting up animation IK (inverse kinematics).
    /// </summary>
    /// <param name="layerIndex">Index of the layer on which the IK solver is called.</param>
    void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPosition(AvatarIKGoal.RightHand,target.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand,weight);
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            target.transform.Translate(0f,0.1f,0f);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            target.transform.Translate(0f,-0.1f,0f);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            target.transform.Translate(0.1f,0f,0f);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            target.transform.Translate(-0.1f,0f,0f);
        }
    }
}
