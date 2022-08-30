using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpController : MonoBehaviour
{
    public InputActionProperty triggerInput;
    public InputActionProperty gripInput;
    public GameObject indexTop;

    public GameObject MR;

    public List<GameObject> itemInHand = new List<GameObject>();

    float grip;
    float trigger;
    bool triggerPress;

    private void Update()
    {
        trigger = triggerInput.action.ReadValue<float>();
        grip = gripInput.action.ReadValue<float>();
        if (trigger >= 0.5f && !triggerPress)
        {
            triggerPress = true;
            PickUp();
        }
        if (grip >= 0.5 && trigger <= 0.5)
        {
            if (itemInHand.Count > 0)
            {
                Drop();
            }
        }

        if(trigger <= 0.5)
        {
            triggerPress = false;
        }

        if(itemInHand.Count > 0)
        {
            SkinnedMeshRenderer mr = MR.GetComponent<SkinnedMeshRenderer>();
            mr.enabled = false;
        }
        else
        {
            SkinnedMeshRenderer mr = MR.GetComponent<SkinnedMeshRenderer>();
            mr.enabled = true;
        }
    }

    public void PickUp()
    {
        Collider[] colldiers = Physics.OverlapSphere(transform.position, 0.2f);
        foreach(Collider collider in colldiers)
        {

            if (transform.name != "Left Hand")
            {
                if (collider.transform.tag == "PickUp")
                {
                    if (itemInHand.Count < 1)
                    {
                        itemInHand.Add(collider.transform.gameObject);
                        Rigidbody rb = collider.transform.GetComponent<Rigidbody>();

                        collider.transform.position = transform.position;
                        collider.transform.parent = transform;
                        rb.isKinematic = true;
                    }
                }
                if (collider.transform.tag == "Gun")
                {
                    if (itemInHand.Count < 1)
                    {
                        itemInHand.Add(collider.transform.gameObject);
                        Rigidbody rb = collider.transform.GetComponent<Rigidbody>();

                        collider.transform.position = transform.position;
                        collider.transform.parent = transform;
                        rb.isKinematic = true;
                        collider.transform.rotation = transform.rotation;
                    }
                }
            }
            else if(collider.transform.tag == "Mag")
            {
                itemInHand.Add(collider.transform.gameObject);
                //Rigidbody rb = collider.transform.GetComponent<Rigidbody>();

                collider.transform.position = transform.position;
                collider.transform.parent = transform;
                //rb.isKinematic = true;
                collider.transform.rotation = transform.rotation;
            }
        }
    }

    public void Drop()
    {
        if (grip >= 0.5 && trigger <= 0.5)
        {
            for (int i = 0; i < itemInHand.Count; i++)
            {
                Rigidbody rb = itemInHand[i].GetComponent<Rigidbody>();
                itemInHand[i].transform.parent = null;   
                itemInHand.Remove(itemInHand[i]);
                rb.isKinematic = false;

            }
        }
    }
}
