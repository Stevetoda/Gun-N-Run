using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 3f;
    public float range = 3f;
    public float explosionRadius = 0.1f;
    public GameObject contactEffect;
    public string enemyTag = "enemy";

    //the furthest it can travel
    private Vector3 targetPosition;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.right.x >= 0)
        {
            targetPosition = new Vector3(transform.right.x + range, transform.right.y, transform.right.z);
        }
        else
        {
            targetPosition = new Vector3(transform.right.x - range, transform.right.y, transform.right.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float distancePerFrame = bulletSpeed * Time.deltaTime;
        //distance to the furthest bullet can travel
        dir = targetPosition - transform.position;

        if(dir.magnitude <= distancePerFrame)
        {
            //Debug.Log("done");
            HitTarget();
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with: " + collision.collider.name);
        HitTarget();
    }

    public void HitTarget()
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(contactEffect, transform.position, transform.rotation);
        Explode();
        Destroy(effect, 1f);
    }

    void Explode()
    {
        //return a list of things overlapped within certain range
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach(Collider2D tempCollider in colliders)
        {
            if (tempCollider.tag == enemyTag)
            {
                Debug.Log("destroying: " + tempCollider.name);
                DamageTarget(tempCollider.gameObject);
            }
        }
    }

    //we may implment the hp for enemy later
    void DamageTarget(GameObject enemy)
    {
        Destroy(enemy);
    }

    //for developer
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
