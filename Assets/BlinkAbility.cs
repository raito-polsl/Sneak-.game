using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAbility : MonoBehaviour
{
    public int Uses = 0;
    public float cooldown, distance, speed, destinationMultiplier, cameraHeight = 0f;
    public Transform cam;
    public LayerMask lm;

    int MaxUses = 1;

    float cooldownTimer;
    bool blinking = false;
    Vector3 destination;

    
    void Start()
    {
        cooldownTimer = cooldown;    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Blink();
        }
        if (Uses < MaxUses)
        {
            if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
            else
            {
                Uses += 1;
                cooldownTimer = cooldown;

            }
        }
        if (blinking) {
            var dist = Vector3.Distance(transform.position, destination);
            if (dist > 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            }
            else {
                blinking = false;
            }

        }
    }
    void Blink() {
        if (Uses > 0) {
            Uses -= 1;
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, distance, lm))
            {
                destination = hit.point * destinationMultiplier;
                Debug.DrawLine(cam.position, hit.point * destinationMultiplier, Color.yellow, 2);
            }
            else { 
            destination = (cam.position + cam.forward.normalized * distance) * destinationMultiplier;
                Debug.DrawRay(cam.position, (cam.forward * distance) * destinationMultiplier, Color.green, 2);
            }

            destination.y += cameraHeight;
            blinking= true;
        }
    
    }
}
