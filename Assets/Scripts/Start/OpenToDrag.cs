﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenToDrag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenDrag()
    {
        SceneManager.LoadScene(3);
    }

    public void OpenDuck() {
        SceneManager.LoadScene(5);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
