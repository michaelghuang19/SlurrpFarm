using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject beardialogue;

    // Start is called before the first frame update
    void Start()
    {
        beardialogue = GameObject.Find("BearDialogue");

        beardialogue.SetActive(false);
    }

    public void PlayBearDialogue()
    {
        beardialogue.SetActive(true);
    }
}
