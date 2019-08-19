using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text username;

    void Start()
    {
        PlayerPrefs.SetString("Name", "Patrick");
    }

    // Update is called once per frame
    void Update()
    {
        username.text = PlayerPrefs.GetString("Name");
    }
}
