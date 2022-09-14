using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCollision : MonoBehaviour
{
    public GameObject shardGameObject;
    public GameObject[] enemylist;
    public float radius = 30f;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject e = Instantiate(shardGameObject);
        e.transform.position = transform.position;


        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        else
        {
            foreach (GameObject nearbyObject in enemylist)
            {
                if (nearbyObject.CompareTag("Enemy"))
                {
                    if (Vector3.Distance(transform.position, nearbyObject.transform.position) < radius)
                    {
                        Patroling p = nearbyObject.GetComponent<Patroling>();
                        p.ostatniaPozycja = new GameObject("lastHear");
                        p.ostatniaPozycja.transform.position = transform.position;
                        p.kameraWykryla = true;
                        Debug.Log("siema");


                    }
                }
            }
            Destroy(gameObject);
        }
    }

}
