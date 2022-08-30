using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorTag : XRSocketInteractor
{
    public string targetTag;
    public SimpleShoot SimpleShoot;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        if (base.CanSelect(interactable) && interactable.CompareTag(targetTag))
        {
            SimpleShoot.MagIn = true;
            magazine magazine = interactable.gameObject.GetComponent<magazine>();
            SimpleShoot.MagazineEnter(magazine);
            return true;
        }
        else
        {
            SimpleShoot.MagIn = false;
            return false;
        }
    }
}
