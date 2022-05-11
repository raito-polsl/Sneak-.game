using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeImpact : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Ps;
    public GameObject Trail;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        else { 
            Ps.Play();
            Trail.SetActive(false);
            gameObject.GetComponent<MeshRenderer>().enabled =false;
            Destroy(gameObject,0.75f);
        }
    }
}
