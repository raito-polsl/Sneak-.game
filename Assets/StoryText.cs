using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryText : MonoBehaviour
{
    public GameObject UiObject;
    public TextMeshProUGUI text;
    [TextArea(3, 10)]
    public string tekst;
    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
        text.text = "siema";
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            text.text = tekst;
            UiObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(UiObject.active && Input.GetKeyDown("q")){
            UiObject.SetActive(false);
        }
    }
}
