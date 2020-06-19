using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanMove : MonoBehaviour
{
    public float speedRunning = 1;
    public Transform targetLeft;
    public Transform targetRight;
    public Transform targetAnchor;
    public Transform centerAnchor;
    public Camera camera;
    float weight = 1f;
    bool isPistol;
    Animator anim;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnAnimatorIK(int layerIndex)
    {
        if(isPistol){
            anim.SetIKPosition(AvatarIKGoal.RightHand,targetRight.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand,weight);
            anim.SetIKPosition(AvatarIKGoal.LeftHand,targetLeft.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand,weight);
            anim.SetLookAtPosition(targetAnchor.position);
            anim.SetLookAtWeight(weight); 
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift)){
            speedRunning += Time.deltaTime;
            speedRunning = Mathf.Clamp(speedRunning,1,2);
        }
        else{
            speedRunning -= Time.deltaTime;
            speedRunning = Mathf.Clamp(speedRunning,1,2);
        }

        anim.SetFloat("Speed",translationZ*speedRunning);
        anim.SetFloat("TurnBody",translationX);

        if(Input.GetKey(KeyCode.Mouse1)) {
            var fieldCamera = camera.fieldOfView - (Time.deltaTime *250f);
            camera.fieldOfView = Mathf.Clamp(fieldCamera,31,60);
            isPistol = true;
            LookPistol();
            OnAnimatorIK(0);
            anim.SetBool("isPistol", true);
        }
        else{
            var fieldCamera = camera.fieldOfView + (Time.deltaTime *500f);
            camera.fieldOfView = Mathf.Clamp(fieldCamera,31,60);
            isPistol = false;
            anim.SetBool("isPistol", false);
        }

        
    }

    void LookPistol(){
        float mouseX = Input.GetAxis("Mouse X")*100*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*100*Time.deltaTime;
        xRotation -=mouseY;
        xRotation = Mathf.Clamp(xRotation,-14f,14f);
        yRotation +=mouseX;
        yRotation = Mathf.Clamp(yRotation,0,12f);
        Debug.Log(yRotation);
        centerAnchor.localRotation = Quaternion.Euler(xRotation,yRotation,0f);
    }
}
