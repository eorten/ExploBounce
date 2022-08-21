using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Animator feetAnimator;
    private void Start()
    {
        EventManager.Current.onPlayerGroundedChange += Current_onPlayerGroundedChange;
        EventManager.Current.onPlayerWalking += Current_onPlayerWalking;
    }

    private void Current_onPlayerWalking(bool obj)
    {
        feetAnimator.SetBool("walking", obj);
    }

    private void Current_onPlayerGroundedChange(bool obj)
    {
        //anim.SetBool("Airborne", !obj);


        playerAnimator.Play(!obj ? "Airborne" : "LandingAnim");
    }

    private void OnDestroy()
    {
        EventManager.Current.onPlayerWalking -= Current_onPlayerWalking;
        EventManager.Current.onPlayerGroundedChange -= Current_onPlayerGroundedChange;

    }
}
