using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine : MonoBehaviour
{
    public int ammo = 12;
    GameObject AmmoCase;

    private void Awake()
    {
        AmmoCase = transform.GetChild(1).gameObject;
    }

    public void Update()
    {
        if(ammo > 0)
        {
            AmmoCase.SetActive(true);
        }
        else AmmoCase.SetActive(false);
    }
}
