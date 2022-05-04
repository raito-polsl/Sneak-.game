using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject item;
    public bool canPickup;
    public int granades;
    // Start is called before the first frame update
    void Start()
    {
        granades = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickup == true) {
            if (Input.GetKeyDown(KeyCode.F)) { 
                Destroy(item);
                item = null;
                granades++;
                canPickup = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item") {
            item = other.gameObject;
            canPickup = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            item = null;
            canPickup = false;
        }
    }
}
