using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private int explosionForce;
    [SerializeField] private float explosionSize;
    [SerializeField] private LayerMask ignore;
    [SerializeField] private GameObject explosionAnimation;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
       //Gizmos.DrawSphere(transform.position, explosionSize);
    }

    private void Update()
    {
        Vector3 rotation = rb.velocity;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Finn, raycast mellom
        if (collision.transform.gameObject.layer == 7)
        {
            Collider2D thisCollider = GetComponent<Collider2D>();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionSize);

            //for alle colliders innen radiusen til eksplosjonen
            foreach (var collider in colliders)
            {
                if (collider == thisCollider) break;

                //Om den har rigidbody (blir påvirket av fysikk)
                if (collider.GetComponent<Rigidbody2D>() != null)
                {

                    //Kast et ray fra objektet til raketten (se om noe er mellom)
                    RaycastHit2D hit = Physics2D.Raycast(transform.position,  collider.transform.position- transform.position, Mathf.Infinity, ~ignore);
                    if (hit.collider == collider)
                    {
                        //Hvis rayet treffer raketten er ingen ting mellom, og raketten dytter objektet bort
                        Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
                        Vector2 dirVec = new Vector2(collider.transform.position.x - transform.position.x, collider.transform.position.y - transform.position.y).normalized;
                        rb.velocity = dirVec * explosionForce;
                        //rb.AddForce(dirVec * explosionForce, ForceMode2D.Impulse);
                    }
                }
            }
            Destroy(gameObject);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (explosionAnimation != null)
        {
            Instantiate(explosionAnimation, transform.position + new Vector3(0, 0, 0.2f), Quaternion.identity);
        }

        if (collision.gameObject.tag == "Pool")
        {
            Destroy(gameObject);
            return;
        }
        //Finn, raycast mellom
        if (collision.transform.gameObject.layer == 7)
        {
            Collider2D thisCollider = GetComponent<Collider2D>();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionSize);

            //for alle colliders innen radiusen til eksplosjonen
            foreach (var collider in colliders)
            {
                if (collider == thisCollider) break;

                //Om den har rigidbody (blir påvirket av fysikk)
                if (collider.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
                    Vector2 dirVec = new Vector2(collider.transform.position.x - transform.position.x, collider.transform.position.y - transform.position.y).normalized;
                    rb.velocity = dirVec * explosionForce;
                }
            }
            Destroy(gameObject);
        }
    }
}
