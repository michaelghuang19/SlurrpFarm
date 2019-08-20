using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject bearDialogue;
    public GameObject rhinoDialogue;
    public GameObject joystick;
    public Text bearText;
    public Text rhinoText;

    // Start is called before the first frame update
    void Start()
    {
        bearDialogue = GameObject.Find("BearUI");
        bearDialogue.SetActive(false);

        rhinoDialogue = GameObject.Find("RhinoUI");
        rhinoDialogue.SetActive(false);

    }

    public void PlayBearDialogue()
    {
        Debug.Log("Bear Clicked");
        bearDialogue.SetActive(true);
        joystick.SetActive(false);
    }

    public void StopBearDialogue()
    {
        Debug.Log("Bear Dialogue Clicked");
        bearDialogue.SetActive(false);
        joystick.SetActive(true);

        bearText.text = "Visit slurrpfarm.com for more cool products! ";
    }

    public void PlayRhinoDialogue()
    {
        Debug.Log("Rhino Clicked");
        rhinoDialogue.SetActive(true);
        joystick.SetActive(false);
    }

    public void StopRhinoDialogue()
    {
        Debug.Log("Rhino Dialogue Clicked");
        rhinoDialogue.SetActive(false);
        joystick.SetActive(true);

        rhinoText.text = "Eat healthy and you can be a superhero like me! ";
    }
}
