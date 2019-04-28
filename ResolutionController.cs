using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionController : MonoBehaviour {
    bool isChanged;

    private void Awake()
    {
        isChanged = false;
        Screen.fullScreen = true;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.R) && !isChanged)
        {
            isChanged = true;
            Screen.fullScreen = !Screen.fullScreen;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.R))
        {
            isChanged = false;
        }
    }
}
