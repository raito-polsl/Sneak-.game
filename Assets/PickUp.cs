using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject granadePickUp;
    public GameObject bottlePickUp;
    public bool canPickupGranade;
    public bool canPickupBottle;
    public int granades;
    public int bottles;
    // Start is called before the first frame update
    void Start()
    {
        granades = 0;
        bottles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickupGranade == true) {
            if (Input.GetKeyDown(KeyCode.F)) { 
                Destroy(granadePickUp);
                granadePickUp = null;
                granades++;
                canPickupGranade = false;
            }
        }
        else if (canPickupBottle == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(bottlePickUp);
                bottlePickUp = null;
                bottles++;
                canPickupBottle = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "granade") {
            granadePickUp = other.gameObject;
            canPickupGranade = true;
        }
       else if (other.tag == "bottle")
        {
            bottlePickUp = other.gameObject;
            canPickupBottle = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "granade")
        {
            granadePickUp = null;
            canPickupGranade = false;
        }
        else if (other.tag == "bottle")
        {
            bottlePickUp = other.gameObject;
            canPickupBottle = true;
        }
    }
}
