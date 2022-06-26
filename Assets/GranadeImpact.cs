using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeImpact : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Ps;
    public GameObject Trail;
    public GameObject[] enemylist;
    public float radius = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        else { 

            Ps.Play();

            transform.GetComponent<AudioSource>().Play();
            Trail.SetActive(false);

           
            foreach (GameObject nearbyObject in enemylist) {
                if (nearbyObject.CompareTag("Enemy")) {
                    if(Vector3.Distance(transform.position,nearbyObject.transform.position) < radius) { 
                    Patroling p = nearbyObject.GetComponent<Patroling>();
                    p.isEmp = true;
                    p.countdown = 5f;
                    FieldOfView fov = nearbyObject.GetComponent<FieldOfView>();
                    fov.isEmp = true;
                    fov.countdown = 5f;
                    }
                }
            }
            gameObject.GetComponent<MeshRenderer>().enabled =false;
            Destroy(gameObject,0.75f);

        }
    }
}
