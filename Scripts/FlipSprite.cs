using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    //Flip x og y på rakett
    [Header("Axis")]
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;
    [SerializeField] private Vector3 scale1;
    [SerializeField] private Vector3 scale2;


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x)
        {
            Vector3 newVec = scale1;
            if (x) newVec.x *= -1;
            if (y) newVec.y *= -1;
            if (z) newVec.z *= -1;

            transform.localScale = newVec;
        }
        else if (mousePos.x > transform.position.x)
        {
            Vector3 newVec = scale2;
            if (x) newVec.x *= -1;
            if (y) newVec.y *= -1;
            if (z) newVec.z *= -1;

            transform.localScale = newVec;
        }
    }

}
