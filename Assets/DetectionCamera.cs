using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCamera : MonoBehaviour
{
    public GameObject playerTag;
    public GameObject player;
    public Light spotLight;
    Transform lens;
    public Color value;


    void Start()
    {
        value = spotLight.color;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        player = other.gameObject;
        if (other.gameObject.tag == playerTag.GetComponent<GameObject>().tag) {
            Vector3 direction = other.transform.position - lens.position;
            RaycastHit hit;
            if (Physics.Raycast(lens.transform.position, direction.normalized, out hit, 1000))
            {
                spotLight.color = Color.red;
                Debug.Log(hit.collider.name);
            }
        }
    }
}
