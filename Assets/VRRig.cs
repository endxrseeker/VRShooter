using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigtarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;


    public void Map()
    {
        rigtarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigtarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}
public class VRRig : MonoBehaviour
{
    public Transform headConstraint;
    public Vector3 headBodyOffset;
    public VRMap leftHand;
    public VRMap rightHand;
    public VRMap head;

    public void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    public void Update()
    { 
        transform.position = headConstraint.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;

        leftHand.Map();
        rightHand.Map();
        head.Map();
    }
}
