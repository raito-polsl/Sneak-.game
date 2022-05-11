using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAim : MonoBehaviour
{
    // Start is called before the first frame update
    int layerMask; //The layer mask to focus when looking for a ground
    GameObject raycastOrigin; //The origin in the body of the spider to raycast down instead of raycasting the movecube it self
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground"); //Getting the layermask
        raycastOrigin = transform.parent.gameObject;//To get the raycast origin which is usually the parent
    }


    void Update()
    {
        RaycastHit hit; //simple raycast downwards
        if (Physics.Raycast(raycastOrigin.transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point + new Vector3(0f, 0.3f, 0f); //move the cube to the ground
        }

    }
}
