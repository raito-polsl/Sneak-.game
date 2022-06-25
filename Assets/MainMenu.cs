using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);        
    }

     public void Quit() 
    {  
        Debug.Log("QUIT");  
        Application.Quit();  
    }  

    public void Level1()
    {
        SceneManager.LoadScene("Lvl1");

    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");

    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");

    }
}
