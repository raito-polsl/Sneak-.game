using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyChildren : MonoBehaviour
{
    public Material m;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        { 
            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.AddComponent<SphereCollider>();
            child.gameObject.GetComponent<Renderer>().material = m;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
