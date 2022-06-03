using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeThrow : MonoBehaviour
{
    // Start is called before the first frame update

    public float throwForce = 40f;
    public GameObject granadeprefab;
    public GameObject bottlePrefab;
    public ItemHolderController itemHolderController;
    public CharacterController characterController;
    public PickUp amount;
    public ItemHolderController iHC;


    void Start()
    {
        Physics.IgnoreCollision(granadeprefab.GetComponent<Collider>(), characterController.GetComponent<Collider>(),true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && itemHolderController.selectedWeapon == 1)
        {
            if (amount.granades > 0)
            {
                ThrowGranade();
                amount.granades--;
                if (amount.granades == 0) {
                    iHC.selectedWeapon=0;
                    iHC.SelectWeapon();
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && itemHolderController.selectedWeapon == 2)
        {
            if (amount.bottles > 0)
            {
                ThrowBottle();
                amount.bottles--;
                if (amount.bottles == 0)
                {
                    iHC.selectedWeapon = 0;
                    iHC.SelectWeapon();
                }
            }
        }

    }

    void ThrowGranade() { 
        GameObject granade = Instantiate(granadeprefab,transform.position,transform.rotation);
        Transform granadePosition = granade.transform;

        Rigidbody rb =  granade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
    void ThrowBottle()
    {
        GameObject bottle = Instantiate(bottlePrefab, transform.position, transform.rotation);
        Transform bottlePosition = bottle.transform;

        Rigidbody rb = bottle.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
