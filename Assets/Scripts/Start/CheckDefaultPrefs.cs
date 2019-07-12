using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDefaultPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerLevel")) {
            PlayerPrefs.SetInt("PlayerLevel", 1);
        }
        if (!PlayerPrefs.HasKey("CurEXP")) {
            PlayerPrefs.SetInt("CurEXP", 0);
        }
        if (!PlayerPrefs.HasKey("PrevGame")) {
            PlayerPrefs.SetInt("PrevGame", 0);
        }
        if (!PlayerPrefs.HasKey("PrevGameCount")) {
            PlayerPrefs.SetInt("PrevGameCount", 0);
        }
        if(!PlayerPrefs.HasKey("PlayMusic"))
        {
            PlayerPrefs.SetInt("PlayMusic", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
