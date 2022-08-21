using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private RocketLauncher rl;
    private bool charging = false;
    private float chargeTime;
    private void Update()
    {
        /*
        if (charging)
        {
            chargeTime += Time.deltaTime;
        }
        */
        GetInput();
    }

    private void GetInput()
    {
        /*
        if (Input.GetMouseButtonDown(0)) charging = true;
        if (Input.GetMouseButtonUp(0))
        {
            rl.Shoot(Mathf.Clamp(chargeTime, 0, 1f));
            charging = false;
            chargeTime = 0;
        }
        */
        if(Input.GetMouseButtonDown(0)) rl.Shoot(1);

    }
}
