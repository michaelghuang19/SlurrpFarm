using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenToMemory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OpenMemory()
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent("progress", "percent", 0.4f);
        Debug.Log("Firebase eventLevelStart called");
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
