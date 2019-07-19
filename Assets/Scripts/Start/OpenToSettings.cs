using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenToSettings : MonoBehaviour
{
    public Canvas settingsCanvas;
    public Canvas cameraCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SettingsEnable()
    {
        settingsCanvas.gameObject.SetActive(true);
        cameraCanvas.gameObject.SetActive(false);
    }
    public void SettingsDisable()
    {
        settingsCanvas.gameObject.SetActive(false);
        cameraCanvas.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
