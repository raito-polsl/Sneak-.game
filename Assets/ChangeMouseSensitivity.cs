using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMouseSensitivity : MonoBehaviour
{
    public Slider sensitivity;

    void FixedUpdate()
    {
        MouseLook.sensitivity = sensitivity.value;
    }
}
