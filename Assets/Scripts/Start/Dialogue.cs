using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject bearDialogue;

    // Start is called before the first frame update
    void Start()
    {
        bearDialogue = GameObject.Find("BearUI");
        bearDialogue.SetActive(false);
    }

    public void PlayBearDialogue()
    {
        Debug.Log("Bear Clicked");
        bearDialogue.SetActive(true);
    }

    public void StopBearDialogue()
    {
        Debug.Log("Dialogue Clicked");
        bearDialogue.SetActive(false);
    }
}
