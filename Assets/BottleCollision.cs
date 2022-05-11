using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCollision : MonoBehaviour
{
    public GameObject shardGameObject;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject e = Instantiate(shardGameObject);
        e.transform.position = transform.position;
        Destroy(gameObject);
    }
}
