using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenToScenes : MonoBehaviour
{
    public Canvas settingsCanvas;
    public Canvas cameraCanvas;
    public Canvas instructionCanvas;
    public GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick.gameObject.SetActive(false);
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
    public void OpenDrag()
    {
        SceneManager.LoadScene(3);
    }
    public void OpenDuck()
    {
        SceneManager.LoadScene(4);
    }
    public void OpenMemory()
    {
        //Debug.Log("Firebase eventLevelStart called");
        SceneManager.LoadScene(2);
    }

    public void OpenMaze() {
        SceneManager.LoadScene(6);
    }
    public void DisableInstruction()
    {
        instructionCanvas.gameObject.SetActive(false);
    }
    public void DisableInstructionMaze()
    {
        instructionCanvas.gameObject.SetActive(false);
        joystick.gameObject.SetActive(true);
    }
    public void OpenCredits()
    {
        SceneManager.LoadScene(7);
    }
    
}
