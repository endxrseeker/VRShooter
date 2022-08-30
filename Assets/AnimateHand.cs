using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHand : MonoBehaviour
{
    public InputActionProperty fistAnimAction;
    public InputActionProperty pointAnimAction;
    public Animator animator;

    private void Update()
    {
        float trigger = fistAnimAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", trigger);

        float grip = pointAnimAction.action.ReadValue<float>();
        animator.SetFloat("Grip", grip);
    }
}
