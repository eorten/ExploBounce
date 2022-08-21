using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform objToFollow;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool lerp;
    [SerializeField] private float lerpFac;

    [Header("Axis")]
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;


    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(0, 0, 0);
        if (x) newPos.x = objToFollow.transform.position.x;
        if (y) newPos.y = objToFollow.transform.position.y;
        if (z) newPos.z = objToFollow.transform.position.z;


        if (!lerp)
        {
            transform.position = newPos + offset;

        }
        else
        {
            float fac = (newPos - transform.position).magnitude;
            transform.position = Vector3.Lerp(transform.position, newPos, fac * lerpFac) + offset;
        }

    }
}
