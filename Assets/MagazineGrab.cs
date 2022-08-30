using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagazineGrab : MonoBehaviour
{
    //public InputActionProperty gripInput;

    //public Collider handCollider;
    //public Collider magCollider;

    public GameObject magazinePref;

    //public void Update()
    //{
    //    float grip = gripInput.action.ReadValue<float>();

    //    if(grip >= 0.5)
    //    {
    //        Grab();
    //    }
    //}

    //void Grab()
    //{
    //    Collider[] colliders = (Physics.OverlapSphere(handCollider.transform.position, 0.5f));

    //    foreach(Collider collider in colliders)
    //    {
    //        if(collider.transform.name == "Mag Spawner")
    //        {
    //            Instantiate(magazinePref, handCollider.transform.position, handCollider.transform.rotation);
    //        }
    //    }
    //}

    private void Update()
    {
        if(transform.childCount == 0)
        {
            Instantiate(magazinePref, transform.position, transform.rotation);
        }
    }
}
