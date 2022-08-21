using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
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
            if (player.transform.position.x > transform.position.x)
            {
                player.GetComponent<PlayerMovementController>().SetCheckPoint(new Vector2(transform.position.x, transform.position.y + 1));
                active = false;
            }
        }
    }
}
