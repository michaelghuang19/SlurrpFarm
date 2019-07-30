using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
       
     public int curLevel;
     int curExp;
    public Text currentLevelText;
    public Text currentExpText;
    public Image expBar;
    public Text nameText;
    float originalSize;
    // Start is called before the first frame update
    void Start()
    {
        /* string name = PlayerPrefs.GetString("Name");
        if (name != null) {
            nameText.text = name;
        } else {
            nameText.text = "Patrick";
        } */
        
    }
    void OnEnable()
    {
        
        SceneManager.sceneLoaded += UpdateExpBar;
    }

    void OnDisable()
    {
        
        SceneManager.sceneLoaded -= UpdateExpBar;
    }



    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateExpBar(Scene scene, LoadSceneMode mode)
    {
        originalSize = expBar.rectTransform.rect.width;
        curLevel = PlayerPrefs.GetInt("PlayerLevel");
        curExp = PlayerPrefs.GetInt("CurEXP");
        Debug.Log(curLevel);
        Debug.Log(curExp);
        if(curLevel == 1)
        {
            

            currentExpText.text = curExp.ToString() + '/' + 100.ToString();
            expBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * curExp / 100);
        }
        else if(curLevel == 2)
        {

            currentExpText.text = curExp.ToString() + '/' + 200.ToString();
            expBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * curExp / 200);
        }
        else
        {
            currentExpText.text = curExp.ToString() + '/' + 300.ToString();
            expBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * curExp / 300);
        }
        
        currentLevelText.text = "Lvl" + curLevel.ToString();

    }
}
