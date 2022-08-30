using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Glock : MonoBehaviour
{
    public GameObject baseMag;
    public GameObject leftHand;
    public GameObject ReloadTest;

    public InputActionProperty shootAction;

    public int maxAmmo;
    int ammoCount;
    int magAmmo;

    public bool equipped;
    bool semiAutoShoot;

    GunStates state;

    magazine mag;
    public SimpleShoot shoot;

    public enum GunStates
    {
        Ready,
        NoAmmo
    }

    public void Start()
    {
        ammoCount = maxAmmo;
        magAmmo = maxAmmo;
    }

    public void Update()
    {
        float trigger = shootAction.action.ReadValue<float>();

        if(transform.parent != null)
        {
            equipped = true;
        }
        else equipped = false;

        if(trigger >= 0.7 && equipped && mag.ammo > 0 && !semiAutoShoot)
        {
            semiAutoShoot = true;
            print("shooting" + mag.ammo);
            mag.ammo--;
            shoot.shooting();
        }
        else if (trigger <= .7)
        {
            semiAutoShoot = false;
        }

        //if (equipped && trigger >= .7 && !semiAutoShot && ammoCount > 0)
        //{
        //    semiAutoShot = true;
        //    print("Am Shooting");
        //    ammoCount--;
        //    magAmmo--;
        //}

        //if(baseMag.transform.parent == leftHand.transform && !oneInChamber)
        //{
        //    print("left hand");
        //    ammoCount = 1;
        //    oneInChamber = true;
        //}


    }
}
