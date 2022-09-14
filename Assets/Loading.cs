using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    

    public void OnTriggerEnter(Collider collision)
    {   if (collision.tag == "Player")
        {
            
           
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}
