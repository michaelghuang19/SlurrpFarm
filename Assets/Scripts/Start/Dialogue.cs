using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject bearDialogue;

    public GameObject rhinoDialogue;

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
    }

    public void StopBearDialogue()
    {
        Debug.Log("Bear Dialogue Clicked");
        bearDialogue.SetActive(false);
    }

    public void PlayRhinoDialogue()
    {
        Debug.Log("Bear Clicked");
        rhinoDialogue.SetActive(true);
    }

    public void StopRhinoDialogue()
    {
        Debug.Log("Rhino Dialogue Clicked");
        rhinoDialogue.SetActive(false);
    }
}
