using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMeter : MonoBehaviour
{
    [SerializeField] private GameObject[] sprites;
    private int iter = 0;
    public void RemoveAmmo()
    {
        sprites[iter].SetActive(false);
        iter++;
    }
    public void Reload()
    {
        iter = 0;
        foreach (var item in sprites)
        {
            item.SetActive(true);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        EventManager.Current.onRocketFired += OnRocketFired;
        EventManager.Current.onLauncherReload += EventManager_onLauncherReload;
    }

    private void OnRocketFired()
    {
        print("Recieved event");

        RemoveAmmo();
    }

    private void EventManager_onLauncherReload()
    {
        Reload();
    }

    private void OnDestroy()
    {
        EventManager.Current.onLauncherReload -= EventManager_onLauncherReload;
        EventManager.Current.onRocketFired -= OnRocketFired;
    }
}
