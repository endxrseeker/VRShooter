using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderPos : MonoBehaviour
{
    public GameObject Shoulder;
    public GameObject ShoulderPosition;

    public void Update()
    {
        Shoulder.transform.position = ShoulderPosition.transform.position;
    }
}
