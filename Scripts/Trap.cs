using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Col");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovementController>().MoveToCheckpoint();
        }
    }

}
