using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    [SerializeField] Vector3 _rotation;

    public Transform Gameobject;

    public float x;

    Vector3 lock1;
    Vector3 lock2;
    
    void Start()
    {
        _rotation.x = 10;
    }

    void Update()
    {
        if (Gameobject.eulerAngles.x <=5)
        {
            _rotation.x = -_rotation.x;
        }
        transform.Rotate(_rotation * Time.deltaTime);
        x = Gameobject.eulerAngles.x;
    }
}
