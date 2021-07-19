using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    private bool isOn = false; 


    public void Toggle()
    {        
        isOn = !objectsToToggle[0].activeSelf;

        print("Toggle");

        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(isOn);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Toggle();   
    }   
}
