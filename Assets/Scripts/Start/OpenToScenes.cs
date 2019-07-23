using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenToScenes : MonoBehaviour
{
    public Canvas settingsCanvas;
    public Canvas cameraCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(
                Firebase.Analytics.FirebaseAnalytics.EventJoinGroup,
                Firebase.Analytics.FirebaseAnalytics.ParameterGroupId,
                "spoon_welders"
            );
        
        Debug.Log("Firebase eventLevelStart called");
        SceneManager.LoadScene(2);
    }
}
