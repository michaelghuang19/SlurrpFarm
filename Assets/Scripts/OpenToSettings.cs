using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenToSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene(4);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
