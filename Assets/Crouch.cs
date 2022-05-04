using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public CharacterController controller;
    public PlayerMovement pm;
    public float originalHeight;
    public float reducedHeight = 1.25f;

    public float originalspeed = 0f;
    public float reducedspeed = 0f;

    public bool isCrouching = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
        originalspeed = pm.speed;
        reducedspeed = pm.speed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            pm.speed = reducedspeed;
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            isCrouching = false;
            pm.speed = originalspeed;
            
        }

        if (isCrouching) {
            controller.height = reducedHeight;
        }
        else {
            controller.height = originalHeight;
        }
    }
}
