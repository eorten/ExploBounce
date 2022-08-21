using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool active = true;
    private GameObject player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovementController>().gameObject;
    }
    private void Update()
    {
        if (active)
        {
            if (player.transform.position.x > transform.position.x && transform.position.x - player.transform.position.x < 3)
            {
                EventManager.Current.PlayerTouchGoal();
                active = false;
            }
        }
    }
}
