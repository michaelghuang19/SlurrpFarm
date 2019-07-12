using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerOpen : MonoBehaviour
{
    [SerializeField]
    Canvas UICanvas;
    [SerializeField]
    Canvas DiscountCanvas;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("gamecontroller start called");
        bool playMusic = Convert.ToBoolean(PlayerPrefs.GetInt("PlayMusic"));
        Debug.Log(playMusic);

        bool levelledUp = Convert.ToBoolean(PlayerPrefs.GetInt("LevelChanged"));
        if (levelledUp) {
            UICanvas.gameObject.SetActive(false);
            DiscountCanvas.gameObject.SetActive(true);
        } else {
            UICanvas.gameObject.SetActive(true);
            DiscountCanvas.gameObject.SetActive(false);
        }
    }

}
