using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {

            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Win");
        }
    }
}

