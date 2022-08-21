using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RocketLauncher : MonoBehaviour
{
    //public UnityEvent rocketShot;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform ejectionPoint;
    [SerializeField] private float rocketZLayer;

    [SerializeField] private int ejectionForceMin;
    [SerializeField] private int ejectionForceMax;

    [SerializeField] private int maxMagSize;
    private int magSize;

    [SerializeField] private float reloadTime;
    [SerializeField] private float fireRate;

    private bool canShoot = true;

    private Animator anim;
    private void Start()
    {
        magSize = maxMagSize;
        anim = GetComponent<Animator>(); 
    }

    public void Shoot(float chargeTime)
    {
        if (!canShoot) return;


        anim.SetTrigger("Shoot");
        EventManager.Current.RocketFired();

        GameObject rocket = Instantiate(projectilePrefab, new Vector3(ejectionPoint.position.x, ejectionPoint.position.y, rocketZLayer), transform.rotation);
        rocket.GetComponent<Rigidbody2D>().AddForce(rocket.transform.right * Mathf.Lerp(ejectionForceMin, ejectionForceMax, chargeTime));

        magSize--;
        StartCoroutine(HasShot());

    }

    private IEnumerator HasShot()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);

        if (magSize <= 0)
        {
            yield return new WaitForSeconds(reloadTime);
            EventManager.Current.LauncherReloaded();
            magSize = maxMagSize;
        }

        canShoot = true;

    }


}
