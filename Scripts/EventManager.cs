using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    private static EventManager current;
    public static EventManager Current
    {
        get
        {
            if (current == null)
            {
                print("No instance of Event Manager");
            }
            return current;
        }
    }

    private void Awake()
    {
        current = this;
    }


    public event Action onRocketFired;
    public void RocketFired()
    {
        onRocketFired?.Invoke();
        print("onRicketFired");
    }

    public event Action onLauncherReload;
    public void LauncherReloaded()
    {
        onLauncherReload?.Invoke();
        print("onLauncherReload");

    }

    public event Action<bool> onPlayerGroundedChange;
    public void PlayerGroundedChange(bool grounded)
    {
        onPlayerGroundedChange?.Invoke(grounded);

    }

    public event Action<bool> onPlayerWalking;
    public void PlayerWalking(bool walking)
    {
        onPlayerWalking?.Invoke(walking);

    }

    public event Action onPlayerTouchGoal;
    public void PlayerTouchGoal()
    {
        onPlayerTouchGoal?.Invoke();

    }
}
