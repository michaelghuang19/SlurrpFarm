using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioSwitch : MonoBehaviour
{
    public GameObject switchOn, switchOff;
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        

        
        
    }
    void OnEnable()
    {

        SceneManager.sceneLoaded += UpdateMusic;
    }

    void OnDisable()
    {

        SceneManager.sceneLoaded -= UpdateMusic;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnChangeValue()
    {
        bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if(onoffSwitch)
        {
            switchOn.SetActive(true);
            switchOff.SetActive(false);
            PlayerPrefs.SetInt("PlayMusic", 1);
            backgroundMusic.UnPause();
            
        }
        if(!onoffSwitch)
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);
            PlayerPrefs.SetInt("PlayMusic", 0);
            backgroundMusic.Pause();

        }
    }

    public void UpdateMusic(Scene scene, LoadSceneMode mode)
    {
        
        bool playMusic = Convert.ToBoolean(PlayerPrefs.GetInt("PlayMusic"));
        Debug.Log("1." + playMusic);
        if (playMusic)
        {
            switchOff.SetActive(false);
            switchOn.SetActive(true);
            backgroundMusic.Pause();
        }
        else
        {
            switchOn.SetActive(false);
            switchOff.SetActive(true);
            backgroundMusic.Pause();
       }
    }
}
